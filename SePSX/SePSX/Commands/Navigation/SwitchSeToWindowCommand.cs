/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 11:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToWindow")]
    [OutputType(typeof(IWebDriver))]
    public class SwitchSeToWindowCommand : NavigationCmdletBase
    {
        public SwitchSeToWindowCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string WindowName { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            //SeHelper.SwitchToWindow(this, ((IWebDriver[])this.InputObject), this.WindowName);
            SeHelper.SwitchToWindow(this, InputObject, WindowName);
        }
    }
}
