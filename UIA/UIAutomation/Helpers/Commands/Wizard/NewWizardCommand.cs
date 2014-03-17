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
    using Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of UiaNewWizardCommand.
    /// </summary>
    public class NewWizardCommand : AbstractCommand	// : UiaCommand
    {
        public NewWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (NewUiaWizardCommand)Cmdlet;
            
            WizardHelper.CreateWizard(cmdlet);
        }
    }
}
