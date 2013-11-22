using System.Windows.Automation;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadCmdletBase.
    /// </summary>
    public class ReadCmdletBase : ReadAndConvertCmdletBase
    {
        #region Constructor
        public ReadCmdletBase()
        {
        }
        #endregion Constructor
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckAndPrepareInput(this)) { return; }
            
            // 20131109
            //foreach (AutomationElement inputObject in InputObject) {
            foreach (IMySuperWrapper inputObject in InputObject) {
                
                if (this.GetType().Name == "ReadUiaControlAutomationIdCommand") {
                    this.WriteObject(this, inputObject.Current.AutomationId);
                }
                if (this.GetType().Name == "ReadUiaControlClassCommand") {
                    this.WriteObject(this, inputObject.Current.ClassName);
                }
                if (this.GetType().Name == "ReadUiaControlIsDisabledCommand") {
                    this.WriteObject(this, !inputObject.Current.IsEnabled);
                }
                if (this.GetType().Name == "ReadUiaControlIsEnabledCommand") {
                    this.WriteObject(this, inputObject.Current.IsEnabled);
                }
                if (this.GetType().Name == "ReadUiaControlNameCommand") {
                    this.WriteObject(this, inputObject.Current.Name);
                }
                if (this.GetType().Name == "ReadUiaControlControlTypeCommand") {
                    this.WriteObject(this, inputObject.Current.ControlType.ProgrammaticName);
                }
                if (this.GetType().Name == "ReadUiaControlAcceleratorKeyCommand") {
                    this.WriteObject(this, inputObject.Current.AcceleratorKey);
                }
                if (this.GetType().Name == "ReadUiaControlAccessKeyCommand") {
                    this.WriteObject(this, inputObject.Current.AccessKey);
                }
                if (this.GetType().Name == "ReadUiaControlBoundingRectangleCommand") {
                    this.WriteObject(this, inputObject.Current.BoundingRectangle);
                }
                if (this.GetType().Name == "ReadUiaControlFrameworkIdCommand") {
                    this.WriteObject(this, inputObject.Current.FrameworkId);
                }
                if (this.GetType().Name == "ReadUiaControlHasKeyboardFocusCommand") {
                    this.WriteObject(this, inputObject.Current.HasKeyboardFocus);
                }
                if (this.GetType().Name == "ReadUiaControlHelpTextCommand") {
                    this.WriteObject(this, inputObject.Current.HelpText);
                }
                if (this.GetType().Name == "ReadUiaControlIsKeyboardFocusableCommand") {
                    this.WriteObject(this, inputObject.Current.IsKeyboardFocusable);
                }
                if (this.GetType().Name == "ReadUiaControlIsOffscreenCommand") {
                    this.WriteObject(this, inputObject.Current.IsOffscreen);
                }
                if (this.GetType().Name == "ReadUiaControlIsPasswordCommand") {
                    this.WriteObject(this, inputObject.Current.IsPassword);
                }
                if (this.GetType().Name == "ReadUiaControlIsRequiredForFormCommand") {
                    this.WriteObject(this, inputObject.Current.IsRequiredForForm);
                }
                if (this.GetType().Name == "ReadUiaControlItemStatusCommand") {
                    this.WriteObject(this, inputObject.Current.ItemStatus);
                }
                if (this.GetType().Name == "ReadUiaControlItemTypeCommand") {
                    this.WriteObject(this, inputObject.Current.ItemType);
                }
                if (this.GetType().Name == "ReadUiaControlLabeledByCommand") {
                    this.WriteObject(this, inputObject.Current.LabeledBy);
                }
                if (this.GetType().Name == "ReadUiaControlLocalizedControlTypeCommand") {
                    this.WriteObject(this, inputObject.Current.LocalizedControlType);
                }
                if (this.GetType().Name == "ReadUiaControlNativeWindowHandleCommand") {
                    this.WriteObject(this, inputObject.Current.NativeWindowHandle);
                }
                if (this.GetType().Name == "ReadUiaControlOrientationCommand") {
                    this.WriteObject(this, inputObject.Current.Orientation);
                }
                if (this.GetType().Name == "ReadUiaControlProcessIdCommand") {
                    this.WriteObject(this, inputObject.Current.ProcessId);
                }
            }
            
        }

    }
    
    /// <summary>
    /// Description of ReadUiaControlAutomationIdCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlAutomationId")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlAutomationIdCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlAutomationIdCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlClassCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlClass")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlClassCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlClassCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlIsDisabledCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlIsDisabled")]
    //[OutputType(typeof(bool[]))]
    
    public class ReadUiaControlIsDisabledCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlIsDisabledCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlIsEnabledCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlIsEnabled")]
    //[OutputType(typeof(bool[]))]
    
    public class ReadUiaControlIsEnabledCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlIsEnabledCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlNameCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlName")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlNameCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlNameCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlControlTypeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlType")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlControlTypeCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlControlTypeCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlAcceleratorKeyCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlAcceleratorKey")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlAcceleratorKeyCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlAcceleratorKeyCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlAccessKeyCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlAccessKey")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlAccessKeyCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlAccessKeyCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlBoundingRectangleCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlBoundingRectangle")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlBoundingRectangleCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlBoundingRectangleCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlFrameworkIdCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlFrameworkIdKey")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlFrameworkIdCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlFrameworkIdCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlHasKeyboardFocusCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlHasKeyboardFocus")]
    //[OutputType(typeof(bool[]))]
    
    public class ReadUiaControlHasKeyboardFocusCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlHasKeyboardFocusCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlHelpTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlHelpText")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlHelpTextCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlHelpTextCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUiaControlIsKeyboardFocusableCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlIsKeyboardFocusable")]
    //[OutputType(typeof(bool[]))]
    
    public class ReadUiaControlIsKeyboardFocusableCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlIsKeyboardFocusableCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUiaControlIsOffscreenCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlIsOffscreen")]
    //[OutputType(typeof(bool[]))]
    
    public class ReadUiaControlIsOffscreenCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlIsOffscreenCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUiaControlIsPasswordCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlIsPassword")]
    //[OutputType(typeof(bool[]))]
    
    public class ReadUiaControlIsPasswordCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlIsPasswordCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUiaControlIsRequiredForFormCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlIsRequiredForForm")]
    //[OutputType(typeof(bool[]))]
    
    public class ReadUiaControlIsRequiredForFormCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlIsRequiredForFormCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlItemStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlItemStatus")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlItemStatusCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlItemStatusCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlItemTypeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlItemType")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlItemTypeCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlItemTypeCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlLabeledByCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlLabeledBy")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlLabeledByCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlLabeledByCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlLocalizedControlTypeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlLocalizedControlType")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlLocalizedControlTypeCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlLocalizedControlTypeCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlNativeWindowHandleCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlNativeWindowHandle")]
    //[OutputType(typeof(int[]))]
    
    public class ReadUiaControlNativeWindowHandleCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlNativeWindowHandleCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlOrientationCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlOrientation")]
    //[OutputType(typeof(string[]))]
    
    public class ReadUiaControlOrientationCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlOrientationCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUiaControlProcessIdCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UiaControlProcessId")]
    //[OutputType(typeof(int[]))]
    
    public class ReadUiaControlProcessIdCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUiaControlProcessIdCommand()
        {
        }
        #endregion Constructor
    }
}
