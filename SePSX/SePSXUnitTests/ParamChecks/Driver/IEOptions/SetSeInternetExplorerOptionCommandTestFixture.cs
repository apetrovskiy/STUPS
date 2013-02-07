/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    
    /// <summary>
    /// Description of SetSeInternetExplorerOptionCommand.
    /// </summary>
    [TestFixture]
    public class SetSeInternetExplorerOptionCommand_ParamCheck // EditIEOptionsCmdletBase
    {
        public SetSeInternetExplorerOptionCommand_ParamCheck()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace(); // 20121226
        }
        
        [Test]
        [Category("Fast")]
        public void SetSeInternetExplorerOption_InputObject_only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions);");
        }
        
        [Test]
        [Category("Fast")]
        public void SetSeInternetExplorerOption_InputObject_EnableNativeEvents()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -EnableNativeEvents;");
        }
        
        [Test]
        [Category("Fast")]
        public void SetSeInternetExplorerOption_InputObject_IgnoreZoomLevel()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -IgnoreZoomLevel;");
        }
        
        [Test]
        [Category("Fast")]
        public void SetSeInternetExplorerOption_InputObject_IntroduceInstabilityByIgnoringProtectedModeSettings()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -IntroduceInstabilityByIgnoringProtectedModeSettings;");
        }
        
        [Test]
        [Category("Fast")]
        public void SetSeInternetExplorerOption_InputObject_InitialBrowserUrl()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -InitialBrowserUrl 'http://google.com';");
        }
    }
}
