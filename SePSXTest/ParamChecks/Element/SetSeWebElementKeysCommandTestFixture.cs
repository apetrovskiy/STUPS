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
    /// Description of SetSeWebElementKeysCommand.
    /// </summary>
    [TestFixture]
    public class SetSeWebElementKeysCommandTestFixture
    {
        public SetSeWebElementKeysCommandTestFixture()
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
//        public void InputObject_NoText() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Set-SeWebElementKeys " +
//                "-InputObject ([SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
//        }
        
        [Test]
        public void InputObject_Text()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeWebElementKeys " +
                "-InputObject ([SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement()) " +
                "-Text aaa;");
        }
        
        [Test]
        public void NoInputObject_Text()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "[SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Set-SeWebElementKeys aaa;");
        }
    }
}
