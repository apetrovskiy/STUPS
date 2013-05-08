/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/17/2013
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UIAInvokeWizardCommand.
    /// </summary>
    internal class UIAInvokeWizardCommand : UIACommand
    {
        internal UIAInvokeWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            WizardRunCmdletBase cmdlet =
                (WizardRunCmdletBase)this.Cmdlet;
            
            WizardHelper.InvokeWizard(cmdlet);
        }
    }
}
