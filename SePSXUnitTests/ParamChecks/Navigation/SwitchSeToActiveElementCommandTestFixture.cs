/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToActiveElementCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToActiveElement")]
    [OutputType(typeof(IWebElement))]
    public class SwitchSeToActiveElementCommandTestFixture // NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToActiveElementCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeHelper.SwitchToActiveElement(this, this.InputObject);
        }
    }
}
