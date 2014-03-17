/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/17/2013
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
    using Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of UiaInvokeWizardCommand.
    /// </summary>
    public class InvokeWizardCommand : AbstractCommand	// : UiaCommand
    {
        public InvokeWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (WizardRunCmdletBase)Cmdlet;
            
            WizardHelper.InvokeWizard(cmdlet);
        }
    }
}
