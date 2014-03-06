/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 02:30 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections;

    /// <summary>
    /// Description of AddUiaWizardStepCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "UiaWizardStep")]
    public class AddUiaWizardStepCommand : WizardStepCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            AddWizardStepCommand command =
                new AddWizardStepCommand(this);
            command.Execute();
        }
        
    }
}
