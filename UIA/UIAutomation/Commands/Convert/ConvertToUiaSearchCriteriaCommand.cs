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
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Collections;
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
            List<string> defaultExcludeList =
                new List<string> {"LabeledBy", "NativeWindowHandle", "ProcessId"};
            Exclude = defaultExcludeList.ToArray();
            
            List<string> defaultIncludeList =
                new List<string> {"Name", "AutomationId", "ControlType"};
            Include = defaultIncludeList.ToArray();
            Full = false;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public string[] Include { get; set; }
        [Parameter(Mandatory = false)]
        public string[] Exclude { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Full { get; set; }
        #endregion Parameters
        
        // 20131210
        // private IUiElement _currentInputObject = null;
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {
                
                // 20120823
                // 20131210
                // _currentInputObject = inputObject;
                
            if (Full) {
                
                //this.Exclude = null;
                Exclude =
                    new string[] {};
//                for (int i = 0; i < this.Exclude.Length; i++) {
//                    
//                }
                
            }
            
            string result = "@{";
            
            // 20131210
            // and further
            // result += GetPropertyCompleteString(result, "Name");
            result += GetPropertyCompleteString(inputObject, result, "Name");
            result += GetPropertyCompleteString(inputObject, result, "AutomationId");
            result += GetPropertyCompleteString(inputObject, result, "ControlType");
            result += GetPropertyCompleteString(inputObject, result, "Class");
            result += GetPropertyCompleteString(inputObject, result, "AcceleratorKey");
            result += GetPropertyCompleteString(inputObject, result, "AccessKey");
            result += GetPropertyCompleteString(inputObject, result, "BoundingRectangle");
            result += GetPropertyCompleteString(inputObject, result, "FrameworkId");
            result += GetPropertyCompleteString(inputObject, result, "HasKeyboardFocus");
            result += GetPropertyCompleteString(inputObject, result, "HelpText");
            result += GetPropertyCompleteString(inputObject, result, "IsContentElement");
            result += GetPropertyCompleteString(inputObject, result, "IsControlElement");
            result += GetPropertyCompleteString(inputObject, result, "IsEnabled");
            result += GetPropertyCompleteString(inputObject, result, "IsKeyboardFocusable");
            result += GetPropertyCompleteString(inputObject, result, "IsOffscreen");
            result += GetPropertyCompleteString(inputObject, result, "IsPassword");
            result += GetPropertyCompleteString(inputObject, result, "IsRequiredForForm");
            result += GetPropertyCompleteString(inputObject, result, "ItemStatus");
            result += GetPropertyCompleteString(inputObject, result, "ItemType");
            //result += getPropertyCompleteString(inputObject, result, "LabeledBy");
            result += GetPropertyCompleteString(inputObject, result, "LocalizedControlType");
            result += GetPropertyCompleteString(inputObject, result, "NativeWindowHandle");
            result += GetPropertyCompleteString(inputObject, result, "Orientation");
            result += GetPropertyCompleteString(inputObject, result, "ProcessId");
            
            // 20130127
            // 20131210
            // result += GetPatternStrings();
            result += GetPatternStrings(inputObject);
            
            result += "}";
            WriteObject(this, result);
            
            } // 20120823
            
        }
        
        // 20131210
        // private string GetPatternStrings()
        private string GetPatternStrings(IUiElement currentElement)
        {
            string result = string.Empty;
            
            if (!Full) return result;
            // 20131209
            // AutomationPattern[] supportedPatterns =
            //     _currentInputObject.GetSupportedPatterns();
            IBasePattern[] supportedPatterns =
                // 20131210
                // _currentInputObject.GetSupportedPatterns();
                currentElement.GetSupportedPatterns();
            
            if (null == supportedPatterns || 0 == supportedPatterns.Length) return result;
            
            // 20131209
            // foreach (AutomationPattern pattern in supportedPatterns) {
            foreach (IBasePattern pattern in supportedPatterns) {
                
                result += ";Has";
                result +=
                    // 20131209
                    // pattern.ProgrammaticName.Substring(0, pattern.ProgrammaticName.Length - 19);
                    // 20131210
                    // (pattern.SourcePattern as AutomationPattern).ProgrammaticName.Substring(0, (pattern as AutomationPattern).ProgrammaticName.Length - 19);
                    // (pattern.SourcePattern as AutomationPattern).ProgrammaticName.Substring(0, (pattern.SourcePattern as AutomationPattern).ProgrammaticName.Length - 19);
                    (pattern.GetSourcePattern() as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", string.Empty);
                
                result += "=$true";
            }
            
            return result;
        }
        
        private string propertyToString(object property)
        {
            string result = "\"\"";
            string tempResult = 
                property.ToString();
            if (tempResult.ToUpper() == "TRUE") {
                tempResult = "$true";
            }
            if (tempResult.ToUpper() == "FALSE") {
                tempResult = "$false";
            }
            if (tempResult != "$true" && tempResult != "$false" && tempResult != string.Empty) {
                tempResult = 
                    "\"" + 
                    tempResult + 
                    "\"";
            }
            if (tempResult != null && tempResult.Length > 0) {
                result = tempResult;
            }
            return result;
        }
        
        private string GetPropertyCompleteString(
            // 20131210
            IUiElement currentElement,
            string resultString,
            string propertyName)
        {
            string result = string.Empty;
            
            if ((Full) ||
                (IsIncluded(propertyName) &&
                 !IsExcluded(propertyName))) {
                result = propertyName;
                result += "=";
                
                switch (propertyName) {
                    case "Name":
                        // 20131210
                        // and further
                        // result += propertyToString(_currentInputObject.Current.Name);
                        result += propertyToString(currentElement.Current.Name);
                        break;
                    case "AutomationId":
                        result += propertyToString(currentElement.Current.AutomationId);
                        break;
                    case "ControlType":
                        result += propertyToString(currentElement.Current.ControlType.ProgrammaticName.Substring(12));
                        break;
                    case "Class":
                        result += propertyToString(currentElement.Current.ClassName);
                        break;
                    case "AcceleratorKey":
                        result += propertyToString(currentElement.Current.AcceleratorKey);
                        break;
                    case "AccessKey":
                        result += propertyToString(currentElement.Current.AccessKey);
                        break;
                    case "BoundingRectangle":
                        result += propertyToString(currentElement.Current.BoundingRectangle.ToString());
                        break;
                    case "FrameworkId":
                        result += propertyToString(currentElement.Current.FrameworkId);
                        break;
                    case "HasKeyboardFocus":
                        result += propertyToString(currentElement.Current.HasKeyboardFocus.ToString());
                        break;
                    case "HelpText":
                        result += propertyToString(currentElement.Current.HelpText);
                        break;
                    case "IsContentElement":
                        result += propertyToString(currentElement.Current.IsContentElement.ToString());
                        break;
                    case "IsControlElement":
                        result += propertyToString(currentElement.Current.IsControlElement.ToString());
                        break;
                    case "IsEnabled":
                        result += propertyToString(currentElement.Current.IsEnabled.ToString());
                        break;
                    case "IsKeyboardFocusable":
                        result += propertyToString(currentElement.Current.IsKeyboardFocusable.ToString());
                        break;
                    case "IsOffscreen":
                        result += propertyToString(currentElement.Current.IsOffscreen.ToString());
                        break;
                    case "IsPassword":
                        result += propertyToString(currentElement.Current.IsPassword.ToString());
                        break;
                    case "IsRequiredForForm":
                        result += propertyToString(currentElement.Current.IsRequiredForForm.ToString());
                        break;
                    case "ItemStatus":
                        result += propertyToString(currentElement.Current.ItemStatus);
                        break;
                    case "ItemType":
                        result += propertyToString(currentElement.Current.ItemType);
                        break;
                    //case "LabeledBy":
                    //    result += 
                    //    break;
                    case "LocalizedControlType":
                        result += propertyToString(currentElement.Current.LocalizedControlType);
                        break;
                    case "NativeWindowHandle":
                        result += propertyToString(currentElement.Current.NativeWindowHandle.ToString());
                        break;
                    case "Orientation":
                        result += propertyToString(currentElement.Current.Orientation.ToString());
                        break;
                    case "ProcessId":
                        result += propertyToString(currentElement.Current.ProcessId.ToString());
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
        
        private bool IsIncluded(string propertyName)
        {
            return Include.Any(t => String.Equals(t, propertyName, StringComparison.CurrentCultureIgnoreCase));

            /*
            bool result = false;
            for (int i = 0; i < this.Include.Length; i++) {
                if (this.Include[i].ToUpper() == propertyName.ToUpper()) {
                    result = true;
                    break;
                }
            }
            return result;
            */
        }

        private bool IsExcluded(string propertyName)
        {
            return Exclude.Any(t => String.Equals(t, propertyName, StringComparison.CurrentCultureIgnoreCase));
            /*
            bool result = false;
            for (int i = 0; i < this.Exclude.Length; i++)
            {
                if (this.Exclude[i].ToUpper() == propertyName.ToUpper())
                {
                    result = true;
                    break;
                }
            }
            return result;
            */
        }
    }
}
