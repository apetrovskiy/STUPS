/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeSeAlertAcceptCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeAlertAccept")]
    [OutputType(typeof(bool))]
    public class InvokeSeAlertAcceptCommand : AlertCmdletBase
    {
        public InvokeSeAlertAcceptCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputAlert(true);
            
            SeHelper.AlertAcceptButtonClick(this, InputObject);
        }
    }
}
