/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 5:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.CheckCmdletParameters
{
    using System;
    using Tmx;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of NewTLTestPlanCommand.
    /// </summary>
    [TestFixture]
    public class NewTLTestPlanCommandTestFixture
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
        //[Ignore("for later demystification")]
        public void New_TLTestPlan_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan;");
        }
        
        [Test]
        [Category("Fast")]
        //[Ignore("for later demystification")]
        public void New_TLTestPlan_Name_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName plan01;");
        }
        
        [Test]
        [Category("Fast")]
        //[Ignore("for later demystification")]
        public void New_TLTestPlan_Name_Description()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr;");
        }
        
        [Test]
        [Category("Fast")]
        //[Ignore("for later demystification")]
        public void New_TLTestPlan_Name_Active()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Active;");
        }
        
        [Test]
        [Category("Fast")]
        //[Ignore("for later demystification")]
        public void New_TLTestPlan_Name_Active_Description()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr -Active;");
        }
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_Name_Description_TestProjectName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr -TestProjectName proj;");
        }
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_Name_Active_TestProjectName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Active -TestProjectName proj;");
        }
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_Name_Active_Description_TestProjectName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr -Active -TestProjectName proj;");
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -InputObject (Get-TLProject -Name prj);");
        }
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_Name_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName plan01 -InputObject (Get-TLProject -Name prj);");
        }
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_Name_Description_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr -InputObject (Get-TLProject -Name prj);");
        }
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_Name_Active_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Active -InputObject (Get-TLProject -Name prj);");
        }
        
        [Test]
        [Category("Fast")]
        public void New_TLTestPlan_Name_Active_Description_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr -Active -InputObject (Get-TLProject -Name prj);");
        }
        
//        [Test]
//        [Category("Fast")]
//        public void New_TLTestPlan_Name_Description_TestProjectName_InputObject() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr -TestProjectName proj -InputObject $null;");
//        }
        
//        [Test]
//        [Category("Fast")]
//        public void New_TLTestPlan_Name_Active_TestProjectName_InputObject() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-TLTestPlan -TestPlanName testplan20121119 -Active -TestProjectName proj -InputObject $null;");
//        }
        
//        [Test]
//        [Category("Fast")]
//        public void New_TLTestPlan_Name_Active_Description_TestProjectName_InputObject() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-TLTestPlan -TestPlanName testplan20121119 -Description descr -Active -TestProjectName proj -InputObject $null;");
//        }
    }
}
