/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/12/2014
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of WaitControlIsEnabled.
    /// </summary>
    public class WaitControlIsEnabledCommand : UiaCommand
    {
        public WaitControlIsEnabledCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
            
        }
        
        public override void Execute()
        {
            var cmdlet = (WaitUiaControlIsEnabledCommand)Cmdlet;
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
                
                // 20140312
                // if (!Equals(cmdlet.ControlType, inputObject.Current.ControlType)) {
                if (!Equals(cmdlet.ControlType, inputObject.GetCurrent().ControlType)) {
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "Control is not of " +
                         cmdlet.ControlType.ProgrammaticName +
                         " type",
                        "WrongControlType",
                        ErrorCategory.InvalidArgument,
                        true);
                    
                }
    
                try {
                    cmdlet.WaitIfCondition(inputObject, true);
                }
                catch (Exception eWaitIfCondition) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to get enabled control. " +
                        eWaitIfCondition.Message,
                        "FailedToGetEnabledControl",
                        ErrorCategory.InvalidOperation,
                        true);
                }
    
                cmdlet.WriteObject(cmdlet, inputObject);
                
            }
        }
    }
}
