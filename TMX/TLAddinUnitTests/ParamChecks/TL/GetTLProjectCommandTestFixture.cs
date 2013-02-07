/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.CheckCmdletParameters
{
    using System;
    using TMX;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetTLProjectCommand.
    /// </summary>
    [TestFixture]
    public class GetTLProjectCommandTestFixture
    {
        public GetTLProjectCommandTestFixture()
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
        [Category("Fast")]
        public void Get_TLProject_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
        		"Get-TLProject;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLProject_Name_Implicitly()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
        		"Get-TLProject project;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLProject_Name_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
        		"Get-TLProject -Name project;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLProject_Id_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
        		"Get-TLProject -Id 111;");
        }
        
//        [Test]
//        [Category("Fast")]
//        public void Get_TLProject_Name_Id() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Get-TLProject -Name proj01 -Id 333;");
//        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLProject_NameArray_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
        		"Get-TLProject -Name project01,project02;");
        }
    }
}
