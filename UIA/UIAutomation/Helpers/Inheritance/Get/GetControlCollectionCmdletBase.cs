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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Description of GetControlCollectionCmdletBase.
    /// </summary>
    public class GetControlCollectionCmdletBase : GetControlCmdletBase
    {
        public GetControlCollectionCmdletBase()
        {
            PassThru = false;
        }
        
        public GetControlCollectionCmdletBase(ControlSearcherData data)
        {
            InputObject = data.InputObject;
            Name = data.Name;
            AutomationId = data.AutomationId;
            Class = data.Class;
            Value = data.Value;
            ControlType = data.ControlType;
            CaseSensitive = data.CaseSensitive;
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        internal new SwitchParameter Wait { get; set; }
        [Alias("Milliseconds")]
        [UiaParameter][Parameter(Mandatory = false)]
        internal new int Timeout { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        internal new int Seconds {
            get { return Timeout / 1000; } 
            set{ Timeout = value * 1000; }
        }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public virtual new string[] ControlType { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        
        // 20130127
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter CaseSensitive { get; set; }
        #endregion Parameters
        
        // not used
//        protected void GetAutomationElementsViaWildcards_FindAll(
//            IUiElement inputObject,
//            classic.AndCondition conditions,
//            bool caseSensitive,
//            bool onlyOneResult,
//            bool onlyTopLevel,
//            bool viaWildcardOrRegex)
//        {
//            if (!CheckAndPrepareInput(this)) { return; }
//            
//            var controlSearcherData =
//                new ControlSearcherData {
//                Name = this.Name,
//                AutomationId = this.AutomationId,
//                Class = this.Class,
//                Value = this.Value,
//                ControlType = this.ControlType
//            };
//            
//            GetAutomationElementsWithFindAll(
//                inputObject,
//                controlSearcherData,
//                conditions,
//                caseSensitive,
//                onlyOneResult,
//                onlyTopLevel,
//                viaWildcardOrRegex);
//        }
        
        internal List<IUiElement> GetAutomationElementsViaWildcards_FindAll(
            ControlSearcherData data,
            IUiElement inputObject,
            classic.Condition conditions,
            bool caseSensitive,
            bool onlyOneResult,
            bool onlyTopLevel,
            bool viaWildcardOrRegex)
        {
            var resultCollection = new List<IUiElement>(); // ? make it null ??
            
            resultCollection =
                GetAutomationElementsWithFindAll(
                    inputObject,
                    data,
                    conditions,
                    caseSensitive,
                    onlyOneResult,
                    onlyTopLevel,
                    viaWildcardOrRegex);
            
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
            
            var resultCollection = new List<IUiElement>();
            
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
            var resultCollection = new List<IUiElement>();
            
            var walker = 
                new classic.TreeWalker(
                    classic.Condition.TrueCondition);
            
            try {
                
                IUiElement oneMoreElement = AutomationFactory.GetUiElement(walker.GetFirstChild(element.GetSourceElement() as classic.AutomationElement));
                
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
                    
                    oneMoreElement = AutomationFactory.GetUiElement(walker.GetNextSibling(oneMoreElement.GetSourceElement() as classic.AutomationElement));
                    
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
            
            walker = null;
            
            return resultCollection;
        }
        
        internal List<IUiElement> GetAutomationElementsWithFindAll(
            IUiElement element,
            ControlSearcherData data,
            classic.Condition conditions,
            bool caseSensitiveParam,
            bool onlyOneResult,
            bool onlyTopLevel,
            bool viaWildcardOrRegex)
        {
            var resultCollection = new List<IUiElement>();
            
            try {
                
                IUiEltCollection results =
                    element.FindAll(
                        classic.TreeScope.Descendants,
                        conditions);
                
                resultCollection =
                    WindowSearcher.ReturnOnlyRightElements(
                        results,
                        data,
                        caseSensitiveParam,
                        viaWildcardOrRegex);
                
                if (null != results) {
                    // results.Dispose(); // taboo!
                    results = null;
                }
                // results = null;
                
            }
            catch { //(Exception eWildCardSearch) {
                
            }
            
            return resultCollection;
        }
        
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
            var resultCollection = new List<IUiElement>();
            
            name = name ?? string.Empty;
            automationId = automationId ?? string.Empty;
            className = className ?? string.Empty;
            
            if ((controlType != null && 
                controlType.Length > 0 && 
                ElementOfPossibleControlType(
                    controlType,
                    // 20140312
                    // element.Current.ControlType.ProgrammaticName)) ||
                    element.GetCurrent().ControlType.ProgrammaticName)) ||
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
                
                var wildcardName = 
                    new WildcardPattern(name,options);
                
                var wildcardAutomationId = 
                    new WildcardPattern(automationId,options);
                
                var wildcardClass = 
                    new WildcardPattern(className,options);
                
                // 20130125
                // there's a bug 20130125
                bool matched = false;
                
                if (FromCache && CurrentData.CacheRequest != null) {
                    // 20140312
                    // if (name.Length > 0 && wildcardName.IsMatch(element.Cached.Name)) {
                    // if (name.Length > 0 && wildcardName.IsMatch((element as ISupportsCached).Cached.Name)) {
                    if (name.Length > 0 && wildcardName.IsMatch(element.GetCached().Name)) {
                        matched = true;
                    } else if (automationId.Length > 0 &&
                        // 20140312
                                              // wildcardAutomationId.IsMatch(element.Cached.AutomationId)) {
                        // wildcardAutomationId.IsMatch((element as ISupportsCached).Cached.AutomationId)) {
                        wildcardAutomationId.IsMatch(element.GetCached().AutomationId)) {
                        matched = true;
                    } else
                        // 20140312
                        // matched |= className.Length > 0 && wildcardClass.IsMatch(element.Cached.ClassName);
                        // matched |= className.Length > 0 && wildcardClass.IsMatch((element as ISupportsCached).Cached.ClassName);
                        matched |= className.Length > 0 && wildcardClass.IsMatch(element.GetCached().ClassName);
                } else {
                    // 20140312
                    // if (name.Length > 0 && wildcardName.IsMatch(element.Current.Name)) {
                    if (name.Length > 0 && wildcardName.IsMatch(element.GetCurrent().Name)) {
                        matched = true;
                    } else if (automationId.Length > 0 &&
                        // 20140312
                                              // wildcardAutomationId.IsMatch(element.Current.AutomationId)) {
                        wildcardAutomationId.IsMatch(element.GetCurrent().AutomationId)) {
                        matched = true;
                    } else
                        // 20140312
                        // matched |= className.Length > 0 && wildcardClass.IsMatch(element.Current.ClassName);
                        matched |= className.Length > 0 && wildcardClass.IsMatch(element.GetCurrent().ClassName);
                }
                
                if (matched) {
                    
                    resultCollection.Add(element);
                    
                    if (onlyOneResult) {

                        throw (new Exception("wrong code here!"));

                    } else {
                        
                        return resultCollection;
                    }
                }
                
                wildcardName = wildcardAutomationId = wildcardClass = null;
                
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
            
            return result;
        }
        
        protected void GetAutomationElementsSiblings(bool nextSibling)
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            var walker = 
                new classic.TreeWalker(
                    classic.Condition.TrueCondition);
            
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
                sibling = nextSibling ? AutomationFactory.GetUiElement(walker.GetNextSibling(inputObject.GetSourceElement() as classic.AutomationElement)) : AutomationFactory.GetUiElement(walker.GetPreviousSibling(inputObject.GetSourceElement() as classic.AutomationElement));
                
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
        
        protected void GetAutomationElementsChildren(IUiElement inputObject, bool firstChild)
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            var walker = 
                new classic.TreeWalker(
                    classic.Condition.TrueCondition);
            
            IUiElement sibling =
                firstChild ?
                    AutomationFactory.GetUiElement(walker.GetFirstChild(inputObject.GetSourceElement() as classic.AutomationElement)) :
                        AutomationFactory.GetUiElement(walker.GetLastChild(inputObject.GetSourceElement() as classic.AutomationElement));
            
            WriteObject(this, sibling);
        }
        
        protected void GetAutomationElements(classic.TreeScope scope)
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {
                
                var searchResults = 
                    new List<IUiElement>();
                
                if (scope == classic.TreeScope.Children ||
                    scope == classic.TreeScope.Descendants) {
                    // WriteVerbose(this, "selected TreeScope." + scope.ToString());
                    
                    var controlSearch =
                        AutomationFactory.GetSearcherImpl<ControlSearcher>() as ControlSearcher;
                    
                    classic.Condition conditions =
                        ControlSearcher.GetWildcardSearchCondition(
                            controlSearch.ConvertCmdletToControlSearcherData(this));
                    
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
                        // WriteVerbose(this, "no conditions. Performing search with TrueCondition");
                        temporaryResults =
                            inputObject.FindAll(
                                scope,
                                classic.Condition.TrueCondition);
                        if (temporaryResults.Count > 0)
                        {
//                            WriteVerbose(this, 
//                                         "returned " + 
//                                         temporaryResults.Count.ToString() + 
//                                         " results");
                            searchResults.AddRange(temporaryResults.Cast<IUiElement>());
                        }
                    }
                    // WriteVerbose(this, "results found: " + searchResults.Count.ToString());
                    WriteObject(this, searchResults.ToArray());
                }
                
                if (null != searchResults) {
                    searchResults.Clear();
                    searchResults = null;
                }
                
                if (scope != classic.TreeScope.Parent && scope != classic.TreeScope.Ancestors) continue;
                
                IUiElement[] outResult = inputObject.GetParentOrAncestor(scope);
                WriteObject(this, outResult);
                
                if (null != outResult) {
                    outResult = null;
                }
                
            }
            
        }
    }
}
