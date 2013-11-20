/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2013
 * Time: 2:28 AM
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
    /// Description of SetUIAEditTextCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class SetUIAEditTextCommandTestFixture
    {
        public SetUIAEditTextCommandTestFixture()
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
        [Ignore("It's difficult to learn now what is the problem with it")]
        [Description("Set-UIAEditText -Text 'text' -InputObject $obj")]
        public void Set_UIAEditText_Text()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Set-UIAEditText -Text 'text' -InputObject $obj;");
        }
        
        [Test]
        [Category("Fast")]
        [Ignore("It's difficult to learn now what is the problem with it")]
        [Description("Set-UIAEditText 'text' -InputObject $obj")]
        public void Set_UIAEditText_Text_Position0()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Set-UIAEditText 'text' -InputObject $obj;");
        }
    }
}
