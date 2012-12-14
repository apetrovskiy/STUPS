/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.CheckParameters
{
    using System;
    using TMX;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetTLTestPlanCommand.
    /// </summary>
    [TestFixture]
    public class GetTLTestPlanCommandTestFixture
    {
        public GetTLTestPlanCommandTestFixture()
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
        [Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan;");
        }
        
        [Test]
        [Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_Name_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestPlanName 'test plan 001';");
        }
        
        [Test]
        public void Get_TLTestPlan_Name_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestPlanName 'test plan 001' -InputObject (Get-TLProject -Name prj);");
        }
        
        [Test]
        [Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_TestPlanName_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestPlanName 'test plan 001';");
        }
        
        [Test]
        public void Get_TLTestPlan_TestPlanName_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestPlanName 'test plan 001' -InputObject (Get-TLProject -Name prj);");
        }
        
//        [Test]
//        public void Get_TLTestPlan_Id_Only()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//        		"Get-TLProject -Id 111;");
//        }
//        
//        [Test]
//        public void Get_TLTestPlan_Name_Id()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//        		"Get-TLProject -TestPlanName proj01 -Id 333;");
//        }
        
        [Test]
        [Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_NameArray_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestPlanName plan01,plan02;");
        }
        
        [Test]
        public void Get_TLTestPlan_TestProjectName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestProjectName prj01;");
        }
        
        [Test]
        public void Get_TLTestPlan_Name_TestProjectName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestPlanName 'test plan 001' -TestProjectName prj01;");
        }
        
        [Test]
        public void Get_TLTestPlan_Name_TestProjectNameArray()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Get-TLTestPlan -TestPlanName 'test plan 001' -TestProjectName prj01,prj02;");
        }
    }
}
