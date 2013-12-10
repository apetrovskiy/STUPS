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
        public static IUiEltCollection ConvertCmdletInputToCollectionAdapter(this ICollection inputArray)
        {
            IUiEltCollection resultCollection =
                AutomationFactory.GetUiEltCollection(inputArray);
            return resultCollection;
        }
        
        public static IBasePattern[] ConvertAutomationPatternToBasePattern(this AutomationPattern[] patterns, IUiElement element)
        {
            var resultList =
                new List<IBasePattern>();
            foreach (AutomationPattern pattern in patterns) {
                // resultList.Add(AutomationFactory.GetMySuperPattern<IBasePattern>(element, pattern));
                switch (pattern.ProgrammaticName.Substring(12)) {
                    case "DockPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperDockPattern>(element, pattern));
                        break;
                    case "ExpandCollapsePattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperExpandCollapsePattern>(element, pattern));
                        break;
                    case "GridItemPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperGridItemPattern>(element, pattern));
                        break;
                    case "GridPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperGridPattern>(element, pattern));
                        break;
                    case "InvokePattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperInvokePattern>(element, pattern));
                        break;
                    case "RangeValuePattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperRangeValuePattern>(element, pattern));
                        break;
                    case "ScrollItemPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperScrollItemPattern>(element, pattern));
                        break;
                    case "ScrollPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperScrollPattern>(element, pattern));
                        break;
                    case "SelectionItemPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperSelectionItemPattern>(element, pattern));
                        break;
                    case "SelectionPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperSelectionPattern>(element, pattern));
                        break;
                    case "TableItemPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperTableItemPattern>(element, pattern));
                        break;
                    case "TablePattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperTablePattern>(element, pattern));
                        break;
                    case "TextPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperTextPattern>(element, pattern));
                        break;
                    case "TogglePattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperTogglePattern>(element, pattern));
                        break;
                    case "TransformPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperTransformPattern>(element, pattern));
                        break;
                    case "ValuePattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperValuePattern>(element, pattern));
                        break;
                    case "WindowPattern":
                        resultList.Add(AutomationFactory.GetMySuperPattern<IMySuperWindowPattern>(element, pattern));
                        break;
                    // default:
                    //     
                    // 	break;
                }
            }
            return resultList.ToArray();
        }
    }
}