/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/7/2013
 * Time: 2:22 AM
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
    
    /// <summary>
    /// Description of ExtensionsMethods.
    /// </summary>
    public static class ExtensionsMethods
    {
//        public static IEnumerable GetElementsByWildcard(this MySuperCollection collection, string name, string automationId, string className, string txtValue, bool caseSensitive)
//        {
//            WildcardOptions options;
//            if (caseSensitive) {
//                options =
//                    WildcardOptions.Compiled;
//            } else {
//                options =
//                    WildcardOptions.IgnoreCase |
//                    WildcardOptions.Compiled;
//            }
//            
//            List<IMySuperWrapper> list = collection.Cast<IMySuperWrapper>().ToList();
//            
//            WildcardPattern wildcardName = 
//                new WildcardPattern((string.IsNullOrEmpty(name) ? "*" : name), options);
//            WildcardPattern wildcardAutomationId = 
//                new WildcardPattern((string.IsNullOrEmpty(automationId) ? "*" : automationId), options);
//            WildcardPattern wildcardClassName = 
//                new WildcardPattern((string.IsNullOrEmpty(className) ? "*" : className), options);
//            WildcardPattern wildcardValue = 
//                new WildcardPattern((string.IsNullOrEmpty(txtValue) ? "*" : txtValue), options);
//            
//            var queryByBigFour = from collectionItem
//                in list
//                where wildcardName.IsMatch(collectionItem.Current.Name) &&
//                      wildcardAutomationId.IsMatch(collectionItem.Current.AutomationId) &&
//                      wildcardClassName.IsMatch(collectionItem.Current.ClassName) &&
//                      (collectionItem.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
//                      wildcardValue.IsMatch((collectionItem.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value) :
//                      // check whether the -Value parameter has or hasn't value
//                      ("*" == txtValue ? true : false))
//                select collectionItem;
//            
//            // disposal
//            list = null;
//            
//            return queryByBigFour;
//        }
        
//        public static IEnumerable GetElementsByWildcard(this MySuperCollection collection, string name, string automationId, string className, string txtValue)
//        {
//            return GetElementsByWildcard(collection, name, automationId, className, txtValue, false);
//        }
        
        public static IMySuperCollection ConvertCmdletInputToCollectionAdapter(this ICollection inputArray)
        {
            IMySuperCollection resultCollection =
                AutomationFactory.GetMySuperCollection(inputArray);
            return resultCollection;
        }
        
//        internal static IMySuperWrapper GetParent(this IMySuperWrapper element)
//        {
//            IMySuperWrapper result = null;
//            
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            
//            try {
//                result = AutomationFactory.GetMySuperWrapper(walker.GetParent(element.GetSourceElement()));
//            }
//            catch {}
//            
//            return result;
//        }
//        
//        #region get an ancestor with a handle
//        /// <summary>
//        ///  /// </summary>
//        /// <param name="element"></param>
//        /// <returns></returns>
//        internal static IMySuperWrapper GetAncestorWithHandle(this IMySuperWrapper element)
//        {
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            
//            // 20131109
//            //System.Windows.Automation.AutomationElement testparent;
//
//            try {
//                
//                IMySuperWrapper testparent = AutomationFactory.GetMySuperWrapper(walker.GetParent(element.GetSourceElement()));
//                while (testparent != null &&
//                       testparent.Current.NativeWindowHandle == 0) {
//                    testparent =
//                        AutomationFactory.GetMySuperWrapper(walker.GetParent(testparent.GetSourceElement()));
//                    if (testparent != null &&
//                        (int)testparent.Current.ProcessId > 0 &&
//                        testparent.Current.NativeWindowHandle != 0) {
//                        
//                        return testparent;
//                    }
//                }
//                return testparent.Current.NativeWindowHandle != 0 ? testparent : null;
//                
//            } catch {
//                return null;
//            }
//        }
//        #endregion get an ancestor with a handle
//        
//        #region get the parent or an ancestor
//        /// <summary>
//        ///  /// </summary>
//        /// <param name="element"></param>
//        /// <param name="scope"></param>
//        /// <returns></returns>
//        internal static IMySuperWrapper[] GetParentOrAncestor(this IMySuperWrapper element, TreeScope scope)
//        {
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            // 20131109
//            //System.Windows.Automation.AutomationElement testparent;
//            // 20131109
//            //System.Collections.Generic.List<AutomationElement> ancestors =
//            //    new System.Collections.Generic.List<AutomationElement>();
//            List<IMySuperWrapper> ancestors =
//                new List<IMySuperWrapper>();
//            
//            try {
//                
//                // 20131109
//                IMySuperWrapper testParent = AutomationFactory.GetMySuperWrapper(walker.GetParent(element.GetSourceElement()));
//                    
//                if (scope == TreeScope.Parent || scope == TreeScope.Ancestors) {
//                    
//                    if (testParent != MySuperWrapper.RootElement) {
//                        ancestors.Add(testParent);
//                    }
//                    
//                    if (testParent == MySuperWrapper.RootElement ||
//                        scope == TreeScope.Parent) {
//                        return ancestors.ToArray();
//                    }
//                }
//                while (testParent != null &&
//                       (int)testParent.Current.ProcessId > 0 &&
//                       testParent != MySuperWrapper.RootElement) {
//                    
//                    testParent =
//                        AutomationFactory.GetMySuperWrapper(walker.GetParent(testParent.GetSourceElement()));
//                    if (testParent != null &&
//                        (int)testParent.Current.ProcessId > 0 &&
//                        testParent != MySuperWrapper.RootElement) {
//                        
//                        ancestors.Add(testParent);
//                    }
//                }
//                return ancestors.ToArray();
//            } catch {
//                return ancestors.ToArray();
//            }
//        }
//        #endregion get the parent or an ancestor
        
//        /// <summary>
//        ///  /// </summary>
//        /// <returns></returns>
//        internal static AutomationPattern[] GetElementPatternsFromPoint(this IMySuperWrapper element)
//        {
//            AutomationPattern[] result = null;
//            GetAutomationElementFromPoint();
//            // 20131204
//            // result = _element.GetSupportedPatterns();
//            result = element.GetSupportedPatterns();
//            return result;
//        }
//        
//        // temporary!!!
//        // internal static System.Windows.Automation.AutomationElement GetAutomationElementFromPoint()
//        /// <summary>
//        ///  /// </summary>
//        /// <returns></returns>
//        public static IMySuperWrapper GetAutomationElementFromPoint(this IMySuperWrapper element)
//        {
//            // 20131109
//            //System.Windows.Automation.AutomationElement result =
//            //    null;
//            IMySuperWrapper result = null;
//            
//            try {
//                _element =
//                    // 20131109
//                    //AutomationElement.FromPoint(new System.Windows.Point(
//                    //    Cursor.Position.X,
//                    //    Cursor.Position.Y));
//                    MySuperWrapper.FromPoint(
//                        new System.Windows.Point(
//                            Cursor.Position.X,
//                            Cursor.Position.Y));
//                result = _element;
//            }
//            catch { }
//            return result;
//        }
    }
}