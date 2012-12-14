/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementCssValueCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebElementCssValueCommandTestFixture
    {
        public ReadSeWebElementCssValueCommandTestFixture()
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
//        public void InputObject_NoPropertyName() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Read-SeWebElementCssValue " +
//                "-InputObject ([SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
//        }
        
        [Test]
        public void InputObject_PropertyName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Read-SeWebElementCssValue " +
                "-InputObject ([SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement()) " +
                "-PropertyName aaa;");
        }
        
        [Test]
        public void NoInputObject_PropertyName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "[SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Read-SeWebElementCssValue -PropertyName aaa;");
        }
    }
}
