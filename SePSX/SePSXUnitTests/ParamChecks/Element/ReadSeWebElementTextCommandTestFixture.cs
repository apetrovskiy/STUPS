/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementTextCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebElementTextCommand_ParamCheck
    {
        public ReadSeWebElementTextCommand_ParamCheck()
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
        public void ReadSeWebElementText_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "Read-SeWebElementText " +
                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementText_NoInputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "[SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Read-SeWebElementText;");
        }
    }
}
