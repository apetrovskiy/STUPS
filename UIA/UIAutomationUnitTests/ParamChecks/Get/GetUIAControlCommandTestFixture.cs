/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2013
 * Time: 12:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using System;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetUIAControlCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetUIAControlCommandTestFixture
    {
        public GetUIAControlCommandTestFixture()
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
        public void Get_UIAControl_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAControl_ControlType()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl -ControlType Button;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAControl_Name()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl -Name 'aaa';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAControl_ControlType_Name()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl -ControlType Button -Name 'aaa';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAControl_AutomationId()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl -AutomationId '111';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAControl_ControlType_AutomationId()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl -ControlType Button -AutomationId '111';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAControl_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl -Class 'class';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAControl_ControlType_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAControl -ControlType Button -Class 'class';");
        }
    }
}
