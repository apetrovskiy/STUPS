/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 8:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeWebDriverCommand.
    /// </summary>
    [TestFixture]
    public class StartSeWebDriverCommandTestFixture // StartDriverCmdletBase //DriverCmdletBase
    {
        public StartSeWebDriverCommandTestFixture()
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
        public void Chrome_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName chrome;");
        }
        
        [Test]
        public void Chrome_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName chrome -InstanceName aaa;");
        }
        
        [Test]
        public void Ch_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ch;");
        }
        
        [Test]
        public void Ch_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ch -InstanceName aaa;");
        }
        
        [Test]
        public void Firefox_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName Firefox;");
        }
        
        [Test]
        public void Firefox_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName Firefox -InstanceName aaa;");
        }
        
        [Test]
        public void FF_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ff;");
        }
        
        [Test]
        public void FF_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ff -InstanceName aaa;");
        }
        
        [Test]
        public void InternetExplorer32_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName InternetExplorer32;");
        }
        
        [Test]
        public void InternetExplorer32_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName InternetExplorer32 -InstanceName aaa;");
        }
        
        [Test]
        public void IE32_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ie32;");
        }
        
        [Test]
        public void IE32_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ie32 -InstanceName aaa;");
        }
        
        [Test]
        public void InternetExplorer64_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName InternetExplorer64;");
        }
        
        [Test]
        public void InternetExplorer64_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName InternetExplorer64 -InstanceName aaa;");
        }
        
        [Test]
        public void IE64_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ie64;");
        }
        
        [Test]
        public void IE64_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeWebDriver -DriverName ie64 -InstanceName aaa;");
        }
    }
}
