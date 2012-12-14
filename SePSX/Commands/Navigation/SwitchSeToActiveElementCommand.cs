/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToActiveElementCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToActiveElement")]
    [OutputType(typeof(IWebElement))]
    public class SwitchSeToActiveElementCommand : NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToActiveElementCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeHelper.SwitchToActiveElement(this, this.InputObject);
        }
    }
}
