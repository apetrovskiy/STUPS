/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/26/2012
 * Time: 10:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections;
using System.Linq;

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    // 20120823
    using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Description of ConvertToUiaHashtableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UiaHashtable")]
    public class ConvertToUiaHashtableCommand : ConvertCmdletBase
    {
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // if (!this.CheckControl(this)) { return; }
            if (!CheckAndPrepareInput(this)) { return; }
            
            // 20120823
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (Hashtable hashtable in InputObject.Select(inputObject => new Hashtable
            {
                {"Name", inputObject.Current.Name},
                {"AutomationId", inputObject.Current.AutomationId},
                {"ControlType", inputObject.Current.ControlType.ProgrammaticName},
                {"Class", inputObject.Current.ClassName},
                {"AcceleratorKey", inputObject.Current.AcceleratorKey},
                {"AccessKey", inputObject.Current.AccessKey},
                {"BoundingRectangle", inputObject.Current.BoundingRectangle.ToString()},
                {"FrameworkId", inputObject.Current.FrameworkId},
                {"HasKeyboardFocus", inputObject.Current.HasKeyboardFocus.ToString()},
                {"HelpText", inputObject.Current.HelpText},
                {"IsContentElement", inputObject.Current.IsContentElement.ToString()},
                {"IsControlElement", inputObject.Current.IsControlElement.ToString()},
                {"IsEnabled", inputObject.Current.IsEnabled.ToString()},
                {"IsKeyboardFocusable", inputObject.Current.IsKeyboardFocusable.ToString()},
                {"IsOffscreen", inputObject.Current.IsOffscreen.ToString()},
                {"IsPassword", inputObject.Current.IsPassword.ToString()},
                {"IsRequiredForForm", inputObject.Current.IsRequiredForForm.ToString()},
                {"ItemStatus", inputObject.Current.ItemStatus},
                {"ItemType", inputObject.Current.ItemType},
                {"LocalizedControlType", inputObject.Current.LocalizedControlType},
                {"NativeWindowHandle", inputObject.Current.NativeWindowHandle.ToString()},
                {"Orientation", inputObject.Current.Orientation.ToString()},
                {"ProcessId", inputObject.Current.ProcessId.ToString()}
            }))
            {
                #region commented
                //            hashtable.Add("Name", this.InputObject.Current.Name);
//            hashtable.Add("AutomationId", this.InputObject.Current.AutomationId);
//            hashtable.Add("ControlType", this.InputObject.Current.ControlType.ProgrammaticName);
//            hashtable.Add("Class", this.InputObject.Current.ClassName);
//            hashtable.Add("AcceleratorKey", this.InputObject.Current.AcceleratorKey);
//            hashtable.Add("AccessKey", this.InputObject.Current.AccessKey);
//            hashtable.Add("BoundingRectangle", this.InputObject.Current.BoundingRectangle.ToString());
//            hashtable.Add("FrameworkId", this.InputObject.Current.FrameworkId);
//            hashtable.Add("HasKeyboardFocus", this.InputObject.Current.HasKeyboardFocus.ToString());
//            hashtable.Add("HelpText", this.InputObject.Current.HelpText);
//            hashtable.Add("IsContentElement", this.InputObject.Current.IsContentElement.ToString());
//            hashtable.Add("IsControlElement", this.InputObject.Current.IsControlElement.ToString());
//            hashtable.Add("IsEnabled", this.InputObject.Current.IsEnabled.ToString());
//            hashtable.Add("IsKeyboardFocusable", this.InputObject.Current.IsKeyboardFocusable.ToString());
//            hashtable.Add("IsOffscreen", this.InputObject.Current.IsOffscreen.ToString());
//            hashtable.Add("IsPassword", this.InputObject.Current.IsPassword.ToString());
//            hashtable.Add("IsRequiredForForm", this.InputObject.Current.IsRequiredForForm.ToString());
//            hashtable.Add("ItemStatus", this.InputObject.Current.ItemStatus);
//            hashtable.Add("ItemType", this.InputObject.Current.ItemType);
//            //hashtable.Add("LabeledBy", this.InputObject.Current.LabeledBy);
//            hashtable.Add("LocalizedControlType", this.InputObject.Current.LocalizedControlType);
//            hashtable.Add("NativeWindowHandle", this.InputObject.Current.NativeWindowHandle.ToString());
//            hashtable.Add("Orientation", this.InputObject.Current.Orientation.ToString());
//            hashtable.Add("ProcessId", this.InputObject.Current.ProcessId.ToString());
                #endregion commented

                // 20120823
                //hashtable.Add("LabeledBy", inputObject.Current.LabeledBy);

                /*
            System.Collections.Hashtable hashtable = 
                new System.Collections.Hashtable();
            
            // 20120823
            hashtable.Add("Name", inputObject.Current.Name);
            hashtable.Add("AutomationId", inputObject.Current.AutomationId);
            hashtable.Add("ControlType", inputObject.Current.ControlType.ProgrammaticName);
            hashtable.Add("Class", inputObject.Current.ClassName);
            hashtable.Add("AcceleratorKey", inputObject.Current.AcceleratorKey);
            hashtable.Add("AccessKey", inputObject.Current.AccessKey);
            hashtable.Add("BoundingRectangle", inputObject.Current.BoundingRectangle.ToString());
            hashtable.Add("FrameworkId", inputObject.Current.FrameworkId);
            hashtable.Add("HasKeyboardFocus", inputObject.Current.HasKeyboardFocus.ToString());
            hashtable.Add("HelpText", inputObject.Current.HelpText);
            hashtable.Add("IsContentElement", inputObject.Current.IsContentElement.ToString());
            hashtable.Add("IsControlElement", inputObject.Current.IsControlElement.ToString());
            hashtable.Add("IsEnabled", inputObject.Current.IsEnabled.ToString());
            hashtable.Add("IsKeyboardFocusable", inputObject.Current.IsKeyboardFocusable.ToString());
            hashtable.Add("IsOffscreen", inputObject.Current.IsOffscreen.ToString());
            hashtable.Add("IsPassword", inputObject.Current.IsPassword.ToString());
            hashtable.Add("IsRequiredForForm", inputObject.Current.IsRequiredForForm.ToString());
            hashtable.Add("ItemStatus", inputObject.Current.ItemStatus);
            hashtable.Add("ItemType", inputObject.Current.ItemType);
            //hashtable.Add("LabeledBy", inputObject.Current.LabeledBy);
            hashtable.Add("LocalizedControlType", inputObject.Current.LocalizedControlType);
            hashtable.Add("NativeWindowHandle", inputObject.Current.NativeWindowHandle.ToString());
            hashtable.Add("Orientation", inputObject.Current.Orientation.ToString());
            hashtable.Add("ProcessId", inputObject.Current.ProcessId.ToString());
            */

                // 20120831
                WriteObject(this, hashtable);
            }
        }
    }
    
    /// <summary>
    /// Description of ConvertToUiaSearchCriteriaCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UiaSearchCriteria")]
    public class ConvertToUiaSearchCriteriaCommand : ConvertCmdletBase
    {
        public ConvertToUiaSearchCriteriaCommand()
        {
            // 20131202
            // ArrayList defaultExcludeList = 
            List<string> defaultExcludeList =
                // new ArrayList {"LabeledBy", "NativeWindowHandle", "ProcessId"};
                new List<string> {"LabeledBy", "NativeWindowHandle", "ProcessId"};
            // Exclude = (string[])defaultExcludeList.ToArray(typeof(string));
            Exclude = defaultExcludeList.ToArray();
            // ArrayList defaultIncludeList = 
            List<string> defaultIncludeList =
                // new ArrayList {"Name", "AutomationId", "ControlType"};
                new List<string> {"Name", "AutomationId", "ControlType"};
            // Include = (string[])defaultIncludeList.ToArray(typeof(string));
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
        
        private IMySuperWrapper _currentInputObject = null;
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IMySuperWrapper inputObject in InputObject) {
                // 20120823
                _currentInputObject = inputObject;
            
            if (Full) {
                //this.Exclude = null;
                Exclude =
                    // 20131202
                    // (string[])(new ArrayList()).ToArray(typeof(string));
                    new string[] {};
//                for (int i = 0; i < this.Exclude.Length; i++) {
//                    
//                }
            }

            string result = "@{";
            
            result += GetPropertyCompleteString(result, "Name");
            result += GetPropertyCompleteString(result, "AutomationId");
            result += GetPropertyCompleteString(result, "ControlType");
            result += GetPropertyCompleteString(result, "Class");
            result += GetPropertyCompleteString(result, "AcceleratorKey");
            result += GetPropertyCompleteString(result, "AccessKey");
            result += GetPropertyCompleteString(result, "BoundingRectangle");
            result += GetPropertyCompleteString(result, "FrameworkId");
            result += GetPropertyCompleteString(result, "HasKeyboardFocus");
            result += GetPropertyCompleteString(result, "HelpText");
            result += GetPropertyCompleteString(result, "IsContentElement");
            result += GetPropertyCompleteString(result, "IsControlElement");
            result += GetPropertyCompleteString(result, "IsEnabled");
            result += GetPropertyCompleteString(result, "IsKeyboardFocusable");
            result += GetPropertyCompleteString(result, "IsOffscreen");
            result += GetPropertyCompleteString(result, "IsPassword");
            result += GetPropertyCompleteString(result, "IsRequiredForForm");
            result += GetPropertyCompleteString(result, "ItemStatus");
            result += GetPropertyCompleteString(result, "ItemType");
            //result += getPropertyCompleteString(result, "LabeledBy");
            result += GetPropertyCompleteString(result, "LocalizedControlType");
            result += GetPropertyCompleteString(result, "NativeWindowHandle");
            result += GetPropertyCompleteString(result, "Orientation");
            result += GetPropertyCompleteString(result, "ProcessId");
            // 20130127
            result += GetPatternStrings();

            result += "}";
            WriteObject(this, result);
            
            } // 20120823
            
        }
        
        private string GetPatternStrings()
        {
            string result = string.Empty;

            if (!Full) return result;
            AutomationPattern[] supportedPatterns =
                _currentInputObject.GetSupportedPatterns();
            if (null == supportedPatterns || 0 >= supportedPatterns.Length) return result;
            foreach (AutomationPattern pattern in supportedPatterns) {
                result += ";Has";
                result +=
                    pattern.ProgrammaticName.Substring(0, pattern.ProgrammaticName.Length - 19);
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
                        result += propertyToString(_currentInputObject.Current.Name);
                        break;
                    case "AutomationId":
                        result += propertyToString(_currentInputObject.Current.AutomationId);
                        break;
                    case "ControlType":
                        result += propertyToString(_currentInputObject.Current.ControlType.ProgrammaticName.Substring(12));
                        break;
                    case "Class":
                        result += propertyToString(_currentInputObject.Current.ClassName);
                        break;
                    case "AcceleratorKey":
                        result += propertyToString(_currentInputObject.Current.AcceleratorKey);
                        break;
                    case "AccessKey":
                        result += propertyToString(_currentInputObject.Current.AccessKey);
                        break;
                    case "BoundingRectangle":
                        result += propertyToString(_currentInputObject.Current.BoundingRectangle.ToString());
                        break;
                    case "FrameworkId":
                        result += propertyToString(_currentInputObject.Current.FrameworkId);
                        break;
                    case "HasKeyboardFocus":
                        result += propertyToString(_currentInputObject.Current.HasKeyboardFocus.ToString());
                        break;
                    case "HelpText":
                        result += propertyToString(_currentInputObject.Current.HelpText);
                        break;
                    case "IsContentElement":
                        result += propertyToString(_currentInputObject.Current.IsContentElement.ToString());
                        break;
                    case "IsControlElement":
                        result += propertyToString(_currentInputObject.Current.IsControlElement.ToString());
                        break;
                    case "IsEnabled":
                        result += propertyToString(_currentInputObject.Current.IsEnabled.ToString());
                        break;
                    case "IsKeyboardFocusable":
                        result += propertyToString(_currentInputObject.Current.IsKeyboardFocusable.ToString());
                        break;
                    case "IsOffscreen":
                        result += propertyToString(_currentInputObject.Current.IsOffscreen.ToString());
                        break;
                    case "IsPassword":
                        result += propertyToString(_currentInputObject.Current.IsPassword.ToString());
                        break;
                    case "IsRequiredForForm":
                        result += propertyToString(_currentInputObject.Current.IsRequiredForForm.ToString());
                        break;
                    case "ItemStatus":
                        result += propertyToString(_currentInputObject.Current.ItemStatus);
                        break;
                    case "ItemType":
                        result += propertyToString(_currentInputObject.Current.ItemType);
                        break;
                    //case "LabeledBy":
                    //    result += 
                    //    break;
                    case "LocalizedControlType":
                        result += propertyToString(_currentInputObject.Current.LocalizedControlType);
                        break;
                    case "NativeWindowHandle":
                        result += propertyToString(_currentInputObject.Current.NativeWindowHandle.ToString());
                        break;
                    case "Orientation":
                        result += propertyToString(_currentInputObject.Current.Orientation.ToString());
                        break;
                    case "ProcessId":
                        result += propertyToString(_currentInputObject.Current.ProcessId.ToString());
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
