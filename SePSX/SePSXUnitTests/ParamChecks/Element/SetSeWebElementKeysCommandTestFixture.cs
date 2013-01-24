/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SetSeWebElementKeysCommand.
    /// </summary>
    [TestFixture]
    public class SetSeWebElementKeysCommand_ParamCheck
    {
        public SetSeWebElementKeysCommand_ParamCheck()
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
        
//        [Test]
//        [Category("Fast")]
//        public void InputObject_NoText() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Set-SeWebElementKeys " +
//                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
//        }
        
        [Test]
        [Category("Fast")]
        public void InputObject_Text()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Set-SeWebElementKeys " +
                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement()) " +
                "-Text aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void NoInputObject_Text()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "[SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Set-SeWebElementKeys aaa;");
        }
    }
}
