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
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    using System.Collections;
    
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using Commands;

    /// <summary>
    /// Description of GetControlCollectionCmdletBase.
    /// </summary>
    public class GetControlCollectionCmdletBase : GetControlCmdletBase
    {
        public GetControlCollectionCmdletBase()
        {
            PassThru = false;
        }
        
        public GetControlCollectionCmdletBase(
            IUiElement[] inputObjectCollection,
            string name,
            string automationId,
            string className,
            string textValue,
            string[] controlType,
            bool caseSensitive)
        {
            InputObject = inputObjectCollection;
            Name = name;
            AutomationId = automationId;
            Class = className;
            Value = textValue;
            ControlType = controlType;
            CaseSensitive = caseSensitive;
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
        public virtual new string[] ControlType { get; set; }
        
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
            IUiElement inputObject,
            AndCondition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel,
            bool viaWildcardOrRegex)
        {
            if (!CheckAndPrepareInput(this)) { return; }
          
            GetAutomationElementsWithFindAll(
                inputObject,
                Name,
                AutomationId,
                Class,
                Value,
                ControlType,
                conditions,
                caseSensitive,
                onlyOneResult,
                onlyTopLevel,
                viaWildcardOrRegex);
        }
        
        internal List<IUiElement> GetAutomationElementsViaWildcards_FindAll(
            GetControlCollectionCmdletBase cmdlet,
            IUiElement inputObject,
            Condition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel,
            bool viaWildcardOrRegex)
        {
            cmdlet.WriteVerbose(cmdlet, "in the GetAutomationElementsViaWildcards_FindAll method");
            
            if (!cmdlet.CheckAndPrepareInput(cmdlet)) { return null; } // ?? 20131107
            
            cmdlet.WriteVerbose(cmdlet, "still in the GetAutomationElementsViaWildcards_FindAll method");
            
            List<IUiElement> resultCollection = new List<IUiElement>();
            
            resultCollection =
                GetAutomationElementsWithFindAll(
                    inputObject,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.ControlType,
                    conditions,
                    caseSensitive,
                    onlyOneResult,
                    onlyTopLevel,
                    viaWildcardOrRegex);
            
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
            IUiElement inputObject,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!CheckAndPrepareInput(this)) { return; }
          
            GetAutomationElementsWithWalker(
                inputObject,
                Name,
                AutomationId,
                Class,
                ControlType,
                caseSensitive,
                onlyOneResult,
                onlyTopLevel);
        }
        
        internal List<IUiElement> GetAutomationElementsViaWildcards(
            GetControlCollectionCmdletBase cmdlet,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            if (!cmdlet.CheckAndPrepareInput(cmdlet)) { return null; }
            
            List<IUiElement> resultCollection = new List<IUiElement>();
            
            foreach (IUiElement inputObject in InputObject) {
            
                resultCollection =
                    GetAutomationElementsWithWalker(
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
        
        private List<IUiElement> GetAutomationElementsWithWalker(
            IUiElement element,
            string name,
            string automationId,
            string className,
            string[] controlType,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            List<IUiElement> resultCollection = new List<IUiElement>();

            TreeWalker walker = 
                new TreeWalker(
                    Condition.TrueCondition);
            // 20131109
            //System.Windows.Automation.AutomationElement oneMoreElement;

            try {
                // 20131118
                // property to method
                //IUiElement oneMoreElement = ObjectsFactory.GetUiElement(walker.GetFirstChild(element.SourceElement));
                // 20140102
                // IUiElement oneMoreElement = AutomationFactory.GetUiElement(walker.GetFirstChild(element.GetSourceElement()));
                IUiElement oneMoreElement = AutomationFactory.GetUiElement(walker.GetFirstChild(element.GetSourceElement() as AutomationElement));

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

                resultCollection = ProcessAutomationElement(
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
                    
                    // 20131109
                    //oneMoreElement = walker.GetNextSibling(oneMoreElement.SourceElement);
                    // 20131112
                    //oneMoreElement = new UiElement(walker.GetNextSibling(oneMoreElement.SourceElement));
                    // 20131118
                    // property to method
                    //oneMoreElement = ObjectsFactory.GetUiElement(walker.GetNextSibling(oneMoreElement.SourceElement));
                    // 20140102
                    // oneMoreElement = AutomationFactory.GetUiElement(walker.GetNextSibling(oneMoreElement.GetSourceElement()));
                    oneMoreElement = AutomationFactory.GetUiElement(walker.GetNextSibling(oneMoreElement.GetSourceElement() as AutomationElement));

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

                    resultCollection = ProcessAutomationElement(
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
        
        internal List<IUiElement> GetAutomationElementsWithFindAll(
            IUiElement element,
            string name,
            string automationId,
            string className,
            string textValue,
            string[] controlType,
            Condition conditions,
            bool caseSensitiveParam,
            bool onlyOneResult,
            bool onlyTopLevel,
            bool viaWildcardOrRegex)
        {
            List<IUiElement> resultCollection = new List<IUiElement>();

            try {
                
                IUiEltCollection results =
                    element.FindAll(
                        TreeScope.Descendants,
                        conditions);
                WriteVerbose(
                    this,
                    "There are roughly " +
                    results.Count.ToString() +
                    " elements");
                
                resultCollection =
                    WindowSearch.ReturnOnlyRightElements(
                        // this,
                        results,
                        name,
                        automationId,
                        className,
                        textValue,
                        controlType,
                        caseSensitiveParam,
                        viaWildcardOrRegex);
                
                // 20130608
                results = null;
                
            }
            catch { //(Exception eWildCardSearch) {
                
            }
            
            return resultCollection;
        }
        
        /*
        internal List<IUiElement> GetAutomationElementsWithFindAll(
            IUiElement element,
            string name,
            string automationId,
            string className,
            string textValue,
            string[] controlType,
            Condition conditions,
            bool caseSensitiveParam,
            bool onlyOneResult,
            bool onlyTopLevel,
            bool viaWildcardOrRegex)
        {
            List<IUiElement> resultCollection = new List<IUiElement>();

            try {
                
                IUiEltCollection results =
                    element.FindAll(
                        TreeScope.Descendants,
                        conditions);
                WriteVerbose(
                    this,
                    "There are roughly " +
                    results.Count.ToString() +
                    " elements");
                
                resultCollection =
                    ReturnOnlyRightElements(
                        this,
                        results,
                        name,
                        automationId,
                        className,
                        textValue,
                        controlType,
                        caseSensitiveParam,
                        viaWildcardOrRegex);
                
                // 20130608
                results = null;
                
            }
            catch { //(Exception eWildCardSearch) {
                
            }
            
            return resultCollection;
        }
        */
        
        private List<IUiElement> ProcessAutomationElement(
            IUiElement element,
            string name,
            string automationId,
            string className,
            string[] controlType,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel)
        {
            List<IUiElement> resultCollection = new List<IUiElement>();
            
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
                ElementOfPossibleControlType(
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
                
                if (FromCache && CurrentData.CacheRequest != null) {
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
                
                GetAutomationElementsWithWalker(
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
        
        internal bool ElementOfPossibleControlType(
            string[] controlType, 
            string elementControlType)
        {
            bool result = false;
            
            if (null == controlType || 0 == controlType.Length) {
                return result;
            }
            if (string.IsNullOrEmpty(elementControlType)) {
                return result;
            }

            /*
            if (null == elementControlType || string.Empty == elementControlType) {
                return result;
            }
            */

            // if all the item are empty strings
            string tempString = controlType.Aggregate(string.Empty, (current, t) => current + t);
            /*
            for (int i = 0; i < controlType.Length; i++)
            {
                tempString += controlType[i];
            }
            */

            if (tempString.Length == 0) {
            	result = true;
            	return result;
            }
            elementControlType =
                elementControlType.Substring(
                    elementControlType.IndexOf('.') + 1);
            foreach (string controlTypeName in controlType.Where(controlTypeName => String.Equals(controlTypeName, elementControlType, StringComparison.CurrentCultureIgnoreCase)))
            {
                result = true;
            }

            /*
            foreach (string controlTypeName in controlType)
            {
                if (controlTypeName.ToUpper() == elementControlType.ToUpper())
                {
                    result = true;
                }

            }
            */

            /*
            for (int i = 0; i < controlType.Length; i++) {
                if (controlType[i].ToUpper() == elementControlType.ToUpper()) {
                    result = true;
            	}
            }
            */

            return result;
        }
        
        protected void GetAutomationElementsSiblings(bool nextSibling)
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            TreeWalker walker = 
                new TreeWalker(
                    Condition.TrueCondition);
            
            // 20120823
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            /*
            foreach (IUiElement sibling in from inputObject in InputObject let sibling = null select nextSibling ? ObjectsFactory.GetUiElement(walker.GetNextSibling(inputObject.GetSourceElement())) : ObjectsFactory.GetUiElement(walker.GetPreviousSibling(inputObject.GetSourceElement())))
            {
                //if (nextSibling) {
                //    // 20120823
                //    //sibling = walker.GetNextSibling(this.InputObject);
                //    sibling = walker.GetNextSibling(inputObject);
                //} else {
                //    // 20120823
                //    //sibling = walker.GetPreviousSibling(this.InputObject);
                //    sibling = walker.GetPreviousSibling(inputObject);
                //}
                
                // 20131113
                // WriteObject(this, sibling);
                WriteObject(this, sibling);
            }
            */

            // 20140111
            // foreach (IUiElement sibling in from inputObject in InputObject let sibling = null select nextSibling ? AutomationFactory.GetUiElement(walker.GetNextSibling(inputObject.GetSourceElement() as AutomationElement)) : AutomationFactory.GetUiElement(walker.GetPreviousSibling(inputObject.GetSourceElement() as AutomationElement)))
            // {
            //     WriteObject(this, sibling);
            // }
            
            foreach (IUiElement inputObject in InputObject) {
                
                IUiElement sibling = null;
                // 20140102
                // sibling = nextSibling ? AutomationFactory.GetUiElement(walker.GetNextSibling(inputObject.GetSourceElement())) : AutomationFactory.GetUiElement(walker.GetPreviousSibling(inputObject.GetSourceElement()));
                sibling = nextSibling ? AutomationFactory.GetUiElement(walker.GetNextSibling(inputObject.GetSourceElement() as AutomationElement)) : AutomationFactory.GetUiElement(walker.GetPreviousSibling(inputObject.GetSourceElement() as AutomationElement));
                
                WriteObject(this, sibling);
            
            } // 20120823
            

            /*
            foreach (IUiElement inputObject in this.InputObject) {
                
                // 20131109
                //AutomationElement sibling = null;
                //sibling = nextSibling ? walker.GetNextSibling(inputObject) : walker.GetPreviousSibling(inputObject);
                IUiElement sibling = null;
                // 20131112
                //sibling = nextSibling ? (new UiElement(walker.GetNextSibling(inputObject.SourceElement))) : (new UiElement(walker.GetPreviousSibling(inputObject.SourceElement)));
                sibling = nextSibling ? ObjectsFactory.GetUiElement(walker.GetNextSibling(inputObject.SourceElement)) : ObjectsFactory.GetUiElement(walker.GetPreviousSibling(inputObject.SourceElement));

                
                //if (nextSibling) {
                //    // 20120823
                //    //sibling = walker.GetNextSibling(this.InputObject);
                //    sibling = walker.GetNextSibling(inputObject);
                //} else {
                //    // 20120823
                //    //sibling = walker.GetPreviousSibling(this.InputObject);
                //    sibling = walker.GetPreviousSibling(inputObject);
                //}
                
                WriteObject(this, sibling);
            
            } // 20120823
            */
            
        }
        
        // 20131109
        //protected void GetAutomationElementsChildren(AutomationElement inputObject, bool firstChild)
        protected void GetAutomationElementsChildren(IUiElement inputObject, bool firstChild)
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            TreeWalker walker = 
                new TreeWalker(
                    Condition.TrueCondition);
            
            // 20131109
            //AutomationElement sibling = null;
            //sibling = firstChild ? walker.GetFirstChild(inputObject) : walker.GetLastChild(inputObject);
            IUiElement sibling = null;
            // 20131112
            //sibling = firstChild ? (new UiElement(walker.GetFirstChild(inputObject.SourceElement))) : (new UiElement(walker.GetLastChild(inputObject.SourceElement)));
            // 20131118
            // property to method
            //sibling = firstChild ? ObjectsFactory.GetUiElement(walker.GetFirstChild(inputObject.SourceElement)) : ObjectsFactory.GetUiElement(walker.GetLastChild(inputObject.SourceElement));
            // 20131118
            // property to method
            //sibling = firstChild ? ObjectsFactory.GetUiElement(walker.GetFirstChild(inputObject.SourceElement)) : ObjectsFactory.GetUiElement(walker.GetLastChild(inputObject.GetSourceElement()));
            // 20140102
            // sibling = firstChild ? AutomationFactory.GetUiElement(walker.GetFirstChild(inputObject.GetSourceElement())) : AutomationFactory.GetUiElement(walker.GetLastChild(inputObject.GetSourceElement()));
            sibling = firstChild ? AutomationFactory.GetUiElement(walker.GetFirstChild(inputObject.GetSourceElement() as AutomationElement)) : AutomationFactory.GetUiElement(walker.GetLastChild(inputObject.GetSourceElement() as AutomationElement));

            /*
            if (firstChild) {
                // 20120824
                //sibling = walker.GetFirstChild(this.InputObject);
                sibling = walker.GetFirstChild(inputObject);
            } else {
                // 20120824
                //sibling = walker.GetLastChild(this.InputObject);
                sibling = walker.GetLastChild(inputObject);
            }
            */
            WriteObject(this, sibling);
        }
        
        protected void GetAutomationElements(TreeScope scope)
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {
                
                List<IUiElement> searchResults = 
                    new List<IUiElement>();
                
                if (scope == TreeScope.Children ||
                    scope == TreeScope.Descendants) {
                    WriteVerbose(this, "selected TreeScope." + scope.ToString());
                    
                    // Condition conditions = GetWildcardSearchCondition(this);
                    var controlSearch =
                        AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
                    
                    Condition conditions =
                        ControlSearch.GetWildcardSearchCondition(
//                            new ControlSearchData {
//                                InputObject = this.InputObject,
//                                ContainsText = this.ContainsText,
//                                Name = this.Name,
//                                AutomationId = this.AutomationId,
//                                Class = this.Class,
//                                Value = this.Value,
//                                ControlType = this.ControlType,
//                                SearchCriteria = this.SearchCriteria,
//                                Win32 = this.Win32,
//                                CaseSensitive = this.CaseSensitive,
//                                Regex = this.Regex
//                            },
                            controlSearch.ConvertCmdletToControlSearchData(this));
                    
                    IUiEltCollection temporaryResults = null;
                    if (conditions != null)
                    {
                            temporaryResults =
                                inputObject.FindAll(
                                    scope,
                                    conditions);
                            
                            searchResults.AddRange(temporaryResults.Cast<IUiElement>());
                    }
                    else {
                        WriteVerbose(this, "no conditions. Performing search with TrueCondition");
                        temporaryResults =
                            inputObject.FindAll(
                                scope,
                                Condition.TrueCondition);
                        if (temporaryResults.Count > 0)
                        {
                            WriteVerbose(this, 
                                         "returned " + 
                                         temporaryResults.Count.ToString() + 
                                         " results");
                            searchResults.AddRange(temporaryResults.Cast<IUiElement>());
                        }
                    }
                    WriteVerbose(this, "results found: " + searchResults.Count.ToString());
                    WriteObject(this, searchResults.ToArray());
                } // if (scope == TreeScope.Children ||
                //scope == TreeScope.Descendants)
                if (scope != TreeScope.Parent && scope != TreeScope.Ancestors) continue;
                
                IUiElement[] outResult = inputObject.GetParentOrAncestor(scope);
                WriteObject(this, outResult);
                
            } // 20120823
            
        }
    }
}
