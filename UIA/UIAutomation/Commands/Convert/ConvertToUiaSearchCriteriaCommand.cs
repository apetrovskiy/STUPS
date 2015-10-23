/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/27/2013
 * Time: 2:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
//    using System.Windows.Automation;
//    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Description of ConvertToUiaSearchCriteriaCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UiaSearchCriteria")]
    public class ConvertToUiaSearchCriteriaCommand : ConvertCmdletBase
    {
        public ConvertToUiaSearchCriteriaCommand()
        {
            var defaultExcludeList =
                new List<string> {"LabeledBy", "NativeWindowHandle", "ProcessId"};
            Exclude = defaultExcludeList.ToArray();
            
            var defaultIncludeList =
                new List<string> {"Name", "AutomationId", "ControlType"};
            Include = defaultIncludeList.ToArray();
            Full = false;
            
            /*
            List<string> defaultExcludeList =
                new List<string> {"LabeledBy", "NativeWindowHandle", "ProcessId"};
            Exclude = defaultExcludeList.ToArray();
            
            List<string> defaultIncludeList =
                new List<string> {"Name", "AutomationId", "ControlType"};
            Include = defaultIncludeList.ToArray();
            Full = false;
            */
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        public string[] Include { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public string[] Exclude { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter Full { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            if (Full) {
                Exclude = new string[] {};
            }
            
            // 20140305
//            var command = AutomationFactory.GetCommand<ConvertToSearchCriteriaCommand>(this);
//            command.Execute();
            
//            foreach (string strInclude in Include) {
//                WriteVerbose(this, "include: " + strInclude);
//            }
//            foreach (string strExclude in Exclude) {
//                WriteVerbose(this, "exclude: " + strExclude);
//            }
//            
            foreach (IUiElement element in InputObject) {
                WriteObject(this, ConvertElementToSearchCriteria(element));
            }
        }

        protected internal string ConvertElementToSearchCriteria(IUiElement element)
        {
            string result = "@{";
            result += GetPropertyCompleteString(element, result, "Name");
            result += GetPropertyCompleteString(element, result, "AutomationId");
            result += GetPropertyCompleteString(element, result, "ControlType");
            result += GetPropertyCompleteString(element, result, "Class");
            result += GetPropertyCompleteString(element, result, "AcceleratorKey");
            result += GetPropertyCompleteString(element, result, "AccessKey");
            result += GetPropertyCompleteString(element, result, "BoundingRectangle");
            result += GetPropertyCompleteString(element, result, "FrameworkId");
            result += GetPropertyCompleteString(element, result, "HasKeyboardFocus");
            result += GetPropertyCompleteString(element, result, "HelpText");
            result += GetPropertyCompleteString(element, result, "IsContentElement");
            result += GetPropertyCompleteString(element, result, "IsControlElement");
            result += GetPropertyCompleteString(element, result, "IsEnabled");
            result += GetPropertyCompleteString(element, result, "IsKeyboardFocusable");
            result += GetPropertyCompleteString(element, result, "IsOffscreen");
            result += GetPropertyCompleteString(element, result, "IsPassword");
            result += GetPropertyCompleteString(element, result, "IsRequiredForForm");
            result += GetPropertyCompleteString(element, result, "ItemStatus");
            result += GetPropertyCompleteString(element, result, "ItemType");
            //result += getPropertyCompleteString(inputObject, result, "LabeledBy");
            result += GetPropertyCompleteString(element, result, "LocalizedControlType");
            result += GetPropertyCompleteString(element, result, "NativeWindowHandle");
            result += GetPropertyCompleteString(element, result, "Orientation");
            result += GetPropertyCompleteString(element, result, "ProcessId");
            result += GetPatternStrings(element);
            result += "}";
            
            return result;
        }
        
        private string GetPatternStrings(IUiElement element)
        {
            string result = string.Empty;
            
            if (!Full) return result;
            
            IBasePattern[] supportedPatterns =
                element.GetSupportedPatterns();
            
            if (null == supportedPatterns || 0 == supportedPatterns.Length) return result;
            
            foreach (IBasePattern pattern in supportedPatterns) {
                
                result += ";Has";
                result +=
                    // (pattern.GetSourcePattern() as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", string.Empty);
                    pattern.GetType().Name.Substring(2);
                result += "=$true";
            }
            
            return result;
        }
        
        private string PropertyToString(object propertyValue)
        {
            switch (propertyValue.ToString().ToUpper()) {
                case "TRUE":
                    return "$true";
                case "FALSE":
                    return "$false";
                case "":
                    return "\"\"";
                default:
                    return "\"" + propertyValue.ToString() + "\"";
            }
        }
        
        private string GetPropertyCompleteString(
            IUiElement currentElement,
            string resultString,
            string propertyName)
        {
            string result = string.Empty;
            
            if ((Full) ||
                // (IsIncluded(propertyName) &&
                // (IsInArray(Include, propertyName) &&
                // !IsExcluded(propertyName))) {
                // !IsInArray(Exclude, propertyName))) {
                
                (!IsInArray(Exclude, propertyName) &&
                (0 == Include.Length || IsInArray(Include, propertyName)))) {
                
                result = propertyName;
                result += "=";
                
                // 20140312
//                switch (propertyName) {
//                    case "Name":
//                        result += PropertyToString(currentElement.Current.Name);
//                        break;
//                    case "AutomationId":
//                        result += PropertyToString(currentElement.Current.AutomationId);
//                        break;
//                    case "ControlType":
//                        result += PropertyToString(currentElement.Current.ControlType.ProgrammaticName.Substring(12));
//                        break;
//                    case "Class":
//                        result += PropertyToString(currentElement.Current.ClassName);
//                        break;
//                    case "AcceleratorKey":
//                        result += PropertyToString(currentElement.Current.AcceleratorKey);
//                        break;
//                    case "AccessKey":
//                        result += PropertyToString(currentElement.Current.AccessKey);
//                        break;
//                    case "BoundingRectangle":
//                        result += PropertyToString(currentElement.Current.BoundingRectangle.ToString());
//                        break;
//                    case "FrameworkId":
//                        result += PropertyToString(currentElement.Current.FrameworkId);
//                        break;
//                    case "HasKeyboardFocus":
//                        result += PropertyToString(currentElement.Current.HasKeyboardFocus.ToString());
//                        break;
//                    case "HelpText":
//                        result += PropertyToString(currentElement.Current.HelpText);
//                        break;
//                    case "IsContentElement":
//                        result += PropertyToString(currentElement.Current.IsContentElement.ToString());
//                        break;
//                    case "IsControlElement":
//                        result += PropertyToString(currentElement.Current.IsControlElement.ToString());
//                        break;
//                    case "IsEnabled":
//                        result += PropertyToString(currentElement.Current.IsEnabled.ToString());
//                        break;
//                    case "IsKeyboardFocusable":
//                        result += PropertyToString(currentElement.Current.IsKeyboardFocusable.ToString());
//                        break;
//                    case "IsOffscreen":
//                        result += PropertyToString(currentElement.Current.IsOffscreen.ToString());
//                        break;
//                    case "IsPassword":
//                        result += PropertyToString(currentElement.Current.IsPassword.ToString());
//                        break;
//                    case "IsRequiredForForm":
//                        result += PropertyToString(currentElement.Current.IsRequiredForForm.ToString());
//                        break;
//                    case "ItemStatus":
//                        result += PropertyToString(currentElement.Current.ItemStatus);
//                        break;
//                    case "ItemType":
//                        result += PropertyToString(currentElement.Current.ItemType);
//                        break;
//                        //case "LabeledBy":
//                        //    result +=
//                        //    break;
//                    case "LocalizedControlType":
//                        result += PropertyToString(currentElement.Current.LocalizedControlType);
//                        break;
//                    case "NativeWindowHandle":
//                        result += PropertyToString(currentElement.Current.NativeWindowHandle.ToString());
//                        break;
//                    case "Orientation":
//                        result += PropertyToString(currentElement.Current.Orientation.ToString());
//                        break;
//                    case "ProcessId":
//                        result += PropertyToString(currentElement.Current.ProcessId.ToString());
//                        break;
//                }
                switch (propertyName) {
                    case "Name":
                        result += PropertyToString(currentElement.GetCurrent().Name);
                        break;
                    case "AutomationId":
                        result += PropertyToString(currentElement.GetCurrent().AutomationId);
                        break;
                    case "ControlType":
                        result += PropertyToString(currentElement.GetCurrent().ControlType.ProgrammaticName.Substring(12));
                        break;
                    case "Class":
                        result += PropertyToString(currentElement.GetCurrent().ClassName);
                        break;
                    case "AcceleratorKey":
                        result += PropertyToString(currentElement.GetCurrent().AcceleratorKey);
                        break;
                    case "AccessKey":
                        result += PropertyToString(currentElement.GetCurrent().AccessKey);
                        break;
                    case "BoundingRectangle":
                        result += PropertyToString(currentElement.GetCurrent().BoundingRectangle.ToString());
                        break;
                    case "FrameworkId":
                        result += PropertyToString(currentElement.GetCurrent().FrameworkId);
                        break;
                    case "HasKeyboardFocus":
                        result += PropertyToString(currentElement.GetCurrent().HasKeyboardFocus.ToString());
                        break;
                    case "HelpText":
                        result += PropertyToString(currentElement.GetCurrent().HelpText);
                        break;
                    case "IsContentElement":
                        result += PropertyToString(currentElement.GetCurrent().IsContentElement.ToString());
                        break;
                    case "IsControlElement":
                        result += PropertyToString(currentElement.GetCurrent().IsControlElement.ToString());
                        break;
                    case "IsEnabled":
                        result += PropertyToString(currentElement.GetCurrent().IsEnabled.ToString());
                        break;
                    case "IsKeyboardFocusable":
                        result += PropertyToString(currentElement.GetCurrent().IsKeyboardFocusable.ToString());
                        break;
                    case "IsOffscreen":
                        result += PropertyToString(currentElement.GetCurrent().IsOffscreen.ToString());
                        break;
                    case "IsPassword":
                        result += PropertyToString(currentElement.GetCurrent().IsPassword.ToString());
                        break;
                    case "IsRequiredForForm":
                        result += PropertyToString(currentElement.GetCurrent().IsRequiredForForm.ToString());
                        break;
                    case "ItemStatus":
                        result += PropertyToString(currentElement.GetCurrent().ItemStatus);
                        break;
                    case "ItemType":
                        result += PropertyToString(currentElement.GetCurrent().ItemType);
                        break;
                        //case "LabeledBy":
                        //    result +=
                        //    break;
                    case "LocalizedControlType":
                        result += PropertyToString(currentElement.GetCurrent().LocalizedControlType);
                        break;
                    case "NativeWindowHandle":
                        result += PropertyToString(currentElement.GetCurrent().NativeWindowHandle.ToString());
                        break;
                    case "Orientation":
                        result += PropertyToString(currentElement.GetCurrent().Orientation.ToString());
                        break;
                    case "ProcessId":
                        result += PropertyToString(currentElement.GetCurrent().ProcessId.ToString());
                        break;
                }
            }

            if (string.IsNullOrEmpty(resultString) || resultString.Length <= 0) return result;
            if (resultString.Substring(resultString.Length - 1) != "{" &&
                resultString.Substring(resultString.Length - 1) != ";") {
                result = ";" + result;
            }
            
            return result;
        }
        
        private bool IsInArray(ICollection<string> inputArray, string propertyName)
        /*
        private bool IsInArray(string[] inputArray, string propertyName)
        */
        {
            if (null == inputArray || 0 == inputArray.Count) return false;
            
            return inputArray.Any(name => String.Equals(name, propertyName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
