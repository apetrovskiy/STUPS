/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/30/2012
 * Time: 12:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToAlertCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToAlert")]
    [OutputType(typeof(IAlert))]
    public class SwitchSeToAlertCommandTestFixture // NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToAlertCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeHelper.SwitchToAlert(this, this.InputObject);
        }
    }
}
