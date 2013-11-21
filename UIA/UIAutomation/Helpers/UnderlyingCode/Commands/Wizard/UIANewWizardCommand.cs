/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UiaNewWizardCommand.
    /// </summary>
    internal class UiaNewWizardCommand : UiaCommand
    {
        internal UiaNewWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            NewUiaWizardCommand cmdlet =
                (NewUiaWizardCommand)this.Cmdlet;
            
            WizardHelper.CreateWizard(cmdlet);
        }
    }
}
