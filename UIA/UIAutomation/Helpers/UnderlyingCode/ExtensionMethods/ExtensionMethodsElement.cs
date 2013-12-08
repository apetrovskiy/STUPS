/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/4/2013
 * Time: 10:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PSTestLib;
    
    /// <summary>
    /// Description of ExtensionMethodsElement.
    /// </summary>
    public static class ExtensionMethodsElement
    {
        public static IUiElement GetParent(this IUiElement element)
        {
            IUiElement result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        
        #region get an ancestor with a handle
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        internal static IUiElement GetAncestorWithHandle(this IUiElement element)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                
                IUiElement testparent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
                while (testparent != null &&
                       testparent.Current.NativeWindowHandle == 0) {
                    testparent =
                        AutomationFactory.GetUiElement(walker.GetParent(testparent.GetSourceElement()));
                    if (testparent != null &&
                        (int)testparent.Current.ProcessId > 0 &&
                        testparent.Current.NativeWindowHandle != 0) {
                        
                        return testparent;
                    }
                }
                return testparent.Current.NativeWindowHandle != 0 ? testparent : null;
                
            } catch {
                return null;
            }
        }
        #endregion get an ancestor with a handle
        
        #region get the parent or an ancestor
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        internal static IUiElement[] GetParentOrAncestor(this IUiElement element, TreeScope scope)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            List<IUiElement> ancestors =
                new List<IUiElement>();
            
            try {
                
                IUiElement testParent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
                    
                if (scope == TreeScope.Parent || scope == TreeScope.Ancestors) {
                    
                    if (testParent != UiElement.RootElement) {
                        ancestors.Add(testParent);
                    }
                    
                    if (testParent == UiElement.RootElement ||
                        scope == TreeScope.Parent) {
                        return ancestors.ToArray();
                    }
                }
                while (testParent != null &&
                       (int)testParent.Current.ProcessId > 0 &&
                       testParent != UiElement.RootElement) {
                    
                    testParent =
                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement()));
                    if (testParent != null &&
                        (int)testParent.Current.ProcessId > 0 &&
                        testParent != UiElement.RootElement) {
                        
                        ancestors.Add(testParent);
                    }
                }
                return ancestors.ToArray();
            } catch {
                return ancestors.ToArray();
            }
        }
        #endregion get the parent or an ancestor
        
        #region Collect ancestors
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="element"></param>
        internal static void CollectAncestors(this IUiElement element, TranscriptCmdletBase cmdlet, ref string errorMessage, ref bool errorOccured)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try
            {
                // commented out 201206210
                //testparent =
                //    walker.GetParent(element);
                IUiElement testParent = element;

                while (testParent != null && (int)testParent.Current.ProcessId > 0) {
                    
                    testParent =
                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement()));
                    
                    if (testParent == null || (int) testParent.Current.ProcessId <= 0) continue;
                    if (testParent == cmdlet.OddRootElement)
                    { testParent = null; }
                    else{
                        string parentControlType =
                            // getControlTypeNameOfAutomationElement(testparent, element);
                            // testparent.Current.ControlType.ProgrammaticName.Substring(
                            // element.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                            //  // experimental
                            testParent.Current.ControlType.ProgrammaticName.Substring(
                                testParent.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                        //  // if (parentControlType.Length == 0) {
                        // break;
                        //}
                            
                        // in case this element is an upper-level Pane
                        // residing directrly under the RootElement
                        // change type to window
                        // i.e. Get-UiaPane - >  Get-UiaWindow
                        // since Get-UiaPane is unable to get something more than
                        // a window's child pane control
                        if (parentControlType == "Pane" || parentControlType == "Menu") {
                            
                            // 20131109
                            //if (walker.GetParent(testParent) == cmdlet.rootElement) {
                            // 20131112
                            //if ((new UiElement(walker.GetParent(testParent.SourceElement))) == cmdlet.oddRootElement) {
                            // 20131118
                            // property to method
                            //if (ObjectsFactory.GetUiElement(walker.GetParent(testParent.SourceElement)) == cmdlet.oddRootElement) {
                            if (AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement())) == cmdlet.OddRootElement) {
                                parentControlType = "Window";
                            }
                        }
                            
                        string parentVerbosity =
                            @"Get-Uia" + parentControlType;
                        try {
                            if (testParent.Current.AutomationId.Length > 0) {
                                parentVerbosity += (" -AutomationId '" + testParent.Current.AutomationId + "'");
                            }
                        }
                        catch {
                        }
                        if (!cmdlet.NoClassInformation) {
                            try {
                                if (testParent.Current.ClassName.Length > 0) {
                                    parentVerbosity += (" -Class '" + testParent.Current.ClassName + "'");
                                }
                            }
                            catch {
                            }
                        }
                        try {
                            if (testParent.Current.Name.Length > 0) {
                                parentVerbosity += (" -Name '" + testParent.Current.Name + "'");
                            }
                        }
                        catch {
                        }

                        if (cmdlet.LastRecordedItem[cmdlet.LastRecordedItem.Count - 1].ToString() == parentVerbosity)
                            continue;
                        cmdlet.LastRecordedItem.Add(parentVerbosity);
                        cmdlet.WriteVerbose(parentVerbosity);
                    }
                }
            }
            catch (Exception eErrorInTheInnerCycle) {
                cmdlet.WriteDebug(cmdlet, eErrorInTheInnerCycle.Message);
                // _errorMessageInTheInnerCycle =
                errorMessage =
                    eErrorInTheInnerCycle.Message;
                // _errorInTheInnerCycle = true;
                errorOccured = true;
            }
        }
        #endregion Collect ancestors
        
        /// <summary>
        /// Retrievs an element's ControlType property as a string.
        /// </summary>
        /// <param name="element">AutomationElement</param>
        /// <returns>string</returns>
        internal static string GetElementControlTypeString(this IUiElement element)
        {
            string elementControlType = String.Empty;
            try {
                elementControlType = element.Current.ControlType.ProgrammaticName;
            } catch {
                elementControlType = element.Cached.ControlType.ProgrammaticName;
            }
            if (string.Empty != elementControlType && 0 < elementControlType.Length) {
                elementControlType = elementControlType.Substring(elementControlType.IndexOf('.') + 1);
            }
            //string elementVerbosity = String.Empty;
            //if (string.Empty == elementControlType || 0 == elementControlType.Length) {
            //    return result;
            //}
            return elementControlType;
        }
        
        /// <summary>
        /// Retrieves such element's properties as AutomationId, Name, Class(Name) and Value
        /// </summary>
        /// <param name="cmdlet">cmdlet to report</param>
        /// <param name="element">The element properties taken from</param>
        /// <param name="propertyName">The name of property</param>
        /// <param name="pattern">an object of the ValuePattern type</param>
        /// <param name="hasName">an object has Name</param>
        /// <returns></returns>
        internal static string GetElementPropertyString(
            this IUiElement element,
            PSCmdletBase cmdlet,
            string propertyName,
            IMySuperValuePattern pattern,
            ref bool hasName)
        {
            cmdlet.WriteVerbose(cmdlet, "getting " + propertyName);
            string tempString = string.Empty;
            try {
                
                switch (propertyName) {
                    case "Name":
                        if (0 < element.Current.Name.Length) {
                            tempString = element.Current.Name;
                            hasName = true;
                        }
                        break;
                    case "AutomationId":
                        if (0 < element.Current.AutomationId.Length) {
                            tempString = element.Current.AutomationId;
                        }
                        break;
                    case "Class":
                        if (0 < element.Current.ClassName.Length) {
                            tempString = element.Current.ClassName;
                        }
                        break;
                    case "Value":
                        if (!string.IsNullOrEmpty(pattern.Current.Value)) {
                            tempString = pattern.Current.Value;
                            hasName = true;
                        }
                        break;
                    case "Win32":
                        if (0 < element.Current.NativeWindowHandle) {
                            tempString = ".";
                        }
                        break;
                    default:
                        
                    	break;
                }
            } catch {
                switch (propertyName) {
                    case "Name":
                        if (0 < element.Cached.Name.Length) {
                            tempString = element.Cached.Name;
                            hasName = true;
                        }
                        break;
                    case "AutomationId":
                        if (0 < element.Cached.AutomationId.Length) {
                            tempString = element.Cached.AutomationId;
                        }
                        break;
                    case "Class":
                        if (0 < element.Cached.ClassName.Length) {
                            tempString = element.Cached.ClassName;
                        }
                        break;
                    case "Value":
                        if (!string.IsNullOrEmpty(pattern.Cached.Value)) {
                            tempString = pattern.Cached.Value;
                            hasName = true;
                        }
                        break;
                    case "Win32":
                        if (0 < element.Cached.NativeWindowHandle) {
                            tempString = ".";
                        }
                        break;
                    default:
                        
                    	break;
                }
            }
            if (string.IsNullOrEmpty(tempString)) {
                return string.Empty;
            } else {
                if ("Win32" == propertyName) {
                    tempString =
                        " -" + propertyName;
                } else {
                    tempString =
                        " -" + propertyName + " '" + tempString + "'";
                }
                return tempString;
            }
        }
        
        internal static List<IUiElement> GetControlByNameViaWin32(
            this IUiElement containerElement,
            GetControlCmdletBase cmdlet,
            string controlTitle,
            string controlValue)
        {
            List<IUiElement> resultCollection = new List<IUiElement>();
            
            cmdlet.WriteVerbose(cmdlet, "checking the container control");

            if (null == containerElement) { return resultCollection; }
            cmdlet.WriteVerbose(cmdlet, "checking the Name parameter");
            
            controlTitle = string.IsNullOrEmpty(controlTitle) ? "*" : controlTitle;
            controlValue = string.IsNullOrEmpty(controlValue) ? "*" : controlValue;
            
            try {
                IntPtr containerHandle =
                    new IntPtr(containerElement.Current.NativeWindowHandle);
                if (containerHandle == IntPtr.Zero){
                    cmdlet.WriteVerbose(cmdlet, "The container control has no handle");

                    return resultCollection;
                }
                
                List<IntPtr> handlesCollection =
                    UiaHelper.GetControlByNameViaWin32Recursively(cmdlet, containerHandle, controlTitle, 1);
                
                const WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                
                WildcardPattern wildcardName =
                    new WildcardPattern(controlTitle, options);
                WildcardPattern wildcardValue =
                    new WildcardPattern(controlValue, options);
                
                if (null == handlesCollection || 0 == handlesCollection.Count) return resultCollection;
                cmdlet.WriteVerbose(cmdlet, "handles.Count = " + handlesCollection.Count.ToString());
                
                foreach (IntPtr controlHandle in handlesCollection) {
                    try {
                        cmdlet.WriteVerbose(cmdlet, "checking a handle");
                        if (IntPtr.Zero == controlHandle) continue;
                        cmdlet.WriteVerbose(cmdlet, "the handle is not null");
                        
                        IUiElement tempElement =
                            UiElement.FromHandle(controlHandle);
                        cmdlet.WriteVerbose(cmdlet, "adding the handle to the collection");
                                
                        cmdlet.WriteVerbose(cmdlet, controlTitle);
                        cmdlet.WriteVerbose(cmdlet, tempElement.Current.Name);
                        
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.Name)) continue;
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.AutomationId)) continue;
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.ClassName)) continue;
                        try {
                            string elementValue =
                                // 20131208
                                // (tempElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
                                // (tempElement.GetCurrentPattern<IMySuperValuePattern, ValuePattern>(ValuePattern.Pattern) as ValuePattern).Current.Value;
                                tempElement.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern).Current.Value;
                            if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, elementValue)) continue;
                            if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardValue, elementValue)) continue;
                        }
                        catch { //(Exception eValuePattern) {
                        }
                    }
                    catch (Exception eGetAutomationElementFromHandle) {
                        cmdlet.WriteVerbose(cmdlet, eGetAutomationElementFromHandle.Message);
                    }
                }
                return resultCollection;
            } catch (Exception eWin32Control) {
                cmdlet.WriteVerbose(cmdlet, "UiaHelper.GetControlByName() failed");
                cmdlet.WriteVerbose(cmdlet, eWin32Control.Message);
                return resultCollection;
            }
        }
        
        internal static bool IsMatchWildcardPattern(
            this IUiElement elementInput,
            PSCmdletBase cmdlet,
            IList resultCollection,
            WildcardPattern wcPattern,
            string dataToCheck)
        {
            bool result = false;
            
            if (string.IsNullOrEmpty(dataToCheck)) {
                return result;
            }
            
            if (!wcPattern.IsMatch(dataToCheck)) return result;
            
            result = true;
            cmdlet.WriteVerbose(cmdlet, "name '" + dataToCheck + "' matches!");
            resultCollection.Add(elementInput);
            
            return result;
        }
        
        #region Patterns
//        public static N GetCurrentPattern<N, O>(this IUiElement element) where N : IBasePattern //where O : AutomationPattern
//        {
//            N resultPattern = AutomationFactory.GetMySuperPattern<N, O>(element, null);
//Console.WriteLine("extension method 0001");
//if (null == resultPattern) {
//    Console.WriteLine("null == resultPattern");
//}
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern((O as AutomationPattern), out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<N, O>(element, (pattern as AutomationPattern));
//            }
//Console.WriteLine("extension method 0003");
//            
//            return resultPattern;
//        }
        
//        public static IMySuperExpandCollapsePattern GetExpandCollapsePattern(this IUiElement element)
//        {
////            IMySuperExpandCollapsePattern resultPattern = AutomationFactory.GetMySuperExpandCollapsePattern(element, null);
////            object pattern = null;
////            
////            if (element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out pattern)) {
////                resultPattern =
////                    AutomationFactory.GetMySuperExpandCollapsePattern(element,  (pattern as ExpandCollapsePattern));
////            }
////            
//            IMySuperExpandCollapsePattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperExpandCollapsePattern, ExpandCollapsePattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperExpandCollapsePattern, ExpandCollapsePattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperInvokePattern GetInvokePattern(this IUiElement element)
//        {
////            IMySuperInvokePattern resultPattern = AutomationFactory.GetMySuperInvokePattern(element, null);
////            object pattern = null;
////            
////            if (element.TryGetCurrentPattern(InvokePattern.Pattern, out pattern)) {
////                resultPattern =
////                    AutomationFactory.GetMySuperInvokePattern(element,  (pattern as InvokePattern));
////            }
////            
//            IMySuperInvokePattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperInvokePattern, InvokePattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(InvokePattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperInvokePattern, InvokePattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperScrollItemPattern GetScrollItemPattern(this IUiElement element)
//        {
////            IMySuperScrollItemPattern resultPattern =
////                AutomationFactory.GetMySuperScrollItemPattern(element, null);
////            object pattern = null;
////            
////            if (element.TryGetCurrentPattern(ScrollItemPattern.Pattern, out pattern)) {
////                resultPattern =
////                    AutomationFactory.GetMySuperScrollItemPattern(element, (pattern as ScrollItemPattern));
////            }
////            
//            IMySuperScrollItemPattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperScrollItemPattern, ScrollItemPattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(ScrollItemPattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperScrollItemPattern, ScrollItemPattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperScrollPattern GetScrollPattern(this IUiElement element)
//        {
////            IMySuperScrollPattern resultPattern =
////                AutomationFactory.GetMySuperScrollPattern(element, null);
////            object pattern = null;
////            
////            if (element.TryGetCurrentPattern(ScrollPattern.Pattern, out pattern)) {
////                resultPattern =
////                    AutomationFactory.GetMySuperScrollPattern(element, (pattern as ScrollPattern));
////            }
////            
//            IMySuperScrollPattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperScrollPattern, ScrollPattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(ScrollPattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperScrollPattern, ScrollPattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperSelectionItemPattern GetSelectionItemPattern(this IUiElement element)
//        {
////            IMySuperSelectionItemPattern resultPattern =
////                AutomationFactory.GetMySuperSelectionItemPattern(element, null);
////            object pattern = null;
////            
////            if (element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out pattern)) {
////                resultPattern =
////                    AutomationFactory.GetMySuperSelectionItemPattern(element, (pattern as SelectionItemPattern));
////            }
////            
//            IMySuperSelectionItemPattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperSelectionItemPattern, SelectionItemPattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperSelectionItemPattern, SelectionItemPattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperSelectionPattern GetSelectionPattern(this IUiElement element)
//        {
////            IMySuperSelectionPattern resultPattern =
////                AutomationFactory.GetMySuperSelectionPattern(element, null);
////            object pattern = null;
////            
////            if (element.TryGetCurrentPattern(SelectionPattern.Pattern, out pattern)) {
////                resultPattern =
////                    AutomationFactory.GetMySuperSelectionPattern(element, (pattern as SelectionPattern));
////            }
////            
//            IMySuperSelectionPattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperSelectionPattern, SelectionPattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(SelectionPattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperSelectionPattern, SelectionPattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperTogglePattern GetTogglePattern(this IUiElement element)
//        {
////            IMySuperTogglePattern resultPattern = AutomationFactory.GetMySuperTogglePattern(element, null);
////            object pattern = null;
////            
////            if (element.TryGetCurrentPattern(TogglePattern.Pattern, out pattern)) {
////                resultPattern =
////                    AutomationFactory.GetMySuperTogglePattern(element,  (pattern as TogglePattern));
////            }
////            
//            IMySuperTogglePattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperTogglePattern, TogglePattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(TogglePattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperTogglePattern, TogglePattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperValuePattern GetValuePattern(this IUiElement element)
//        {
//            // 20131208
//            // IMySuperValuePattern resultPattern = AutomationFactory.GetMySuperValuePattern(element, null);
////Console.WriteLine("extension method 00001");
//            IMySuperValuePattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperValuePattern, ValuePattern>(element, null);
////Console.WriteLine("extension method 00002");
//            object pattern = null;
////Console.WriteLine("extension method 00003");
//            
//            
//            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out pattern)) {
////Console.WriteLine("extension method 00004");
//                resultPattern =
//                    // 20131208
//                    // AutomationFactory.GetMySuperValuePattern(element, (pattern as ValuePattern));
//                    AutomationFactory.GetMySuperPattern<IMySuperValuePattern, ValuePattern>(element, (pattern as AutomationPattern));
////Console.WriteLine("extension method 00005");
//            }
//            
////Console.WriteLine("extension method 00006");
//            
//            return resultPattern;
//        }
//        
//        public static IMySuperWindowPattern GetWindowPattern(this IUiElement element)
//        {
//            IMySuperWindowPattern resultPattern = AutomationFactory.GetMySuperPattern<IMySuperWindowPattern, WindowPattern>(element, null);
//            object pattern = null;
//            
//            if (element.TryGetCurrentPattern(WindowPattern.Pattern, out pattern)) {
//                resultPattern =
//                    AutomationFactory.GetMySuperPattern<IMySuperWindowPattern, WindowPattern>(element, (pattern as AutomationPattern));
//            }
//            
//            return resultPattern;
//        }
//        
////        public T GetValuePattern<T>(this IUiElement element)
////        {
////            T result = null;
////            
////            if (element.TryGetCurrentPattern(ValuePattern.Pattern)) {
////                result =
////                    element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
////            }
////            
////            return result;
////        }
        #endregion Patterns
    }
}
