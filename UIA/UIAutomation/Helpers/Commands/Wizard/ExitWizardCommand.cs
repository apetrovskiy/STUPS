/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/14/2014
 * Time: 9:38 PM
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
    /// Description of ExitWizardCommand.
    /// </summary>
    public class ExitWizardCommand : AbstractCommand	// : UiaCommand
    {
        public ExitWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (ExitUiaWizardCommand)Cmdlet;

            cmdlet.GetWizard(cmdlet.Name).StopImmediately = true;
            
            cmdlet.WriteObject(cmdlet, true);
        }
    }
}
