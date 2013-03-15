/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementAttributeCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebElementAttributeCommand_ParamCheck
    {
        public ReadSeWebElementAttributeCommand_ParamCheck()
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
//        public void InputObject_NoAttributeName() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Read-SeWebElementAttribute " +
//                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
//        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementAttribute_InputObject_AttributeName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Read-SeWebElementAttribute " +
                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement()) " +
                "-AttributeName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementAttribute_NoInputObject_AttributeName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "[SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Read-SeWebElementAttribute -AttributeName aaa;");
        }
    }
}
