using UIAutomation.Commands;
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
            string[] controlType,
            bool caseSensitive)
        {
//                                GetControlCollectionCmdletBase cmdlet1 = 
//                                    new GetControlCollectionCmdletBase();
//                                    //(GetControlCollectionCmdletBase)cmdlet;
//                                cmdlet1.InputObject = cmdlet.InputObject;
//                                cmdlet1.Name = cmdlet.Name;
//                                cmdlet1.AutomationId = cmdlet.AutomationId;
//                                cmdlet1.Class = cmdlet.Class;
//                                cmdlet1.CaseSensitive = this.caseSensitive;
//                                // 20120824
//                                //cmdlet1.ControlType = cmdlet.ControlType;
//                                System.Collections.ArrayList arrList = 
//                                    new System.Collections.ArrayList();
//                                arrList.Add(cmdlet.ControlType);
//                                cmdlet1.ControlType = (string[])arrList.ToArray(typeof(string));

            this.InputObject = inputObjectCollection;
            this.Name = name;
            this.AutomationId = automationId;
            this.Class = className;
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
        
        [Parameter(Mandatory = false)]
        public SwitchParameter CaseSensitive { get; set; }
        #endregion Parameters

        
        protected override void BeginProcessing() {
            WriteVerbose(this, "ControlType = " + ControlType);
            WriteVerbose(this, "Class = " + Class);
            WriteVerbose(this, "Name = " + Name);
            WriteVerbose(this, "AutomationId = " + AutomationId);
        }
        
        protected void GetAutomationElementsViaWildcards_FindAll(
            // 20120824
            AutomationElement inputObject,
            AndCondition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!this.CheckControl(this)) { return; }
          
            getAutomationElementsWithFindAll(
                // 20120824
                //this.InputObject,
                inputObject,
                this.Name,
                this.AutomationId,
                this.Class,
                this.ControlType,
                conditions,
                caseSensitive,
                onlyOneResult,
                onlyTopLevel);
        }
        
        // 20120824
        //internal AutomationElement GetAutomationElementsViaWildcards_FindAll(
        //internal AutomationElementCollection GetAutomationElementsViaWildcards_FindAll(
        internal ArrayList GetAutomationElementsViaWildcards_FindAll(
            GetControlCollectionCmdletBase cmdlet,
            AndCondition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            
            if (!cmdlet.CheckControl(cmdlet)) { return null; }

            ArrayList resultCollection = new ArrayList();
            
            // 20120824
            foreach (AutomationElement inputObject in this.InputObject) {
            
            resultCollection =
                getAutomationElementsWithFindAll(
                    // 20120824
                    //cmdlet.InputObject,
                    inputObject,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.ControlType,
                    conditions,
                    caseSensitive,
                    onlyOneResult,
                    onlyTopLevel);

            // 20120824
            //if (result == null) {
            if (null == resultCollection || resultCollection.Count == 0) {
                
                WriteVerbose(
                    cmdlet, 
                    "getAutomationElementsWithWalker (" +
                    // 20120824
                    //cmdlet.InputObject.Current.Name +
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
            
            } // 20120824
            
            // 20120824
            //return result;
            return resultCollection;
        }
        
        protected void GetAutomationElementsViaWildcards(
            // 20120824
            AutomationElement inputObject,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!this.CheckControl(this)) { return; }
          
            getAutomationElementsWithWalker(
                // 20120824
                //this.InputObject,
                inputObject,
                this.Name,
                this.AutomationId,
                this.Class,
                this.ControlType,
                caseSensitive,
                onlyOneResult,
                onlyTopLevel);
        }
        
        // 20120824
        //internal AutomationElement GetAutomationElementsViaWildcards(
        //internal AutomationElementCollection GetAutomationElementsViaWildcards(
        internal ArrayList GetAutomationElementsViaWildcards(
            GetControlCollectionCmdletBase cmdlet,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!cmdlet.CheckControl(cmdlet)) { return null; }

            // 20120824
            //AutomationElement result = null;
            //AutomationElementCollection resultCollection = null;
            ArrayList resultCollection = new ArrayList();
            
            // 20120824
            foreach (AutomationElement inputObject in this.InputObject) {
            
            // 20120824
            //result = 
            resultCollection =
                getAutomationElementsWithWalker(
                    // 20120824
                    //cmdlet.InputObject,
                    inputObject,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.ControlType,
                    caseSensitive,
                    onlyOneResult,
                    onlyTopLevel);

            // 20120824
            //if (result == null) {
            if (null == resultCollection) {
                WriteVerbose(
                    cmdlet, 
                    "getAutomationElementsWithWalker (" +
                    // 20120824
                    //cmdlet.InputObject.Current.Name +
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
            
            } // 20120824
            
            // 20120824
            //return result;
            return resultCollection;
        }
        
        // 20120824
        //private AutomationElement getAutomationElementsWithWalker(
        //private AutomationElementCollection getAutomationElementsWithWalker(
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
            // 20120824
            //AutomationElement result = null;
            //AutomationElementCollection resultCollection = null;
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

                // 20120824
                //result = processAutomationElement(
                resultCollection = processAutomationElement(
                        oneMoreElement,
                        name,
                        automationId,
                        className,
                        controlType,
                        caseSensitive,
                        onlyOneResult,
                        onlyTopLevel);

                // 20120824
                //if ((onlyTopLevel || onlyOneResult) && (result != null)) {
                if ((onlyTopLevel || onlyOneResult) && (null != resultCollection) && resultCollection.Count > 0) {
                    // 20120824
                    //return result; // returns only one window or control
                    //return resultCollection[0];
                    return resultCollection;
                // 20120824
                //} else if (result != null) {
                } else if (null != resultCollection) {
                    // 20120824
                    //WriteObject(this, result);
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

                    // 20120824
                    //result = processAutomationElement(
                    resultCollection = processAutomationElement(
                        oneMoreElement,
                        name,
                        automationId,
                        className,
                        controlType,
                        caseSensitive,
                        onlyOneResult,
                        onlyTopLevel);

                    // 20120824
                    //if ((onlyTopLevel || onlyOneResult) && (result != null)) {
                    if ((onlyTopLevel || onlyOneResult) && (null != resultCollection) && resultCollection.Count > 0) {
                        // 20120824
                        //return result; // returns only one window or control
                        return resultCollection;
                    // 20120824
                    //} else if (result != null) {
                    } else if (null != resultCollection) {
                        // 20120824
                        //WriteObject(this, result);
                        WriteObject(this, resultCollection);
                    }
                }
            }
            catch {}
            
            // 20120824
            //return result;
            return resultCollection;
        }
        
        // 20120824
        //private AutomationElement getAutomationElementsWithFindAll(
        //private AutomationElementCollection getAutomationElementsWithFindAll(
        private ArrayList getAutomationElementsWithFindAll(
            AutomationElement element,
            string name,
            string automationId,
            string className,
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
                
                foreach (AutomationElement oneMoreElement in results) {
                    
//                    if (this.FromCache && CurrentData.CacheRequest != null) {
//                        
//                        try{
//                            WriteVerbose(
//                                this, 
//                                oneMoreElement.Cached.ControlType.ProgrammaticName +
//                                "\t" +
//                                oneMoreElement.Cached.Name + 
//                                "\t" +
//                                oneMoreElement.Cached.AutomationId);
//                            
//                        }
//                        catch {}
//                    } else {
//                        
//                        try{
//                            WriteVerbose(
//                                this, 
//                                oneMoreElement.Current.ControlType.ProgrammaticName +
//                                "\t" +
//                                oneMoreElement.Current.Name + 
//                                "\t" +
//                                oneMoreElement.Current.AutomationId);
//                        }
//                        catch {}
//                    }

                    
                    // 20120824
                    //result = processAutomationElement(
                    //resultCollection = processAutomationElement(
                    resultCollection.AddRange(processAutomationElement(
                            oneMoreElement,
                            name,
                            automationId,
                            className,
                            controlType,
                            caseSensitive,
                            // 20120824
                            //true, //onlyOneResult,
                            false,
                            true)); //onlyTopLevel);
//                    if (null != resultCollection) {
//                        WriteVerbose(this, resultCollection.Count.ToString());
//                    } else {
//                        WriteVerbose(this, "null == resultCollection");
//                    }
                    
                    // 20120824
                    //if ((onlyTopLevel || onlyOneResult) && (result != null)) {
                    if ((onlyTopLevel || onlyOneResult) && (null != resultCollection) && (resultCollection.Count > 0)) {
                        
                        // 20120824
                        //return result; // returns only one window or control
                        //AutomationElementCollection shortCollection = resultCollection[0] as AutomationElementCollection;
                        //return (resultCollection[0] as AutomationElementCollection);
                        //return shortCollection;
                        return resultCollection;
                    // 20120824
                    //} else if (result != null) {
                    } else if (null != resultCollection) {
                        
                        // 20120824
                        //WriteObject(this, result);
                        // 20120824
                        //WriteObject(this, resultCollection);
                    }
                    
                }
                
            }
            catch {}
            
            // 20120824
            //return result;
            return resultCollection;
        }
        
        // 20120824
        //private AutomationElement processAutomationElement(
        //private AutomationElementCollection processAutomationElement(
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
            // 20120824
            //AutomationElement result = null;
            //AutomationElementCollection resultCollection = null;
            ArrayList resultCollection = new ArrayList();
            
            // 20130125 // ??
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
//Console.WriteLine("name = " + name);
//Console.WriteLine("automationId = " + automationId);
//Console.WriteLine("className = " + className);
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
                    
                    // 20120824
                    resultCollection.Add(element);
                    
                    if (onlyOneResult) {
                        
                        // 20120824
                        //result = element;
                        //resultCollection = (AutomationElementCollection)element as AutomationElementCollection;
//                        AutomationElement[] resultArray = new AutomationElement[1];
//                        resultArray[0] = element;
//                        resultCollection = resultArray as AutomationElementCollection;
                            throw (new Exception("wrong code here!"));

                    } else {
                        
                        // 20120824
                        //WriteObject(this, element);  // ??????
                        
                        // 20120824
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
            // 20120824
            //return result;
            return resultCollection;
        }
        
        private bool elementOfPossibleControlType(
            string[] controlType, 
            string elementControlType)
        {
            bool result = false;

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
