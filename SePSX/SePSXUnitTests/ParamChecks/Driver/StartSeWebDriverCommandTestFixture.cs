/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 8:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeWebDriverCommand.
    /// </summary>
    [TestFixture]
    public class StartSeWebDriverCommand_ParamCheck // StartDriverCmdletBase //DriverCmdletBase
    {
        public StartSeWebDriverCommand_ParamCheck()
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
        public void Chrome_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName chrome;");
        }
        
        [Test]
        [Category("Fast")]
        public void Chrome_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName chrome -InstanceName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void Ch_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ch;");
        }
        
        [Test]
        [Category("Fast")]
        public void Ch_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ch -InstanceName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void Firefox_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName Firefox;");
        }
        
        [Test]
        [Category("Fast")]
        public void Firefox_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName Firefox -InstanceName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void FF_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ff;");
        }
        
        [Test]
        [Category("Fast")]
        public void FF_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ff -InstanceName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void InternetExplorer32_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName InternetExplorer32;");
        }
        
        [Test]
        [Category("Fast")]
        public void InternetExplorer32_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName InternetExplorer32 -InstanceName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void IE32_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ie32;");
        }
        
        [Test]
        [Category("Fast")]
        public void IE32_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ie32 -InstanceName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void InternetExplorer64_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName InternetExplorer64;");
        }
        
        [Test]
        [Category("Fast")]
        public void InternetExplorer64_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName InternetExplorer64 -InstanceName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void IE64_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ie64;");
        }
        
        [Test]
        [Category("Fast")]
        public void IE64_WithInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeWebDriver -DriverName ie64 -InstanceName aaa;");
        }
    }
}
