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
            ArrayList defaultExcludeList = 
                new ArrayList {"LabeledBy", "NativeWindowHandle", "ProcessId"};
            /*
            System.Collections.ArrayList defaultExcludeList = 
                new System.Collections.ArrayList();
            defaultExcludeList.Add("LabeledBy");
            defaultExcludeList.Add("NativeWindowHandle");
            defaultExcludeList.Add("ProcessId");
            */
            Exclude = (string[])defaultExcludeList.ToArray(typeof(string));
            ArrayList defaultIncludeList = 
                new ArrayList {"Name", "AutomationId", "ControlType"};
            /*
            System.Collections.ArrayList defaultIncludeList = 
                new System.Collections.ArrayList();
            defaultIncludeList.Add("Name");
            defaultIncludeList.Add("AutomationId");
            defaultIncludeList.Add("ControlType");
            */
            Include = (string[])defaultIncludeList.ToArray(typeof(string));
            Full = false;
            
#region commented
//            result += "Name=" + this.propertyToString(this.InputObject.Current.Name);
//            result += ";AutomationId=" + this.propertyToString(this.InputObject.Current.AutomationId);
//            result += ";ControlType=" + this.propertyToString(this.InputObject.Current.ControlType.ProgrammaticName.Substring(12));
//            result += ";Class=" + this.propertyToString(this.InputObject.Current.ClassName);
//            result += ";AcceleratorKey=" + this.propertyToString(this.InputObject.Current.AcceleratorKey);
//            result += ";AccessKey=" + this.propertyToString(this.InputObject.Current.AccessKey);
//            result += ";BoundingRectangle=" + this.propertyToString(this.InputObject.Current.BoundingRectangle.ToString());
//            result += ";FrameworkId=" + this.propertyToString(this.InputObject.Current.FrameworkId);
//            result += ";HasKeyboardFocus=" + this.propertyToString(this.InputObject.Current.HasKeyboardFocus.ToString());
//            result += ";HelpText=" + this.propertyToString(this.InputObject.Current.HelpText);
//            result += ";IsContentElement=" + this.propertyToString(this.InputObject.Current.IsContentElement.ToString());
//            result += ";IsControlElement=" + this.propertyToString(this.InputObject.Current.IsControlElement.ToString());
//            result += ";IsEnabled=" + this.propertyToString(this.InputObject.Current.IsEnabled.ToString());
//            result += ";IsKeyboardFocusable=" + this.propertyToString(this.InputObject.Current.IsKeyboardFocusable.ToString());
//            result += ";IsOffscreen=" + this.propertyToString(this.InputObject.Current.IsOffscreen.ToString());
//            result += ";IsPassword=" + this.propertyToString(this.InputObject.Current.IsPassword.ToString());
//            result += ";IsRequiredForForm=" + this.propertyToString(this.InputObject.Current.IsRequiredForForm.ToString());
//            result += ";ItemStatus=" + this.propertyToString(this.InputObject.Current.ItemStatus);
//            result += ";ItemType=" + this.propertyToString(this.InputObject.Current.ItemType);
//            //result += ";LabeledBy=" + this.propertyToString(this.InputObject.Current.LabeledBy;
//            result += ";LocalizedControlType=" + this.propertyToString(this.InputObject.Current.LocalizedControlType);
//            result += ";NativeWindowHandle=" + this.propertyToString(this.InputObject.Current.NativeWindowHandle.ToString());
//            result += ";Orientation=" + this.propertyToString(this.InputObject.Current.Orientation.ToString());
//            result += ";ProcessId=" + this.propertyToString(this.InputObject.Current.ProcessId.ToString());
#endregion commented

        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public string[] Include { get; set; }
        [Parameter(Mandatory = false)]
        public string[] Exclude { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Full { get; set; }
        #endregion Parameters
        
        // 20120823
        // 20131109
        //private AutomationElement currentInputObject = null;
        private IMySuperWrapper _currentInputObject = null;
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            // 20120823
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IMySuperWrapper inputObject in InputObject) {
                // 20120823
                _currentInputObject = inputObject;
            
            if (Full) {
                //this.Exclude = null;
                Exclude =
                    (string[])(new ArrayList()).ToArray(typeof(string));
//                for (int i = 0; i < this.Exclude.Length; i++) {
//                    
//                }
            }

            string result = "@{";
            
#region commented
//            result += "Name=" + this.propertyToString(this.InputObject.Current.Name);
//            result += ";AutomationId=" + this.propertyToString(this.InputObject.Current.AutomationId);
//            result += ";ControlType=" + this.propertyToString(this.InputObject.Current.ControlType.ProgrammaticName.Substring(12));
//            result += ";Class=" + this.propertyToString(this.InputObject.Current.ClassName);
//            result += ";AcceleratorKey=" + this.propertyToString(this.InputObject.Current.AcceleratorKey);
//            result += ";AccessKey=" + this.propertyToString(this.InputObject.Current.AccessKey);
//            result += ";BoundingRectangle=" + this.propertyToString(this.InputObject.Current.BoundingRectangle.ToString());
//            result += ";FrameworkId=" + this.propertyToString(this.InputObject.Current.FrameworkId);
//            result += ";HasKeyboardFocus=" + this.propertyToString(this.InputObject.Current.HasKeyboardFocus.ToString());
//            result += ";HelpText=" + this.propertyToString(this.InputObject.Current.HelpText);
//            result += ";IsContentElement=" + this.propertyToString(this.InputObject.Current.IsContentElement.ToString());
//            result += ";IsControlElement=" + this.propertyToString(this.InputObject.Current.IsControlElement.ToString());
//            result += ";IsEnabled=" + this.propertyToString(this.InputObject.Current.IsEnabled.ToString());
//            result += ";IsKeyboardFocusable=" + this.propertyToString(this.InputObject.Current.IsKeyboardFocusable.ToString());
//            result += ";IsOffscreen=" + this.propertyToString(this.InputObject.Current.IsOffscreen.ToString());
//            result += ";IsPassword=" + this.propertyToString(this.InputObject.Current.IsPassword.ToString());
//            result += ";IsRequiredForForm=" + this.propertyToString(this.InputObject.Current.IsRequiredForForm.ToString());
//            result += ";ItemStatus=" + this.propertyToString(this.InputObject.Current.ItemStatus);
//            result += ";ItemType=" + this.propertyToString(this.InputObject.Current.ItemType);
//            //result += ";LabeledBy=" + this.propertyToString(this.InputObject.Current.LabeledBy;
//            result += ";LocalizedControlType=" + this.propertyToString(this.InputObject.Current.LocalizedControlType);
//            result += ";NativeWindowHandle=" + this.propertyToString(this.InputObject.Current.NativeWindowHandle.ToString());
//            result += ";Orientation=" + this.propertyToString(this.InputObject.Current.Orientation.ToString());
//            result += ";ProcessId=" + this.propertyToString(this.InputObject.Current.ProcessId.ToString());
#endregion commented

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

            /*
            if (this.Full) {
                AutomationPattern[] supportedPatterns =
                    currentInputObject.GetSupportedPatterns();
                if (null != supportedPatterns && 0 < supportedPatterns.Length) {
                    foreach (AutomationPattern pattern in supportedPatterns) {
                        result += ";Has";
                        result +=
                            pattern.ProgrammaticName.Substring(0, pattern.ProgrammaticName.Length - 19);
                        result += "=$true";
                    }
                }
            }
            */
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
                
#region commented
//                switch (propertyName) {
//                    case "Name":
//                        result += this.propertyToString(this.InputObject.Current.Name);
//                        break;
//                    case "AutomationId":
//                        result += this.propertyToString(this.InputObject.Current.AutomationId);
//                        break;
//                    case "ControlType":
//                        result += this.propertyToString(this.InputObject.Current.ControlType.ProgrammaticName.Substring(12));
//                        break;
//                    case "Class":
//                        result += this.propertyToString(this.InputObject.Current.ClassName);
//                        break;
//                    case "AcceleratorKey":
//                        result += this.propertyToString(this.InputObject.Current.AcceleratorKey);
//                        break;
//                    case "AccessKey":
//                        result += this.propertyToString(this.InputObject.Current.AccessKey);
//                        break;
//                    case "BoundingRectangle":
//                        result += this.propertyToString(this.InputObject.Current.BoundingRectangle.ToString());
//                        break;
//                    case "FrameworkId":
//                        result += this.propertyToString(this.InputObject.Current.FrameworkId);
//                        break;
//                    case "HasKeyboardFocus":
//                        result += this.propertyToString(this.InputObject.Current.HasKeyboardFocus.ToString());
//                        break;
//                    case "HelpText":
//                        result += this.propertyToString(this.InputObject.Current.HelpText);
//                        break;
//                    case "IsContentElement":
//                        result += this.propertyToString(this.InputObject.Current.IsContentElement.ToString());
//                        break;
//                    case "IsControlElement":
//                        result += this.propertyToString(this.InputObject.Current.IsControlElement.ToString());
//                        break;
//                    case "IsEnabled":
//                        result += this.propertyToString(this.InputObject.Current.IsEnabled.ToString());
//                        break;
//                    case "IsKeyboardFocusable":
//                        result += this.propertyToString(this.InputObject.Current.IsKeyboardFocusable.ToString());
//                        break;
//                    case "IsOffscreen":
//                        result += this.propertyToString(this.InputObject.Current.IsOffscreen.ToString());
//                        break;
//                    case "IsPassword":
//                        result += this.propertyToString(this.InputObject.Current.IsPassword.ToString());
//                        break;
//                    case "IsRequiredForForm":
//                        result += this.propertyToString(this.InputObject.Current.IsRequiredForForm.ToString());
//                        break;
//                    case "ItemStatus":
//                        result += this.propertyToString(this.InputObject.Current.ItemStatus);
//                        break;
//                    case "ItemType":
//                        result += this.propertyToString(this.InputObject.Current.ItemType);
//                        break;
//                    //case "LabeledBy":
//                    //    result += 
//                    //    break;
//                    case "LocalizedControlType":
//                        result += this.propertyToString(this.InputObject.Current.LocalizedControlType);
//                        break;
//                    case "NativeWindowHandle":
//                        result += this.propertyToString(this.InputObject.Current.NativeWindowHandle.ToString());
//                        break;
//                    case "Orientation":
//                        result += this.propertyToString(this.InputObject.Current.Orientation.ToString());
//                        break;
//                    case "ProcessId":
//                        result += this.propertyToString(this.InputObject.Current.ProcessId.ToString());
//                        break;
//                }
#endregion commented

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

            /*
            if (resultString != null &&
                     resultString != string.Empty &&
                     resultString.Length > 0) {
                if (resultString.Substring(resultString.Length - 1) != "{" &&
                    resultString.Substring(resultString.Length - 1) != ";") {
                    result = ";" + result;
                }
            }
            */

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
