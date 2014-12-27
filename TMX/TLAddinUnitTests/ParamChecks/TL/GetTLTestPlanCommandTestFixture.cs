/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.CheckCmdletParameters
{
    using System;
    using Tmx;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetTLTestPlanCommand.
    /// </summary>
    [TestFixture]
    public class GetTLTestPlanCommandTestFixture
    {
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
        //[Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan;");
        }
        
        [Test]
        [Category("Fast")]
        //[Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_Name_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestPlanName 'test plan 001';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLTestPlan_Name_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestPlanName 'test plan 001' -InputObject (Get-TLProject -Name prj);");
        }
        
        [Test]
        [Category("Fast")]
        //[Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_TestPlanName_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestPlanName 'test plan 001';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLTestPlan_TestPlanName_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestPlanName 'test plan 001' -InputObject (Get-TLProject -Name prj);");
        }
        
//        [Test]
//        [Category("Fast")]
//        public void Get_TLTestPlan_Id_Only()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Get-TLProject -Id 111;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void Get_TLTestPlan_Name_Id()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Get-TLProject -TestPlanName proj01 -Id 333;");
//        }
        
        [Test]
        [Category("Fast")]
        //[Ignore("unable to emulate the TestLink store object")]
        public void Get_TLTestPlan_NameArray_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestPlanName plan01,plan02;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLTestPlan_TestProjectName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestProjectName prj01;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLTestPlan_Name_TestProjectName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestPlanName 'test plan 001' -TestProjectName prj01;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLTestPlan_Name_TestProjectNameArray()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLTestPlan -TestPlanName 'test plan 001' -TestProjectName prj01,prj02;");
        }
    }
}
