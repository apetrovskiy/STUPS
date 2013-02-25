/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 1:36 PM
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
    /// Description of WaitUIAWindowCommandTestFixture.
    /// </summary>
    public class WaitUIAWindowCommandTestFixture
    {
        public WaitUIAWindowCommandTestFixture()
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
//        [Category("Fast")]
//        public void Get_UIAWindow_NoParameters()
//        {
//            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//        		"Get-UIAWindow;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void Get_UIAWindow_ProcessName()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
//        		"Get-UIAWindow -ProcessName processName;");
//        }
    }
}
