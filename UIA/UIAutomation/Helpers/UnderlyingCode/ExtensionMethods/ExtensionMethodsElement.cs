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
        public static void CollectAncestors(this IMySuperWrapper element, TranscriptCmdletBase cmdlet)
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
                            @"Get-UIA" + parentControlType;
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
                _errorMessageInTheInnerCycle =
                    eErrorInTheInnerCycle.Message;
                _errorInTheInnerCycle = true;
            }
        }
        #endregion Collect ancestors
    }
}
