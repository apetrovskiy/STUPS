/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 02/16/2012
 * Time: 01:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    using System.Collections;
    
    using System.Linq;
    using System.Linq.Expressions;
    
    using UIAutomation.Commands;

    /// <summary>
    /// Description of GetControlCollectionCmdletBase.
    /// </summary>
    public class GetControlCollectionCmdletBase : GetControlCmdletBase
    {
        public GetControlCollectionCmdletBase()
        {
            this.PassThru = false;
        }
        
        public GetControlCollectionCmdletBase(
            AutomationElement[] inputObjectCollection,
            string name,
            string automationId,
            string className,
            string textValue,
            string[] controlType,
            bool caseSensitive)
        {
            this.InputObject = inputObjectCollection;
            this.Name = name;
            this.AutomationId = automationId;
            this.Class = className;
            this.Value = textValue;
            this.ControlType = controlType;
            this.CaseSensitive = caseSensitive;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter Wait { get; set; }
        [Alias("Milliseconds")]
        [Parameter(Mandatory = false)]
        internal new int Timeout { get; set; }
        [Parameter(Mandatory = false)]
        internal new int Seconds {
            get { return Timeout / 1000; } 
            set{ Timeout = value * 1000; }
        }
        
        [Parameter(Mandatory = false)]
        public new string[] ControlType { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        
        // 20130127
//        [Parameter(Mandatory = false)]
//        public SwitchParameter CaseSensitive { get; set; }
        #endregion Parameters

        protected override void BeginProcessing() {
            WriteVerbose(this, "ControlType = " + ControlType);
            WriteVerbose(this, "Class = " + Class);
            WriteVerbose(this, "Name = " + Name);
            WriteVerbose(this, "AutomationId = " + AutomationId);
        }
        
        protected void GetAutomationElementsViaWildcards_FindAll(
            AutomationElement inputObject,
            AndCondition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!this.CheckControl(this)) { return; }
          
            getAutomationElementsWithFindAll(
                inputObject,
                this.Name,
                this.AutomationId,
                this.Class,
                this.Value,
                this.ControlType,
                conditions,
                caseSensitive,
                onlyOneResult,
                onlyTopLevel);
        }
        
        internal ArrayList GetAutomationElementsViaWildcards_FindAll(
            GetControlCollectionCmdletBase cmdlet,
            AutomationElement inputObject,
            AndCondition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            cmdlet.WriteVerbose(cmdlet, "in the GetAutomationElementsViaWildcards_FindAll method");
            
            if (!cmdlet.CheckControl(cmdlet)) { return null; }
            
            cmdlet.WriteVerbose(cmdlet, "still in the GetAutomationElementsViaWildcards_FindAll method");

            ArrayList resultCollection = new ArrayList();
            
            resultCollection =
                getAutomationElementsWithFindAll(
                    inputObject,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.ControlType,
                    conditions,
                    caseSensitive,
                    onlyOneResult,
                    onlyTopLevel);

            cmdlet.WriteVerbose(cmdlet, "with some resultCollection");
            
            if (null == resultCollection || resultCollection.Count == 0) {
                
                WriteVerbose(
                    cmdlet, 
                    "getAutomationElementsWithWalker (" +
                    inputObject.Current.Name +
                    "," +
                    cmdlet.Name +
                    "," +
                    cmdlet.AutomationId +
                    "," +
                    cmdlet.Class +
                    "," +
                    cmdlet.ControlType +
                    "," +
                    caseSensitive.ToString() +
                    "," +
                    onlyOneResult.ToString() +
                    "," +
                    onlyTopLevel.ToString() +
                    ") returned null");

            }
            
            return resultCollection;
        }
        
        protected void GetAutomationElementsViaWildcards(
            AutomationElement inputObject,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!this.CheckControl(this)) { return; }
          
            getAutomationElementsWithWalker(
                inputObject,
                this.Name,
                this.AutomationId,
                this.Class,
                this.ControlType,
                caseSensitive,
                onlyOneResult,
                onlyTopLevel);
        }
        
        internal ArrayList GetAutomationElementsViaWildcards(
            GetControlCollectionCmdletBase cmdlet,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!cmdlet.CheckControl(cmdlet)) { return null; }

            ArrayList resultCollection = new ArrayList();
            
            foreach (AutomationElement inputObject in this.InputObject) {
            
                resultCollection =
                    getAutomationElementsWithWalker(
                        inputObject,
                        cmdlet.Name,
                        cmdlet.AutomationId,
                        cmdlet.Class,
                        cmdlet.ControlType,
                        caseSensitive,
                        onlyOneResult,
                        onlyTopLevel);

                if (null == resultCollection) {
                    WriteVerbose(
                        cmdlet, 
                        "getAutomationElementsWithWalker (" +
                        inputObject.Current.Name +
                        "," +
                        cmdlet.Name +
                        "," +
                        cmdlet.AutomationId +
                        "," +
                        cmdlet.Class +
                        "," +
                        cmdlet.ControlType +
                        "," +
                        caseSensitive.ToString() +
                        "," +
                        onlyOneResult.ToString() +
                        "," +
                        onlyTopLevel.ToString() +
                        ") returrned null");
                }
            
            }
            
            return resultCollection;
        }
        
        private ArrayList getAutomationElementsWithWalker(
            AutomationElement element,
            string name,
            string automationId,
            string className,
            string[] controlType,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            ArrayList resultCollection = new ArrayList();

            System.Windows.Automation.TreeWalker walker = 
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            System.Windows.Automation.AutomationElement oneMoreElement;
            
            try {
                oneMoreElement = 
                    walker.GetFirstChild(element);

                try{
                    WriteVerbose(
                        this, 
                        oneMoreElement.Current.ControlType.ProgrammaticName +
                        "\t" +
                        oneMoreElement.Current.Name + 
                        "\t" +
                        oneMoreElement.Current.AutomationId);
                }
                catch {}

                resultCollection = processAutomationElement(
                        oneMoreElement,
                        name,
                        automationId,
                        className,
                        controlType,
                        caseSensitive,
                        onlyOneResult,
                        onlyTopLevel);

                if ((onlyTopLevel || onlyOneResult) && (null != resultCollection) && resultCollection.Count > 0) {

                    return resultCollection;

                } else if (null != resultCollection) {

                    WriteObject(this, resultCollection);
                }
                
                while (oneMoreElement != null) {
                    oneMoreElement = walker.GetNextSibling(oneMoreElement);

                    try{
                        WriteVerbose(
                            this, 
                            oneMoreElement.Current.ControlType.ProgrammaticName +
                            "\t" +
                            oneMoreElement.Current.Name + 
                            "\t" +
                            oneMoreElement.Current.AutomationId);
                    }
                    catch {}

                    resultCollection = processAutomationElement(
                        oneMoreElement,
                        name,
                        automationId,
                        className,
                        controlType,
                        caseSensitive,
                        onlyOneResult,
                        onlyTopLevel);

                    if ((onlyTopLevel || onlyOneResult) && (null != resultCollection) && resultCollection.Count > 0) {

                        return resultCollection;

                    } else if (null != resultCollection) {

                        WriteObject(this, resultCollection);
                    }
                }
            }
            catch {}
            
            return resultCollection;
        }
        
        private ArrayList getAutomationElementsWithFindAll(
            AutomationElement element,
            string name,
            string automationId,
            string className,
            string textValue,
            string[] controlType,
            AndCondition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            ArrayList resultCollection = new ArrayList();

            try {
                
                AutomationElementCollection results = 
                    element.FindAll(
                        TreeScope.Descendants,
                        conditions);
                this.WriteVerbose(
                    this,
                    "There are roughly " +
                    results.Count.ToString() +
                    " elements");

                resultCollection =
                    ReturnOnlyRightElements(
                        // 20130513
                        this,
                        results,
                        name,
                        automationId,
                        className,
                        textValue,
                        controlType,
                        caseSensitive);

            }
            catch { //(Exception eWildCardSearch) {
                
            }
            
            return resultCollection;
        }
        
//        internal ArrayList returnOnlyRightElements(
//            AutomationElementCollection results,
//            string name,
//            string automationId,
//            string className,
//            string textValue,
//            string[] controlType,
//            bool caseSensitive)
//        {
//                ArrayList resultCollection = new ArrayList();
//                
//                WildcardOptions options;
//                if (caseSensitive) {
//                    options =
//                        WildcardOptions.Compiled;
//                } else {
//                    options =
//                        WildcardOptions.IgnoreCase |
//                        WildcardOptions.Compiled;
//                }
//
//                if (string.Empty == name || 0 == name.Length) { name = "*"; }
//                if (string.Empty == automationId || 0 == automationId.Length) { automationId = "*"; }
//                if (string.Empty == className || 0 == className.Length) { className = "*"; }
//                if (string.Empty == textValue || 0 == textValue.Length) { textValue = "*"; }
//
//                WildcardPattern wildcardName = 
//                    new WildcardPattern(name, options);
//                WildcardPattern wildcardAutomationId = 
//                    new WildcardPattern(automationId, options);
//                WildcardPattern wildcardClass = 
//                    new WildcardPattern(className, options);
//                WildcardPattern wildcardValue = 
//                    new WildcardPattern(textValue, options);
//
//                System.Collections.Generic.List<AutomationElement> list =
//                    new System.Collections.Generic.List<AutomationElement>();
//                foreach (AutomationElement elt in results) {
//                    list.Add(elt);
//                }
//
//            try {
//                var query = list
////                    .Where<AutomationElement>(item => wildcardName.IsMatch(item.Current.Name))
////                    .Where<AutomationElement>(item => wildcardAutomationId.IsMatch(item.Current.AutomationId))
////                    .Where<AutomationElement>(item => wildcardClass.IsMatch(item.Current.ClassName))
////                    .Where<AutomationElement>(item => 
////                                              item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ? 
////                                              //(("*" != textValue) ? wildcardValue.IsMatch((item.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value) : false) :
////                                              (("*" != textValue) ? (positiveMatch(item, wildcardValue, textValue)) : (negativeMatch(textValue))) :
////                                              true
////                                              )
//                    .Where<AutomationElement>(
//                        item => (wildcardName.IsMatch(item.Current.Name) &&
//                                 wildcardAutomationId.IsMatch(item.Current.AutomationId) &&
//                                 wildcardClass.IsMatch(item.Current.ClassName) &&
//                                 // check whether a control has or hasn't ValuePattern
//                                 (item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
//                                  testRealValueAndValueParameter(item, name, automationId, className, textValue, wildcardValue) :
//                                  // check whether the -Value parameter has or hasn't value
//                                  ("*" == textValue ? true : false)
//                                 )
//                                )
//                       )
//                    .ToArray<AutomationElement>();
//
//                this.WriteVerbose(
//                    this,
//                    "There are " +
//                    query.Count().ToString() +
//                    " elements");
//
//                resultCollection.AddRange(query);
//
//                this.WriteVerbose(
//                    this,
//                    "There are " +
//                    resultCollection.Count.ToString() +
//                    " elements");
//                
//            }
//            catch {
//                
//            }
//            
//            return resultCollection;
//        }
        
//        private bool testRealValueAndValueParameter(
//            AutomationElement item,
//            string name,
//            string automationId,
//            string className,
//            string textValue,
//            WildcardPattern wildcardValue)
//        {
//            bool result = false;
//            
//            // getting the real value of a control
//            string realValue = string.Empty;
//            try {
//                realValue =
//                    (item.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
//            }
//            catch {}
//            
//            // if a control's ValuePattern has no value
//            if (string.Empty == realValue) {
//                
//                if ("*" != name || "*" != automationId || "*" != className) {
//                    return true;
//                }
//                return result;
//            }
//            
//            // if there was not specified the -Value parameter
//            if ("*" == textValue) {
//                
//                if ("*" != name || "*" != automationId || "*" != className) {
//                    return true;
//                }
//                
//                // 20130208
//                //return result;
//            }
//            
//            result =
//                wildcardValue.IsMatch(realValue);
//
//            return result;
//        }
        
        private ArrayList processAutomationElement(
            AutomationElement element,
            string name,
            string automationId,
            string className,
            string[] controlType,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            ArrayList resultCollection = new ArrayList();
            
            if (null == name) {
                name = string.Empty;
            }
            if (null == automationId) {
                automationId = string.Empty;
            }
            if (null == className) {
                className = string.Empty;
            }
            
            if ((controlType != null && 
                controlType.Length > 0 && 
                elementOfPossibleControlType(
                    controlType,
                    element.Current.ControlType.ProgrammaticName)) ||
                (controlType == null) ||
                (controlType.Length == 0)) {

                WildcardOptions options;
                if (caseSensitive) {
                    options =
                        WildcardOptions.Compiled;
                } else {
                    options =
                        WildcardOptions.IgnoreCase |
                        WildcardOptions.Compiled;
                }
                
                if (0 == name.Length && 0 == automationId.Length && 0 == className.Length) {
                    name = "*";
                }

                WildcardPattern wildcardName = 
                    new WildcardPattern(name,options);
                
                WildcardPattern wildcardAutomationId = 
                    new WildcardPattern(automationId,options);
                
                WildcardPattern wildcardClass = 
                    new WildcardPattern(className,options);
                
                // 20130125
                // there's a bug 20130125
                bool matched = false;
                
                if (this.FromCache && CurrentData.CacheRequest != null) {
                    if (name.Length > 0 && wildcardName.IsMatch(element.Cached.Name)) {
                        matched = true;
                    } else if (automationId.Length > 0 && 
                               wildcardAutomationId.IsMatch(element.Cached.AutomationId)) {
                        matched = true;
                    } else if (className.Length > 0 &&
                               wildcardClass.IsMatch(element.Cached.ClassName)) {
                        matched = true;
                    }
                } else {
                    if (name.Length > 0 && wildcardName.IsMatch(element.Current.Name)) {
                        matched = true;
                    } else if (automationId.Length > 0 && 
                               wildcardAutomationId.IsMatch(element.Current.AutomationId)) {
                        matched = true;
                    } else if (className.Length > 0 &&
                               wildcardClass.IsMatch(element.Current.ClassName)) {
                        matched = true;
                    }
                }

                

                
                if (matched) {
                    
                    resultCollection.Add(element);
                    
                    if (onlyOneResult) {

                        throw (new Exception("wrong code here!"));

                    } else {
                        
                        return resultCollection;
                    }
                }
                
                
            }
            
            if (!onlyTopLevel) {
                
                getAutomationElementsWithWalker(
                    element,
                    name,
                    automationId,
                    className,
                    controlType,
                    caseSensitive,
                    onlyOneResult,
                    onlyTopLevel);
                
            }

            return resultCollection;
        }
        
        internal bool elementOfPossibleControlType(
            string[] controlType, 
            string elementControlType)
        {
            bool result = false;
            
            if (null == controlType || 0 == controlType.Length) {
                return result;
            }
            if (null == elementControlType || string.Empty == elementControlType) {
                return result;
            }

            // if all the item are empty strings
            string tempString = string.Empty;
            for (int i = 0; i < controlType.Length; i++) {
            	tempString += controlType[i];
            }
            if (tempString.Length == 0) {
            	result = true;
            	return result;
            }
            elementControlType =
                elementControlType.Substring(
                    elementControlType.IndexOf('.') + 1);
            for (int i = 0; i < controlType.Length; i++) {
                if (controlType[i].ToUpper() == elementControlType.ToUpper()) {
                    result = true;
            	}
            }
            
            return result;
        }
        
        protected void GetAutomationElementsSiblings(bool nextSibling)
        {
            if (!this.CheckControl(this)) { return; }
            
            System.Windows.Automation.TreeWalker walker = 
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {
            
                AutomationElement sibling = null;
                if (nextSibling) {
                    // 20120823
                    //sibling = walker.GetNextSibling(this.InputObject);
                    sibling = walker.GetNextSibling(inputObject);
                } else {
                    // 20120823
                    //sibling = walker.GetPreviousSibling(this.InputObject);
                    sibling = walker.GetPreviousSibling(inputObject);
                }
                WriteObject(this, sibling);
            
            } // 20120823
            
        }
        
        protected void GetAutomationElementsChildren(AutomationElement inputObject, bool firstChild)
        {
            if (!this.CheckControl(this)) { return; }
            
            System.Windows.Automation.TreeWalker walker = 
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            AutomationElement sibling = null;
            if (firstChild) {
                // 20120824
                //sibling = walker.GetFirstChild(this.InputObject);
                sibling = walker.GetFirstChild(inputObject);
            } else {
                // 20120824
                //sibling = walker.GetLastChild(this.InputObject);
                sibling = walker.GetLastChild(inputObject);
            }
            WriteObject(this, sibling);
        }
        
        protected void GetAutomationElements(TreeScope scope)
        {
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {
            
            System.Collections.Generic.List<AutomationElement >  searchResults = 
                new System.Collections.Generic.List<AutomationElement > ();
            AutomationElementCollection temporaryResults = null;
            AutomationElement[] outResult;
            
            if (scope == TreeScope.Children ||
                scope == TreeScope.Descendants) {
                WriteVerbose(this, "selected TreeScope." + scope.ToString());
                AndCondition[] conditions = getControlsConditions(this);
                if (conditions != null && conditions.Length > 0) {
                    WriteVerbose(this, "conditions number: " +
                                 conditions.Length.ToString());
                    for (int i = 0; i < conditions.Length; i++) {
                        if (conditions[i] != null) {
                            WriteVerbose(this, conditions[i].GetConditions());
                            temporaryResults =
                                // 20120823
                                //this.InputObject.FindAll(scope,
                                inputObject.FindAll(scope,
                                                         conditions[i]);
                            if (temporaryResults.Count > 0) {
                                foreach (AutomationElement element in temporaryResults) {
                                    searchResults.Add(element);
                                }
                            }
                        }
                    }
                } else {
                    WriteVerbose(this, "no conditions. Performing search with TrueCondition");
                    temporaryResults =
                        // 20120823
                        //this.InputObject.FindAll(scope,
                        inputObject.FindAll(scope,
                                                 Condition.TrueCondition);
                    if (temporaryResults.Count > 0) {
                        WriteVerbose(this, 
                                     "returned " + 
                                     temporaryResults.Count.ToString() + 
                                     " results");
                        foreach (AutomationElement element in temporaryResults) {
                            searchResults.Add(element);
                        }
                    }
                }
                WriteVerbose(this, "results found: " + searchResults.Count.ToString());
                WriteObject(this, searchResults.ToArray());
            } // if (scope == TreeScope.Children ||
                //scope == TreeScope.Descendants)
            if (scope == TreeScope.Parent ||
                scope == TreeScope.Ancestors) {
                outResult = 
                    // 20120823
                    //UIAHelper.GetParentOrAncestor(this.InputObject, scope);
                    UIAHelper.GetParentOrAncestor(inputObject, scope);
                WriteObject(this, outResult);
            }
                
            } // 20120823
            
        }
    }
}
