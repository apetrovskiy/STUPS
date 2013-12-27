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
                // 20131210
                // switch (pattern.ProgrammaticName.Substring(12)) {
                try {
                    switch (pattern.ProgrammaticName.Replace("Identifiers.Pattern", string.Empty)) {
                        case "DockPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IDockPattern>(element, pattern));
                            break;
                        case "ExpandCollapsePattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IExpandCollapsePattern>(element, pattern));
                            break;
                        case "GridItemPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IGridItemPattern>(element, pattern));
                            break;
                        case "GridPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IGridPattern>(element, pattern));
                            break;
                        case "InvokePattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IInvokePattern>(element, pattern));
                            break;
                        case "RangeValuePattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IRangeValuePattern>(element, pattern));
                            break;
                        case "ScrollItemPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IScrollItemPattern>(element, pattern));
                            break;
                        case "ScrollPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IScrollPattern>(element, pattern));
                            break;
                        case "SelectionItemPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<ISelectionItemPattern>(element, pattern));
                            break;
                        case "SelectionPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<ISelectionPattern>(element, pattern));
                            break;
                        case "TableItemPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<ITableItemPattern>(element, pattern));
                            break;
                        case "TablePattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<ITablePattern>(element, pattern));
                            break;
                        case "TextPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<ITextPattern>(element, pattern));
                            break;
                        case "TogglePattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<ITogglePattern>(element, pattern));
                            break;
                        case "TransformPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<ITransformPattern>(element, pattern));
                            break;
                        case "ValuePattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IValuePattern>(element, pattern));
                            break;
                        case "WindowPattern":
                            resultList.Add(AutomationFactory.GetMySuperPattern<IWindowPattern>(element, pattern));
                            break;
                        // default:
                        //     
                        // 	break;
                    }
                }
                catch {
                    
                }
            }
            
            // 20131227
            return resultList.ToArray();
            // IBasePattern[] resultArray = (0 < resultList.Count() ? resultList.ToArray() : new object[] {} as IBasePattern[]);
            // return resultArray;
        }
    }
}