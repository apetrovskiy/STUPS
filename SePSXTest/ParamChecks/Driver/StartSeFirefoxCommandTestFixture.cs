/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 3:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeFirefoxCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeFirefoxCommandTestFixture
    {
        public StartSeFirefoxCommandTestFixture()
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
        public void Firefox_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeFirefox;");
        }
        
        [Test]
        public void Firefox_Profile()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeFirefox -Profile $null;"); //(New-SeFirefoxProfile);");
        }
        
        [Test]
        public void Firefox_Capabilities()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeFirefox -Capabilities $null;");
        }
        
        [Test]
        public void Firefox_Binary_Profile()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeFirefox -Binary $null -Profile $null;");
        }
        
        [Test]
        public void Firefox_Binary_Profile_Timeout()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeFirefox -Binary $null -Profile $null -Timeout 10000;");
        }
    }
}
