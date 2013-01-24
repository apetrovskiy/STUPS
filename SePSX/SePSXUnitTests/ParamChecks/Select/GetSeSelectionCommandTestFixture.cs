/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-02
 * Time: 00:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeSelectionCommand.
    /// </summary>
    [TestFixture]
    public class GetSeSelectionCommand_ParamCheck
    {
        public GetSeSelectionCommand_ParamCheck()
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
//        public void InputObject_NoParameters() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Get-SeSelection -InputObject $null;");
//        }
        
        [Test]
        [Category("Fast")]
        public void InputObject_FirstSelected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Get-SeSelection -InputObject $null -FirstSelected;");
        }
        
        [Test]
        [Category("Fast")]
        public void InputObject_Selected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Get-SeSelection -InputObject $null -Selected;");
        }
        
        [Test]
        [Category("Fast")]
        public void InputObject_All()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Get-SeSelection -InputObject $null -All;");
        }
        
        [Test]
        [Category("Fast")]
        public void NoInputObject_FirstSelected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Get-SeSelection -FirstSelected;");
        }
        
        [Test]
        [Category("Fast")]
        public void NoInputObject_Selected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Get-SeSelection -Selected;");
        }
        
        [Test]
        [Category("Fast")]
        public void NoInputObject_All()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Get-SeSelection -All;");
        }
    }
}
