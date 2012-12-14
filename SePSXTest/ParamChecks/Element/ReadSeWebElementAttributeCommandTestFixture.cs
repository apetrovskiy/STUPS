/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementAttributeCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebElementAttributeCommandTestFixture
    {
        public ReadSeWebElementAttributeCommandTestFixture()
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
        
//        [Test]
//        public void InputObject_NoAttributeName() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Read-SeWebElementAttribute " +
//                "-InputObject ([SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
//        }
        
        [Test]
        public void InputObject_AttributeName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Read-SeWebElementAttribute " +
                "-InputObject ([SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement()) " +
                "-AttributeName aaa;");
        }
        
        [Test]
        public void NoInputObject_AttributeName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "[SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Read-SeWebElementAttribute -AttributeName aaa;");
        }
    }
}
