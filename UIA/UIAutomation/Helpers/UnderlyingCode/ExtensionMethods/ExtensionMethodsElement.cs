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
        internal static IMySuperWrapper GetParent(this IMySuperWrapper element)
        {
            IMySuperWrapper result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetMySuperWrapper(walker.GetParent(element.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        
        #region get an ancestor with a handle
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        internal static IMySuperWrapper GetAncestorWithHandle(this IMySuperWrapper element)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            // 20131109
            //System.Windows.Automation.AutomationElement testparent;

            try {
                
                IMySuperWrapper testparent = AutomationFactory.GetMySuperWrapper(walker.GetParent(element.GetSourceElement()));
                while (testparent != null &&
                       testparent.Current.NativeWindowHandle == 0) {
                    testparent =
                        AutomationFactory.GetMySuperWrapper(walker.GetParent(testparent.GetSourceElement()));
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
        internal static IMySuperWrapper[] GetParentOrAncestor(this IMySuperWrapper element, TreeScope scope)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            // 20131109
            //System.Windows.Automation.AutomationElement testparent;
            // 20131109
            //System.Collections.Generic.List<AutomationElement> ancestors =
            //    new System.Collections.Generic.List<AutomationElement>();
            List<IMySuperWrapper> ancestors =
                new List<IMySuperWrapper>();
            
            try {
                
                // 20131109
                IMySuperWrapper testParent = AutomationFactory.GetMySuperWrapper(walker.GetParent(element.GetSourceElement()));
                    
                if (scope == TreeScope.Parent || scope == TreeScope.Ancestors) {
                    
                    if (testParent != MySuperWrapper.RootElement) {
                        ancestors.Add(testParent);
                    }
                    
                    if (testParent == MySuperWrapper.RootElement ||
                        scope == TreeScope.Parent) {
                        return ancestors.ToArray();
                    }
                }
                while (testParent != null &&
                       (int)testParent.Current.ProcessId > 0 &&
                       testParent != MySuperWrapper.RootElement) {
                    
                    testParent =
                        AutomationFactory.GetMySuperWrapper(walker.GetParent(testParent.GetSourceElement()));
                    if (testParent != null &&
                        (int)testParent.Current.ProcessId > 0 &&
                        testParent != MySuperWrapper.RootElement) {
                        
                        ancestors.Add(testParent);
                    }
                }
                return ancestors.ToArray();
            } catch {
                return ancestors.ToArray();
            }
        }
        #endregion get the parent or an ancestor
        
        // 20131204
        #region wrong experiment
//        internal static void Highlight(this IMySuperWrapper element)
//        {
//            try { if (_highlighter != null) { _highlighter.Dispose(); } } catch {}
//            try { if (_highlighterParent != null) { _highlighterParent.Dispose(); } } catch {}
//            //try { if (highlighterFirstChild != null) { highlighterFirstChild.Dispose(); } } catch {}
//            
//            if ((element as IMySuperWrapper) != null) {
//                
//                _highlighter =
//                    new Highlighter(
//                        element.Current.BoundingRectangle.Height,
//                        element.Current.BoundingRectangle.Width,
//                        element.Current.BoundingRectangle.X,
//                        element.Current.BoundingRectangle.Y,
//                        element.Current.NativeWindowHandle,
//                        Highlighters.Element,
//                        Preferences.HighlighterColor);
//            }
//            if (!Preferences.HighlightParent) return;
//            
//            IMySuperWrapper parent =
//                // 20131204
//                // GetParent(element);
//                element.GetParent();
//                
//            _highlighterParent =
//                new Highlighter(
//                    parent.Current.BoundingRectangle.Height,
//                    parent.Current.BoundingRectangle.Width,
//                    parent.Current.BoundingRectangle.X,
//                    parent.Current.BoundingRectangle.Y,
//                    parent.Current.NativeWindowHandle,
//                    Highlighters.Parent,
//                    Preferences.HighlighterColorParent);
//        }
//        
//        internal static void HighlightCheckedControl(this IMySuperWrapper element)
//        {
//            try { if (_highlighterCheckedControl != null) { _highlighterCheckedControl.Dispose(); } } catch {}
//            
//            if ((element as IMySuperWrapper) != null) {
//
//                _highlighterCheckedControl =
//                    new Highlighter(
//                        element.Current.BoundingRectangle.Height,
//                        element.Current.BoundingRectangle.Width,
//                        element.Current.BoundingRectangle.X,
//                        element.Current.BoundingRectangle.Y,
//                        element.Current.NativeWindowHandle,
//                        Highlighters.Element,
//                        Preferences.HighlighterColorCheckedControl);
//            }
//        }
        #endregion wrong experiment
        
        #region Collect ancestors
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="element"></param>
        // private static void collectAncestors(TranscriptCmdletBase cmdlet, IMySuperWrapper element)
        public static void CollectAncestors(this IMySuperWrapper element, TranscriptCmdletBase cmdlet, ref string errorMessage, ref bool errorOccured)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            // 20131109
            //System.Windows.Automation.AutomationElement testparent;

            try
            {
                // commented out 201206210
                //testparent =
                //    walker.GetParent(element);
                IMySuperWrapper testParent = element;

                while (testParent != null && (int)testParent.Current.ProcessId > 0) {
                    
                    testParent =
                        AutomationFactory.GetMySuperWrapper(walker.GetParent(testParent.GetSourceElement()));
                    
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
                            //if ((new MySuperWrapper(walker.GetParent(testParent.SourceElement))) == cmdlet.oddRootElement) {
                            // 20131118
                            // property to method
                            //if (ObjectsFactory.GetMySuperWrapper(walker.GetParent(testParent.SourceElement)) == cmdlet.oddRootElement) {
                            if (AutomationFactory.GetMySuperWrapper(walker.GetParent(testParent.GetSourceElement())) == cmdlet.OddRootElement) {
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
        // 20131109
        //private static string getElementControlTypeString(AutomationElement element)
        // private static string GetElementControlTypeString(this IMySuperWrapper element)
        internal static string GetElementControlTypeString(this IMySuperWrapper element)
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
        // 20131109
        //private static string getElementPropertyString(TranscriptCmdletBase cmdlet, AutomationElement element, string propertyName, ValuePattern pattern, ref bool hasName)
        // private static string GetElementPropertyString(
        internal static string GetElementPropertyString(
            this IMySuperWrapper element,
            PSCmdletBase cmdlet,
            /*
            TranscriptCmdletBase cmdlet,
            */
            // IMySuperWrapper element,
            string propertyName,
            // 20131124
            // ValuePattern -> IMySuperValuePattern
            //ValuePattern pattern,
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
        
//        internal static IMySuperWrapper GetFirstChild(this IMySuperWrapper element)
//        {
//            IMySuperWrapper result = null;
//            
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            
//            try {
//                // 20131204
//                // result = AutomationFactory.GetMySuperWrapper(walker.GetFirstChild(element.GetSourceElement()));
//                result = AutomationFactory.GetMySuperWrapper(walker.GetFirstChild(element.GetSourceElement()));
//            }
//            catch {}
//            
//            return result;
//        }

        internal static List<IMySuperWrapper> GetControlByNameViaWin32(
            // 20131204
            this IMySuperWrapper containerElement,
            GetControlCmdletBase cmdlet,
            // 20131204
            // IMySuperWrapper containerElement,
            // 20131129
            // string controlTitle)
            string controlTitle,
            string controlValue)
        {
            List<IMySuperWrapper> resultCollection = new List<IMySuperWrapper>();
            
            cmdlet.WriteVerbose(cmdlet, "checking the container control");

            if (null == containerElement) { return resultCollection; }
            cmdlet.WriteVerbose(cmdlet, "checking the Name parameter");
            
            controlTitle = string.IsNullOrEmpty(controlTitle) ? "*" : controlTitle;
            // 20131129
            controlValue = string.IsNullOrEmpty(controlValue) ? "*" : controlValue;
            
            try {
                IntPtr containerHandle =
                    new IntPtr(containerElement.Current.NativeWindowHandle);
                if (containerHandle == IntPtr.Zero){
                    cmdlet.WriteVerbose(cmdlet, "The container control has no handle");

                    return resultCollection;
                }
                
                List<IntPtr> handlesCollection =
                    // 20131204
                    // GetControlByNameViaWin32Recursively(cmdlet, containerHandle, controlTitle, 1);
                    UiaHelper.GetControlByNameViaWin32Recursively(cmdlet, containerHandle, controlTitle, 1);
                
                const WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                
                WildcardPattern wildcardName =
                    new WildcardPattern(controlTitle, options);
                // 20131129
                WildcardPattern wildcardValue =
                    new WildcardPattern(controlValue, options);
                
                if (null == handlesCollection || 0 == handlesCollection.Count) return resultCollection;
                cmdlet.WriteVerbose(cmdlet, "handles.Count = " + handlesCollection.Count.ToString());
                
                foreach (IntPtr controlHandle in handlesCollection) {
                    try {
                        cmdlet.WriteVerbose(cmdlet, "checking a handle");
                        if (IntPtr.Zero == controlHandle) continue;
                        cmdlet.WriteVerbose(cmdlet, "the handle is not null");
                        
                        IMySuperWrapper tempElement =
                            MySuperWrapper.FromHandle(controlHandle);
                        cmdlet.WriteVerbose(cmdlet, "adding the handle to the collection");
                                
                        cmdlet.WriteVerbose(cmdlet, controlTitle);
                        cmdlet.WriteVerbose(cmdlet, tempElement.Current.Name);
                        
                        // 20131204
                        // if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.Name)) continue;
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.Name)) continue;
                        // 20131129
                        // 20131204
                        // if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.AutomationId)) continue;
                        // if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.ClassName)) continue;
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.AutomationId)) continue;
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.ClassName)) continue;
                        try {
                            string elementValue =
                                (tempElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
                            // 20131129
                            // 20131204
                            // if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, elementValue)) continue;
                            // if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardValue, elementValue)) continue;
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
        
        // 20131204
        // private static bool IsMatchWildcardPattern(
        internal static bool IsMatchWildcardPattern(
            // 20131204
            this IMySuperWrapper elementInput,
            PSCmdletBase cmdlet,
            IList resultCollection,
            // 20131204
            // IMySuperWrapper elementInput,
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
            // 20131129
            // result = true;
            
            return result;
        }
    }
}
