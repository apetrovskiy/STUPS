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
    }
}
