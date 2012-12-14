/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-03
 * Time: 05:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    //using OpenQA.Selenium.Support.UI;
    
    /// <summary>
    /// Description of SetSeSelectionCommand.
    /// </summary>
    [TestFixture]
    public class SetSeSelectionCommandTestFixture
    {
        public SetSeSelectionCommandTestFixture()
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
//                "Set-SeSelection -InputObject $null;");
//        }
        
        [Test]
        public void InputObject_Index()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -Index 1;");
        }
        
        [Test]
        public void InputObject_Value()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -Value 'aaa';");
        }
        
        [Test]
        public void InputObject_VisibleText()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -VisibleText 'bbb';");
        }
        
        [Test]
        public void InputObject_All()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -All;");
        }
        
        [Test]
        public void InputObject_Index_Deselect()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -Index 1 -Deselect;");
        }
        
        [Test]
        public void InputObject_Value_Deselect()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -Value 'aaa' -Deselect;");
        }
        
        [Test]
        public void InputObject_VisibleText_Deselect()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -VisibleText 'bbb' -Deselect;");
        }
        
        [Test]
        public void InputObject_All_Deselect()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -InputObject $null -All -Deselect;");
        }
        
        [Test]
        public void NoInputObject_Index()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Set-SeSelection -Index 1;");
        }
    }
}
