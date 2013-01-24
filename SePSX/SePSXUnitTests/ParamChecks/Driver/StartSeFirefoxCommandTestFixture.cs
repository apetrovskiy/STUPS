/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 3:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeFirefoxCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeFirefoxCommand_ParamCheck
    {
        public StartSeFirefoxCommand_ParamCheck()
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
        public void Firefox_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeFirefox;");
        }
        
        [Test]
        [Category("Fast")]
        public void Firefox_Profile()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeFirefox -Profile $null;"); //(New-SeFirefoxProfile);");
        }
        
        [Test]
        [Category("Fast")]
        public void Firefox_Capabilities()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeFirefox -Capabilities $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void Firefox_Binary_Profile()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeFirefox -Binary $null -Profile $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void Firefox_Binary_Profile_Timeout()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Start-SeFirefox -Binary $null -Profile $null -Timeout 10000;");
        }
    }
}
