/*
 * Created by SharpDevelop.
 * User: Alexander
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
        	//InvokeUIAWizardCommand cmdlet =
        	//	(InvokeUIAWizardCommand)this.Cmdlet;
        	
        	WizardRunCmdletBase cmdlet =
        		(WizardRunCmdletBase)this.Cmdlet;
Console.WriteLine("exec 000001");
            //Wizard wzd = GetWizard(Name);
            Wizard wzd = cmdlet.GetWizard(cmdlet.Name);
Console.WriteLine("exec 000002");
            //if (wzd == null) {
            if (null == wzd) {
Console.WriteLine("exec 000003");
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("Couldn't get the wizard you asked for"),
//                        "NoSuchWizard",
//                        ErrorCategory.InvalidArgument,
//                        Name);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Failed to get the wizard you asked for");
//                //ThrowTerminatingError(err);
//                this.WriteError(this, err, true);
                
                cmdlet.WriteError(
                	cmdlet,
                	"Couldn't get the wizard you asked for",
                	"NoSuchWizard",
                	ErrorCategory.InvalidArgument,
                	true);
            } else {
Console.WriteLine("exec 000004");
            	// 20130317
            	wzd.Automatic = cmdlet.Automatic;
            	wzd.ForwardDirection = cmdlet.ForwardDirection;
Console.WriteLine("exec 000005");
                //this.WriteVerbose(this, "running script blocks");
                cmdlet.WriteVerbose(cmdlet, "running script blocks");
                //RunWizardScriptBlocks(this, wzd);
                cmdlet.RunWizardStartScriptBlocks(cmdlet, wzd);
Console.WriteLine("exec 000006");
                
                // 20130317
                cmdlet.RunWizardInAutomaticMode(cmdlet, wzd);
Console.WriteLine("exec 000007");
                //if (PassThru) {
                //this.WriteObject(this, wzd);
                cmdlet.WriteObject(cmdlet, wzd);
                //} else {
                // WriteObject(this, true);
                //}
            }
        }
    }
}
