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
                
                // resultList.Add(AutomationFactory.GetPatternAdapter<IBasePattern>(element, pattern));
                // 20131210
                // switch (pattern.ProgrammaticName.Substring(12)) {
                try {
                    switch (pattern.ProgrammaticName.Replace("Identifiers.Pattern", string.Empty)) {
                        case "DockPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IDockPattern>(element, pattern));
                            break;
                        case "ExpandCollapsePattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IExpandCollapsePattern>(element, pattern));
                            break;
                        case "GridItemPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IGridItemPattern>(element, pattern));
                            break;
                        case "GridPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IGridPattern>(element, pattern));
                            break;
                        case "InvokePattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IInvokePattern>(element, pattern));
                            break;
                        case "RangeValuePattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IRangeValuePattern>(element, pattern));
                            break;
                        case "ScrollItemPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IScrollItemPattern>(element, pattern));
                            break;
                        case "ScrollPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IScrollPattern>(element, pattern));
                            break;
                        case "SelectionItemPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<ISelectionItemPattern>(element, pattern));
                            break;
                        case "SelectionPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<ISelectionPattern>(element, pattern));
                            break;
                        case "TableItemPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<ITableItemPattern>(element, pattern));
                            break;
                        case "TablePattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<ITablePattern>(element, pattern));
                            break;
                        case "TextPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<ITextPattern>(element, pattern));
                            break;
                        case "TogglePattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<ITogglePattern>(element, pattern));
                            break;
                        case "TransformPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<ITransformPattern>(element, pattern));
                            break;
                        case "ValuePattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IValuePattern>(element, pattern));
                            break;
                        case "WindowPattern":
                            resultList.Add(AutomationFactory.GetPatternAdapter<IWindowPattern>(element, pattern));
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
        
        internal static bool TestControlByPropertiesFromDictionary(
            this IUiElement element,
            Dictionary<string, object> dict)
        {
            bool result = false;
            
            // 20140127
            if (null == dict || 0 == dict.Keys.Count()) return result;
            
            foreach (string key in dict.Keys) {

                // WriteVerbose(this, "Key = " + key + "; Value = " + dict[key].ToString());
                string keyValue = dict[key].ToString();
                
                const WildcardOptions options = WildcardOptions.IgnoreCase |
                                                WildcardOptions.Compiled;
                switch (key) {
                    case "ACCELERATORKEY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.AcceleratorKey))) {
                                // WriteVerbose(this, "ACCELERATORKEY failed");
                                return result;
                        }
                        break;
                    case "ACCESSKEY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.AccessKey))) {
                                // WriteVerbose(this, "ACCESSKEY failed");
                                return result;
                        }
                        break;
                    case "AUTOMATIONID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.AutomationId))) {
                                // WriteVerbose(this, "AUTOMATIONID failed");
                                return result;
                        }
                        break;
                    case "CLASS":
                    case "CLASSNAME":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.ClassName))) {
                                // WriteVerbose(this, "CLASSNAME failed");
                                return result;
                        }
                        break;
                    case "CONTROLTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.ControlType.ProgrammaticName.Substring(12)))) {
                                // WriteVerbose(this, "CONTROLTYPE failed");
                                return result;
                        }
                        break;
                    case "FRAMEWORKID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.FrameworkId))) {
                                // WriteVerbose(this, "FRAMEWORKID failed");
                                return result;
                        }
                        break;
                    case "HASKEYBOARDFOCUS":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.HasKeyboardFocus.ToString()))) {
                                // WriteVerbose(this, "HASKEYBOARDFOCUS failed");
                                return result;
                        }
                        break;
                    case "HELPTEXT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.HelpText))) {
                                // WriteVerbose(this, "HELPTEXT failed");
                                return result;
                        }
                        break;
                    case "ISCONTENTELEMENT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.IsContentElement.ToString()))) {
                                // WriteVerbose(this, "ISCONTENTELEMENT failed");
                                return result;
                        }
                        break;
                    case "ISCONTROLELEMENT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.IsControlElement.ToString()))) {
                                // WriteVerbose(this, "ISCONTROLELEMENT failed");
                                return result;
                        }
                        break;
                    case "ISENABLED":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.IsEnabled.ToString()))) {
                                // WriteVerbose(this, "ISENABLED failed");
                                return result;
                        }
                        break;
                    case "ISKEYBOARDFOCUSABLE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.IsKeyboardFocusable.ToString()))) {
                                // WriteVerbose(this, "ISKEYBOARDFOCUSABLE failed");
                                return result;
                        }
                        break;
                    case "ISOFFSCREEN":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.IsOffscreen.ToString()))) {
                                // WriteVerbose(this, "ISOFFSCREEN failed");
                                return result;
                        }
                        break;
                    case "ISPASSWORD":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.IsPassword.ToString()))) {
                                // WriteVerbose(this, "ISPASSWORD failed");
                                return result;
                        }
                        break;
                    case "ISREQUIREDFORFORM":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.IsRequiredForForm.ToString()))) {
                                // WriteVerbose(this, "ISREQUIREDFORFORM failed");
                                return result;
                        }
                        break;
                    case "ITEMSTATUS":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.ItemStatus))) {
                                // WriteVerbose(this, "ITEMSTATUS failed");
                                return result;
                        }
                        break;
                    case "ITEMTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.ItemType))) {
                                // WriteVerbose(this, "ITEMTYPE failed");
                                return result;
                        }
                        break;
                    case "LABELEDBY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.LabeledBy.Current.Name))) {
                                // WriteVerbose(this, "LABELEDBY failed");
                                return result;
                        }
                        break;
                    case "LOCALIZEDCONTROLTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.LocalizedControlType))) {
                                // WriteVerbose(this, "LOCALIZEDCONTROLTYPE failed");
                                return result;
                        }
                        break;
                    case "NAME":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.Name))) {
                                // WriteVerbose(this, "NAME failed");
                                return result;
                        }
                        break;
                    case "NATIVEWINDOWHANDLE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.NativeWindowHandle.ToString()))) {
                                // WriteVerbose(this, "NATIVEWINDOWHANDLE failed");
                                return result;
                        }
                        break;
                    case "ORIENTATION":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.Orientation.ToString()))) {
                                // WriteVerbose(this, "ORIENTATION failed");
                                return result;
                        }
                        break;
                    case "PROCESSID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.Current.ProcessId.ToString()))) {
                                // WriteVerbose(this, "PROCESSID failed");
                                return result;
                        }
                        break;
                    default:
                        (new CommonCmdletBase()).WriteError(
                            // this,
                            new CommonCmdletBase(),
                            "Wrong AutomationElement parameter is provided: " + key,
                            "WrongParameter",
                            ErrorCategory.InvalidArgument,
                            true);
                        break;
                }
            }
            
            result = true;
            return result;
        }
    }
}