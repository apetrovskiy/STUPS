/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeAlertDismissCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeAlertDismiss")]
    [OutputType(typeof(bool))]
    public class InvokeSeAlertDismissCommand : AlertCmdletBase
    {
        public InvokeSeAlertDismissCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputAlert(true);
            
            SeHelper.AlertDismissButtonClick(this, this.InputObject);
        }
    }
}
