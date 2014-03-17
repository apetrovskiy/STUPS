/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/18/2013
 * Time: 2:14 PM
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
    /// Description of UiaGetWizardCommand.
    /// </summary>
    public class GetWizardCommand : AbstractCommand	// : UiaCommand
    {
        public GetWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (GetUiaWizardCommand)Cmdlet;

            WizardHelper.GetWizard(cmdlet);
        }
    }
}
