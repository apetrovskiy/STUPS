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
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
//            if (this.GetType().Name == "ReadUIAControlAutomationIdCommand") {
//                WriteObject(this, InputObject.Current.AutomationId);
//            }
//            if (this.GetType().Name == "ReadUIAControlClassCommand") {
//                WriteObject(this, InputObject.Current.ClassName);
//            }
//            if (this.GetType().Name == "ReadUIAControlIsDisabledCommand") {
//                WriteObject(this, !InputObject.Current.IsEnabled);
//            }
//            if (this.GetType().Name == "ReadUIAControlIsEnabledCommand") {
//                WriteObject(this, InputObject.Current.IsEnabled);
//            }
//            if (this.GetType().Name == "ReadUIAControlNameCommand") {
//                WriteObject(this, InputObject.Current.Name);
//            }
//            if (this.GetType().Name == "ReadUIAControlControlTypeCommand") {
//                WriteObject(this, InputObject.Current.ControlType.ProgrammaticName);
//            }
//            if (this.GetType().Name == "ReadUIAControlAcceleratorKeyCommand") {
//                WriteObject(this, InputObject.Current.AcceleratorKey);
//            }
//            if (this.GetType().Name == "ReadUIAControlAccessKeyCommand") {
//                WriteObject(this, InputObject.Current.AccessKey);
//            }
//            if (this.GetType().Name == "ReadUIAControlBoundingRectangleCommand") {
//                WriteObject(this, InputObject.Current.BoundingRectangle);
//            }
//            if (this.GetType().Name == "ReadUIAControlFrameworkIdCommand") {
//                WriteObject(this, InputObject.Current.FrameworkId);
//            }
//            if (this.GetType().Name == "ReadUIAControlHasKeyboardFocusCommand") {
//                WriteObject(this, InputObject.Current.HasKeyboardFocus);
//            }
//            if (this.GetType().Name == "ReadUIAControlHelpTextCommand") {
//                WriteObject(this, InputObject.Current.HelpText);
//            }
//            if (this.GetType().Name == "ReadUIAControlIsKeyboardFocusableCommand") {
//                WriteObject(this, InputObject.Current.IsKeyboardFocusable);
//            }
//            if (this.GetType().Name == "ReadUIAControlIsOffscreenCommand") {
//                WriteObject(this, InputObject.Current.IsOffscreen);
//            }
//            if (this.GetType().Name == "ReadUIAControlIsPasswordCommand") {
//                WriteObject(this, InputObject.Current.IsPassword);
//            }
//            if (this.GetType().Name == "ReadUIAControlIsRequiredForFormCommand") {
//                WriteObject(this, InputObject.Current.IsRequiredForForm);
//            }
//            if (this.GetType().Name == "ReadUIAControlItemStatusCommand") {
//                WriteObject(this, InputObject.Current.ItemStatus);
//            }
//            if (this.GetType().Name == "ReadUIAControlItemTypeCommand") {
//                WriteObject(this, InputObject.Current.ItemType);
//            }
//            if (this.GetType().Name == "ReadUIAControlLabeledByCommand") {
//                WriteObject(this, InputObject.Current.LabeledBy);
//            }
//            if (this.GetType().Name == "ReadUIAControlLocalizedControlTypeCommand") {
//                WriteObject(this, InputObject.Current.LocalizedControlType);
//            }
//            if (this.GetType().Name == "ReadUIAControlNativeWindowHandleCommand") {
//                WriteObject(this, InputObject.Current.NativeWindowHandle);
//            }
//            if (this.GetType().Name == "ReadUIAControlOrientationCommand") {
//                WriteObject(this, InputObject.Current.Orientation);
//            }
//            if (this.GetType().Name == "ReadUIAControlProcessIdCommand") {
//                WriteObject(this, InputObject.Current.ProcessId);
//            }
            
            // 20120823
            foreach (AutomationElement inputObject in InputObject) {
                if (this.GetType().Name == "ReadUIAControlAutomationIdCommand") {
                    this.WriteObject(this, inputObject.Current.AutomationId);
                }
                if (this.GetType().Name == "ReadUIAControlClassCommand") {
                    this.WriteObject(this, inputObject.Current.ClassName);
                }
                if (this.GetType().Name == "ReadUIAControlIsDisabledCommand") {
                    this.WriteObject(this, !inputObject.Current.IsEnabled);
                }
                if (this.GetType().Name == "ReadUIAControlIsEnabledCommand") {
                    this.WriteObject(this, inputObject.Current.IsEnabled);
                }
                if (this.GetType().Name == "ReadUIAControlNameCommand") {
                    this.WriteObject(this, inputObject.Current.Name);
                }
                if (this.GetType().Name == "ReadUIAControlControlTypeCommand") {
                    this.WriteObject(this, inputObject.Current.ControlType.ProgrammaticName);
                }
                if (this.GetType().Name == "ReadUIAControlAcceleratorKeyCommand") {
                    this.WriteObject(this, inputObject.Current.AcceleratorKey);
                }
                if (this.GetType().Name == "ReadUIAControlAccessKeyCommand") {
                    this.WriteObject(this, inputObject.Current.AccessKey);
                }
                if (this.GetType().Name == "ReadUIAControlBoundingRectangleCommand") {
                    this.WriteObject(this, inputObject.Current.BoundingRectangle);
                }
                if (this.GetType().Name == "ReadUIAControlFrameworkIdCommand") {
                    this.WriteObject(this, inputObject.Current.FrameworkId);
                }
                if (this.GetType().Name == "ReadUIAControlHasKeyboardFocusCommand") {
                    this.WriteObject(this, inputObject.Current.HasKeyboardFocus);
                }
                if (this.GetType().Name == "ReadUIAControlHelpTextCommand") {
                    this.WriteObject(this, inputObject.Current.HelpText);
                }
                if (this.GetType().Name == "ReadUIAControlIsKeyboardFocusableCommand") {
                    this.WriteObject(this, inputObject.Current.IsKeyboardFocusable);
                }
                if (this.GetType().Name == "ReadUIAControlIsOffscreenCommand") {
                    this.WriteObject(this, inputObject.Current.IsOffscreen);
                }
                if (this.GetType().Name == "ReadUIAControlIsPasswordCommand") {
                    this.WriteObject(this, inputObject.Current.IsPassword);
                }
                if (this.GetType().Name == "ReadUIAControlIsRequiredForFormCommand") {
                    this.WriteObject(this, inputObject.Current.IsRequiredForForm);
                }
                if (this.GetType().Name == "ReadUIAControlItemStatusCommand") {
                    this.WriteObject(this, inputObject.Current.ItemStatus);
                }
                if (this.GetType().Name == "ReadUIAControlItemTypeCommand") {
                    this.WriteObject(this, inputObject.Current.ItemType);
                }
                if (this.GetType().Name == "ReadUIAControlLabeledByCommand") {
                    this.WriteObject(this, inputObject.Current.LabeledBy);
                }
                if (this.GetType().Name == "ReadUIAControlLocalizedControlTypeCommand") {
                    this.WriteObject(this, inputObject.Current.LocalizedControlType);
                }
                if (this.GetType().Name == "ReadUIAControlNativeWindowHandleCommand") {
                    this.WriteObject(this, inputObject.Current.NativeWindowHandle);
                }
                if (this.GetType().Name == "ReadUIAControlOrientationCommand") {
                    this.WriteObject(this, inputObject.Current.Orientation);
                }
                if (this.GetType().Name == "ReadUIAControlProcessIdCommand") {
                    this.WriteObject(this, inputObject.Current.ProcessId);
                }
            }
            
        }

    }
    
    /// <summary>
    /// Description of ReadUIAControlAutomationIdCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlAutomationId")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlAutomationIdCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlAutomationIdCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlClassCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlClass")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlClassCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlClassCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlIsDisabledCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlIsDisabled")]
    // 20120828
    //[OutputType(typeof(bool[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlIsDisabledCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlIsDisabledCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlIsEnabledCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlIsEnabled")]
    // 20120828
    //[OutputType(typeof(bool[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlIsEnabledCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlIsEnabledCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlNameCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlName")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlNameCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlNameCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlControlTypeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlType")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlControlTypeCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlControlTypeCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlAcceleratorKeyCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlAcceleratorKey")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlAcceleratorKeyCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlAcceleratorKeyCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlAccessKeyCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlAccessKey")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlAccessKeyCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlAccessKeyCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlBoundingRectangleCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlBoundingRectangle")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlBoundingRectangleCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlBoundingRectangleCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlFrameworkIdCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlFrameworkIdKey")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlFrameworkIdCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlFrameworkIdCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlHasKeyboardFocusCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlHasKeyboardFocus")]
    // 20120828
    //[OutputType(typeof(bool[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlHasKeyboardFocusCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlHasKeyboardFocusCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlHelpTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlHelpText")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlHelpTextCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlHelpTextCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUIAControlIsKeyboardFocusableCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlIsKeyboardFocusable")]
    // 20120828
    //[OutputType(typeof(bool[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlIsKeyboardFocusableCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlIsKeyboardFocusableCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUIAControlIsOffscreenCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlIsOffscreen")]
    // 20120828
    //[OutputType(typeof(bool[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlIsOffscreenCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlIsOffscreenCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUIAControlIsPasswordCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlIsPassword")]
    // 20120828
    //[OutputType(typeof(bool[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlIsPasswordCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlIsPasswordCommand()
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Description of ReadUIAControlIsRequiredForFormCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlIsRequiredForForm")]
    // 20120828
    //[OutputType(typeof(bool[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlIsRequiredForFormCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlIsRequiredForFormCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlItemStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlItemStatus")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlItemStatusCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlItemStatusCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlItemTypeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlItemType")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlItemTypeCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlItemTypeCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlLabeledByCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlLabeledBy")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlLabeledByCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlLabeledByCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlLocalizedControlTypeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlLocalizedControlType")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlLocalizedControlTypeCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlLocalizedControlTypeCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlNativeWindowHandleCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlNativeWindowHandle")]
    // 20120828
    //[OutputType(typeof(int[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlNativeWindowHandleCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlNativeWindowHandleCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlOrientationCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlOrientation")]
    // 20120828
    //[OutputType(typeof(string[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlOrientationCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlOrientationCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of ReadUIAControlProcessIdCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "UIAControlProcessId")]
    // 20120828
    //[OutputType(typeof(int[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ReadUIAControlProcessIdCommand : ReadCmdletBase
    {
        #region Constructor
        public ReadUIAControlProcessIdCommand()
        {
        }
        #endregion Constructor
    }
}
