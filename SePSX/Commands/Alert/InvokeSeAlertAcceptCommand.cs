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
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
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
            this.checkInputAlert(true);
            
            SeHelper.AlertAcceptButtonClick(this, this.InputObject);
        }
    }
}
