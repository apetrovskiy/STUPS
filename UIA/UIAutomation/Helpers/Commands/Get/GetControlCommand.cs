/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 1:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;
    // using Commands;
    
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of GetControlCommand.
    /// </summary>
    internal class GetControlCommand : UiaCommand
    {
        internal GetControlCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            GetUiaControlCommand cmdlet =
                (GetUiaControlCommand)Cmdlet;
            
            // WizardHelper.InvokeWizard(cmdlet);
            
            var controlSearcher =
                AutomationFactory.GetSearcherImpl<ControlSearcher>() as ControlSearcher;
            
            List<IUiElement> returnCollection =
                controlSearcher.GetElements(
                    controlSearcher.ConvertCmdletToControlSearcherData(cmdlet),
                    cmdlet.Timeout);
            
            if (null != returnCollection && 0 < returnCollection.Count) {

                cmdlet.WriteObject(cmdlet, returnCollection);
                
            } else {
                
                cmdlet.WriteError(
                    cmdlet,
                    "failed to get control in " + 
                    cmdlet.Timeout.ToString() +
                    " milliseconds by:" +
                    " title: '" +
                    cmdlet.Name +
                    "', automationId: '" + 
                    cmdlet.AutomationId + 
                    "', className: '" + 
                    cmdlet.Class +
                    "', value: '" +
                    cmdlet.Value +
                    "'.",
                    "ControlIsNull",
                    ErrorCategory.OperationTimeout,
                    true);
            }
        }
    }
}
