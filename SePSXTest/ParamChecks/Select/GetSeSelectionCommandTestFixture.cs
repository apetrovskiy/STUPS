/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-02
 * Time: 00:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeSelectionCommand.
    /// </summary>
    [TestFixture]
    public class GetSeSelectionCommandTestFixture
    {
        public GetSeSelectionCommandTestFixture()
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
//        public void InputObject_NoParameters() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Get-SeSelection -InputObject $null;");
//        }
        
        [Test]
        public void InputObject_FirstSelected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Get-SeSelection -InputObject $null -FirstSelected;");
        }
        
        [Test]
        public void InputObject_Selected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Get-SeSelection -InputObject $null -Selected;");
        }
        
        [Test]
        public void InputObject_All()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Get-SeSelection -InputObject $null -All;");
        }
        
        [Test]
        public void NoInputObject_FirstSelected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Get-SeSelection -FirstSelected;");
        }
        
        [Test]
        public void NoInputObject_Selected()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Get-SeSelection -Selected;");
        }
        
        [Test]
        public void NoInputObject_All()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Get-SeSelection -All;");
        }
    }
}
