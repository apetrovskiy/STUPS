/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/29/2012
 * Time: 11:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToDefaultContentCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToDefaultContent")]
    [OutputType(typeof(IWebDriver))]
    public class SwitchSeToDefaultContentCommandTestFixture // NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToDefaultContentCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeHelper.SwitchToDefaultContent(this, this.InputObject);
        }
    }
}
