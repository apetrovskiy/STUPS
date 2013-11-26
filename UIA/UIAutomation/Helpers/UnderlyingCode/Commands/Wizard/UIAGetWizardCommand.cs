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
    
    /// <summary>
    /// Description of UiaGetWizardCommand.
    /// </summary>
    internal class UiaGetWizardCommand : UiaCommand
    {
        internal UiaGetWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            GetUiaWizardCommand cmdlet =
                (GetUiaWizardCommand)Cmdlet;

            WizardHelper.GetWizard(cmdlet);
        }
    }
}
