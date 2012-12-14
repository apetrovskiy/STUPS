/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeAlertTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeAlertText")]
    [OutputType(typeof(string))]
    public class ReadSeAlertTextCommand : AlertCmdletBase
    {
        public ReadSeAlertTextCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputAlert(true);
            
            SeHelper.AlertGetText(this, this.InputObject);
        }
    }
}
