/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/26/2012
 * Time: 10:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    // 20120823
    using System.Windows.Automation;

    /// <summary>
    /// Description of ConvertToUIAHashtableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UIAHashtable")]
    public class ConvertToUIAHashtableCommand : ConvertCmdletBase
    {
        /// <summary>
        ///  /// </summary>
        public ConvertToUIAHashtableCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // if (!this.CheckControl(this)) { return; }
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {

            System.Collections.Hashtable hashtable = 
                new System.Collections.Hashtable();
            
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
            
            // 20120831
            this.WriteObject(this, hashtable);
            //this.WriteObject(this, hashtable, true);
            
            } // 20120823

        }
    }
    
    /// <summary>
    /// Description of ConvertToUIASearchCriteriaCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UIASearchCriteria")]
    public class ConvertToUIASearchCriteriaCommand : ConvertCmdletBase
    {
        public ConvertToUIASearchCriteriaCommand()
        {
            System.Collections.ArrayList defaultExcludeList = 
                new System.Collections.ArrayList();
            defaultExcludeList.Add("LabeledBy");
            defaultExcludeList.Add("NativeWindowHandle");
            defaultExcludeList.Add("ProcessId");
            this.Exclude = (string[])defaultExcludeList.ToArray(typeof(string));
            System.Collections.ArrayList defaultIncludeList = 
                new System.Collections.ArrayList();
            defaultIncludeList.Add("Name");
            defaultIncludeList.Add("AutomationId");
            defaultIncludeList.Add("ControlType");
            this.Include = (string[])defaultIncludeList.ToArray(typeof(string));
            this.Full = false;
            
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
        private AutomationElement currentInputObject = null;
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {
                // 20120823
                currentInputObject = inputObject;
            
            if (this.Full) {
                //this.Exclude = null;
                this.Exclude =
                    (string[])(new System.Collections.ArrayList()).ToArray(typeof(string));
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

            result += getPropertyCompleteString(result, "Name");
            result += getPropertyCompleteString(result, "AutomationId");
            result += getPropertyCompleteString(result, "ControlType");
            result += getPropertyCompleteString(result, "Class");
            result += getPropertyCompleteString(result, "AcceleratorKey");
            result += getPropertyCompleteString(result, "AccessKey");
            result += getPropertyCompleteString(result, "BoundingRectangle");
            result += getPropertyCompleteString(result, "FrameworkId");
            result += getPropertyCompleteString(result, "HasKeyboardFocus");
            result += getPropertyCompleteString(result, "HelpText");
            result += getPropertyCompleteString(result, "IsContentElement");
            result += getPropertyCompleteString(result, "IsControlElement");
            result += getPropertyCompleteString(result, "IsEnabled");
            result += getPropertyCompleteString(result, "IsKeyboardFocusable");
            result += getPropertyCompleteString(result, "IsOffscreen");
            result += getPropertyCompleteString(result, "IsPassword");
            result += getPropertyCompleteString(result, "IsRequiredForForm");
            result += getPropertyCompleteString(result, "ItemStatus");
            result += getPropertyCompleteString(result, "ItemType");
            //result += getPropertyCompleteString(result, "LabeledBy");
            result += getPropertyCompleteString(result, "LocalizedControlType");
            result += getPropertyCompleteString(result, "NativeWindowHandle");
            result += getPropertyCompleteString(result, "Orientation");
            result += getPropertyCompleteString(result, "ProcessId");
            // 20130127
            result += getPatternStrings();

            result += "}";
            WriteObject(this, result);
            
            } // 20120823
            
        }
        
        private string getPatternStrings()
        {
            string result = string.Empty;
            
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
        
        private string getPropertyCompleteString(
            string resultString,
            string propertyName)
        {
            string result = string.Empty;
            
            if ((this.Full) ||
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
                        result += this.propertyToString(currentInputObject.Current.Name);
                        break;
                    case "AutomationId":
                        result += this.propertyToString(currentInputObject.Current.AutomationId);
                        break;
                    case "ControlType":
                        result += this.propertyToString(currentInputObject.Current.ControlType.ProgrammaticName.Substring(12));
                        break;
                    case "Class":
                        result += this.propertyToString(currentInputObject.Current.ClassName);
                        break;
                    case "AcceleratorKey":
                        result += this.propertyToString(currentInputObject.Current.AcceleratorKey);
                        break;
                    case "AccessKey":
                        result += this.propertyToString(currentInputObject.Current.AccessKey);
                        break;
                    case "BoundingRectangle":
                        result += this.propertyToString(currentInputObject.Current.BoundingRectangle.ToString());
                        break;
                    case "FrameworkId":
                        result += this.propertyToString(currentInputObject.Current.FrameworkId);
                        break;
                    case "HasKeyboardFocus":
                        result += this.propertyToString(currentInputObject.Current.HasKeyboardFocus.ToString());
                        break;
                    case "HelpText":
                        result += this.propertyToString(currentInputObject.Current.HelpText);
                        break;
                    case "IsContentElement":
                        result += this.propertyToString(currentInputObject.Current.IsContentElement.ToString());
                        break;
                    case "IsControlElement":
                        result += this.propertyToString(currentInputObject.Current.IsControlElement.ToString());
                        break;
                    case "IsEnabled":
                        result += this.propertyToString(currentInputObject.Current.IsEnabled.ToString());
                        break;
                    case "IsKeyboardFocusable":
                        result += this.propertyToString(currentInputObject.Current.IsKeyboardFocusable.ToString());
                        break;
                    case "IsOffscreen":
                        result += this.propertyToString(currentInputObject.Current.IsOffscreen.ToString());
                        break;
                    case "IsPassword":
                        result += this.propertyToString(currentInputObject.Current.IsPassword.ToString());
                        break;
                    case "IsRequiredForForm":
                        result += this.propertyToString(currentInputObject.Current.IsRequiredForForm.ToString());
                        break;
                    case "ItemStatus":
                        result += this.propertyToString(currentInputObject.Current.ItemStatus);
                        break;
                    case "ItemType":
                        result += this.propertyToString(currentInputObject.Current.ItemType);
                        break;
                    //case "LabeledBy":
                    //    result += 
                    //    break;
                    case "LocalizedControlType":
                        result += this.propertyToString(currentInputObject.Current.LocalizedControlType);
                        break;
                    case "NativeWindowHandle":
                        result += this.propertyToString(currentInputObject.Current.NativeWindowHandle.ToString());
                        break;
                    case "Orientation":
                        result += this.propertyToString(currentInputObject.Current.Orientation.ToString());
                        break;
                    case "ProcessId":
                        result += this.propertyToString(currentInputObject.Current.ProcessId.ToString());
                        break;
                }
            }
            
            if (resultString != null &&
                     resultString != string.Empty &&
                     resultString.Length > 0) {
                if (resultString.Substring(resultString.Length - 1) != "{" &&
                    resultString.Substring(resultString.Length - 1) != ";") {
                    result = ";" + result;
                }
            }
            
            return result;
        }
        
        private bool IsIncluded(string propertyName)
        {
            bool result = false;
            for (int i = 0; i < this.Include.Length; i++) {
                if (this.Include[i].ToUpper() == propertyName.ToUpper()) {
                    result = true;
                    break;
                }
            }
            return result;
        }
        
        private bool IsExcluded(string propertyName)
        {
            bool result = false;
            for (int i = 0; i < this.Exclude.Length; i++) {
                if (this.Exclude[i].ToUpper() == propertyName.ToUpper()) {
                    result = true;
                    break;
                }
            }
            return result;
        }
        
    }
}
