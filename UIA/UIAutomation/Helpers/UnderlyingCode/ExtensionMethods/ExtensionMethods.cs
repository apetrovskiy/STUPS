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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Description of ExtensionsMethods.
    /// </summary>
    public static class ExtensionsMethods
    {
        // not used
//        public static IUiEltCollection ConvertCmdletInputToCollectionAdapter(this ICollection inputArray)
//        {
//            IUiEltCollection resultCollection =
//                AutomationFactory.GetUiEltCollection(inputArray);
//            return resultCollection;
//        }
        
        public static IBasePattern[] ConvertAutomationPatternToBasePattern(this classic.AutomationPattern[] patterns, IUiElement element)
        {
            var resultList =
                new List<IBasePattern>();
            foreach (classic.AutomationPattern pattern in patterns) {
                
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
                        //     break;
                    }
                }
                catch {
                    
                }
            }
            
            return resultList.ToArray();
        }
        
        internal static bool TestControlByPropertiesFromDictionary(
            this IUiElement element,
            Dictionary<string, object> dict)
        {
            bool result = false;
            
            if (null == dict || 0 == dict.Keys.Count()) return result;
            
            foreach (string key in dict.Keys) {

                string keyValue = dict[key].ToString();
                
                const WildcardOptions options = WildcardOptions.IgnoreCase |
                                                WildcardOptions.Compiled;
                
                switch (key) {
                    case "ACCELERATORKEY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().AcceleratorKey))) {
                                return result;
                        }
                        break;
                    case "ACCESSKEY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().AccessKey))) {
                                return result;
                        }
                        break;
                    case "AUTOMATIONID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().AutomationId))) {
                                return result;
                        }
                        break;
                    case "CLASS":
                    case "CLASSNAME":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().ClassName))) {
                                return result;
                        }
                        break;
                    case "CONTROLTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().ControlType.ProgrammaticName.Substring(12)))) {
                                return result;
                        }
                        break;
                    case "FRAMEWORKID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().FrameworkId))) {
                                return result;
                        }
                        break;
                    case "HASKEYBOARDFOCUS":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().HasKeyboardFocus.ToString()))) {
                                return result;
                        }
                        break;
                    case "HELPTEXT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().HelpText))) {
                                return result;
                        }
                        break;
                    case "ISCONTENTELEMENT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().IsContentElement.ToString()))) {
                                return result;
                        }
                        break;
                    case "ISCONTROLELEMENT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().IsControlElement.ToString()))) {
                                return result;
                        }
                        break;
                    case "ISENABLED":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().IsEnabled.ToString()))) {
                                return result;
                        }
                        break;
                    case "ISKEYBOARDFOCUSABLE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().IsKeyboardFocusable.ToString()))) {
                                return result;
                        }
                        break;
                    case "ISOFFSCREEN":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().IsOffscreen.ToString()))) {
                                return result;
                        }
                        break;
                    case "ISPASSWORD":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().IsPassword.ToString()))) {
                                return result;
                        }
                        break;
                    case "ISREQUIREDFORFORM":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().IsRequiredForForm.ToString()))) {
                                return result;
                        }
                        break;
                    case "ITEMSTATUS":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().ItemStatus))) {
                                return result;
                        }
                        break;
                    case "ITEMTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().ItemType))) {
                                return result;
                        }
                        break;
                    case "LABELEDBY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().LabeledBy.Current.Name))) {
                                return result;
                        }
                        break;
                    case "LOCALIZEDCONTROLTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().LocalizedControlType))) {
                                return result;
                        }
                        break;
                    case "NAME":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().Name))) {
                                return result;
                        }
                        break;
                    case "NATIVEWINDOWHANDLE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().NativeWindowHandle.ToString()))) {
                                return result;
                        }
                        break;
                    case "ORIENTATION":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().Orientation.ToString()))) {
                                return result;
                        }
                        break;
                    case "PROCESSID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(element.GetCurrent().ProcessId.ToString()))) {
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
        
        internal static string[] ConvertControlTypeToStringArray(this classic.ControlType[] controlTypes)
        {
            if (null == controlTypes || 0 == controlTypes.Length) return new string[] {};
            
            return controlTypes.Select(
                ct =>
                null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
        }
        
        internal static string[] ConvertControlTypeToStringArray(this classic.ControlType controlType)
        {
            return null == controlType ? new string[] {

            } : new string[] {
                controlType.ProgrammaticName.Substring(12)
            };
        }
        
        // not used
//        internal static SingleControlSearcherData ConvertControlSearcherDataToSingleControlSearcherData(this ControlSearcherData data)
//        {
//            return new SingleControlSearcherData {
//                InputObject = (null == data.InputObject ? null : (data.InputObject[0] ?? null)),
//                Name = data.Name,
//                AutomationId = data.AutomationId,
//                Class = data.Class,
//                Value = data.Value,
//                ControlType = data.ControlType,
//                ContainsText = data.ContainsText,
//                Win32 = data.Win32,
//                CaseSensitive = data.CaseSensitive,
//                Regex = data.Regex,
//                SearchCriteria = data.SearchCriteria
//            };
//        }
        
        internal static SingleControlSearcherData ConvertControlSearcherTemplateDataToSingleControlSearcherData(this ControlSearcherTemplateData data)
        {
            return new SingleControlSearcherData {
                InputObject = (null == data.InputObject ? null : (data.InputObject[0] ?? null)),
                Name = data.Name,
                AutomationId = data.AutomationId,
                Class = data.Class,
                Value = data.Value,
                ControlType = data.ControlType,
                ContainsText = data.ContainsText,
                Win32 = data.Win32,
                CaseSensitive = data.CaseSensitive,
                Regex = data.Regex,
                SearchCriteria = data.SearchCriteria
            };
        }
        
        internal static ControlSearcherTemplateData ConvertSingleControlSearcherDataToControlSearcherTemplateData(this SingleControlSearcherData data)
        {
            return new ControlSearcherTemplateData {
                InputObject = new IUiElement[] { data.InputObject },
                Name = data.Name,
                AutomationId = data.AutomationId,
                Class = data.Class,
                Value = data.Value,
                ControlType = data.ControlType,
                ContainsText = data.ContainsText,
                Win32 = data.Win32,
                CaseSensitive = data.CaseSensitive,
                Regex = data.Regex,
                SearchCriteria = data.SearchCriteria
            };
        }
    }
}