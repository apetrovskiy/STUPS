/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/30/2012
 * Time: 12:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToAlertCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToAlert")]
    [OutputType(typeof(IAlert))]
    public class SwitchSeToAlertCommand : NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToAlertCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeHelper.SwitchToAlert(this, this.InputObject);
        }
    }
}
