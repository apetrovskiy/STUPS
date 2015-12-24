/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/29/2012
 * Time: 11:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToDefaultContentCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToDefaultContent")]
    [OutputType(typeof(IWebDriver))]
    public class SwitchSeToDefaultContentCommand : NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToDefaultContentCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            SeHelper.SwitchToDefaultContent(this, InputObject);
        }
    }
}
