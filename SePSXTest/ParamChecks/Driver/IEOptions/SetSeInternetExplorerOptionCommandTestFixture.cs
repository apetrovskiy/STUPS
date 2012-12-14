/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    
    /// <summary>
    /// Description of SetSeInternetExplorerOptionCommand.
    /// </summary>
    [TestFixture]
    public class SetSeInternetExplorerOptionCommandTestFixture // EditIEOptionsCmdletBase
    {
        public SetSeInternetExplorerOptionCommandTestFixture()
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
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        public void Set_SeInternetExplorerOption_InputObject_only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions);");
        }
        
        [Test]
        public void Set_SeInternetExplorerOption_InputObject_EnableNativeEvents()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -EnableNativeEvents;");
        }
        
        [Test]
        public void Set_SeInternetExplorerOption_InputObject_IgnoreZoomLevel()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -IgnoreZoomLevel;");
        }
        
        [Test]
        public void Set_SeInternetExplorerOption_InputObject_IntroduceInstabilityByIgnoringProtectedModeSettings()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -IntroduceInstabilityByIgnoringProtectedModeSettings;");
        }
        
        [Test]
        public void Set_SeInternetExplorerOption_InputObject_InitialBrowserUrl()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeInternetExplorerOption -InputObject (New-SeInternetExplorerOptions) -InitialBrowserUrl 'http://google.com';");
        }
    }
}
