/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/5/2014
 * Time: 11:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
//    using System.Windows.Automation.Text;
    using System.Collections;
//    using System.Collections.Generic;
    using System.Linq;
//    using System.Management.Automation;
//    using PSTestLib;
    
    /// <summary>
    /// Description of ExtensionMethodsElementCommon.
    /// </summary>
    public static class ExtensionMethodsElementCommon
    {
        #region Navigation
        public static IUiElement PerformNavigateToParent(this IUiElement element)
		{
			IUiElement result = null;

			var walker = new classic.TreeWalker(classic.Condition.TrueCondition);
            /*
            TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);
            */

			try {
				result = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement() as classic.AutomationElement));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToFirstChild(this IUiElement element)
		{
			IUiElement result = null;

			var walker = new classic.TreeWalker(classic.Condition.TrueCondition);
            /*
            TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);
            */

			try {
				result = AutomationFactory.GetUiElement(walker.GetFirstChild(element.GetSourceElement() as classic.AutomationElement));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToLastChild(this IUiElement element)
		{
			IUiElement result = null;

			classic.TreeWalker walker = new classic.TreeWalker(classic.Condition.TrueCondition);

			try {
				result = AutomationFactory.GetUiElement(walker.GetLastChild(element.GetSourceElement() as classic.AutomationElement));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToNextSibling(this IUiElement element)
		{
			IUiElement result = null;

			var walker = new classic.TreeWalker(classic.Condition.TrueCondition);
            
            /*
            TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);
            */

			try {
				result = AutomationFactory.GetUiElement(walker.GetNextSibling(element.GetSourceElement() as classic.AutomationElement));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToPreviousSibling(this IUiElement element)
		{
			IUiElement result = null;

			var walker = new classic.TreeWalker(classic.Condition.TrueCondition);
            /*
            TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);
            */
            
			try {
                
				result = AutomationFactory.GetUiElement(walker.GetPreviousSibling(element.GetSourceElement() as classic.AutomationElement));
			} catch {
			}

			return result;
		}
        #endregion Navigation
        #region Highlighter
        public static IUiElement PerformHighlight(this IUiElement element)
		{
			UiaHelper.Highlight(element);
			return element;
		}
        #endregion Highlighter
        #region Export
        #endregion Export
        #region Conversion
        public static Hashtable PerformConvertToSearchCriteria(this IUiElement element)
        {
            try {
                // return UiaHelper.con
            } catch (Exception) {
                
                // throw;
            }
            
            
            return new Hashtable();
        }
        #endregion Conversion
        #region Refresh
        public static IUiElement PerformRefresh(this IUiElement element)
        {
            try {
                return AutomationFactory.GetUiElement(element.GetSourceElement());
            } catch (Exception) {
                return null;
                // throw;
            }
        }
        #endregion Refresh
//        #region Cached
//        public static IUiElementInformation GetCached(this IUiElement element)
//        {
//            try {
//                return AutomationFactory.GetUiElementInformation(((classic.AutomationElement)(element as UiElement).GetSourceElement()).Cached);
//            } catch (Exception) {
//                return null;
//                // throw;
//            }
//        }
//        
//        public static IUiElement GetCachedParent(this IUiElement element)
//        {
//            try {
//                // return (element as ISupportsCached).CachedParent;
//                return AutomationFactory.GetUiElement(((classic.AutomationElement)(element as UiElement).GetSourceElement()).CachedParent);
//            } catch (Exception) {
//                return null;
//                // throw;
//            }
//        }
//        
//        public static IUiEltCollection GetCachedChildren(this IUiElement element)
//        {
//            try {
//                // return (element as ISupportsCached).CachedChildren;
//                return AutomationFactory.GetUiEltCollection(((classic.AutomationElement)(element as UiElement).GetSourceElement()).CachedChildren);
//            } catch (Exception) {
//                return null;
//                // throw;
//            }
//        }
//        #endregion Cached
//        #region Current
//        public static IUiElementInformation GetCurrent(this IUiElement element)
//        {
//            try {
//                return AutomationFactory.GetUiElementInformation(((classic.AutomationElement)(element as UiElement).GetSourceElement()).Current);
//            } catch (Exception) {
//                return null;
//                // throw;
//            }
//        }
//        #endregion Current
    }
}
