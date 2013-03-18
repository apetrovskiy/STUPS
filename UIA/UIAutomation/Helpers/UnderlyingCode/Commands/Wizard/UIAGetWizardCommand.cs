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
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UIAGetWizardCommand.
    /// </summary>
    internal class UIAGetWizardCommand : UIACommand
    {
        internal UIAGetWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            GetUIAWizardCommand cmdlet =
                (GetUIAWizardCommand)this.Cmdlet;

            WizardHelper.GetWizard(cmdlet);
        }
    }
}
