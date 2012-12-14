/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.CheckParameters
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
        public void Get_TLProject_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLProject;");
        }
        
        [Test]
        public void Get_TLProject_Name_Implicitly()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLProject project;");
        }
        
        [Test]
        public void Get_TLProject_Name_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLProject -Name project;");
        }
        
        [Test]
        public void Get_TLProject_Id_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLProject -Id 111;");
        }
        
//        [Test]
//        public void Get_TLProject_Name_Id() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//        		"Get-TLProject -Name proj01 -Id 333;");
//        }
        
        [Test]
        public void Get_TLProject_NameArray_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLProject -Name project01,project02;");
        }
    }
}
