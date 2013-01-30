/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using System.Diagnostics;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetUIADesktopCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Get-UIADesktopCommand test")]
    public class GetUIADesktopCommandTestFixture
    {
        public GetUIADesktopCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UIADesktop")]
        public void GetDesktop_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIADesktop).Current.ClassName;",
                @"#32769");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UIADesktop")]
        public void GetDesktop_ControlType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIADesktop).Current.ControlType.ProgrammaticName;",
                @"ControlType.Pane");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UIADesktop")]
        public void GetDesktop_Stored_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIADesktop; " +
                @"[UIAutomation.CurrentData]::CurrentWindow.Current.ClassName;",
                @"#32769");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UIADesktop")]
        public void GetDesktop_Stored_ControlType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIADesktop; " +
                @"[UIAutomation.CurrentData]::CurrentWindow.Current.ControlType.ProgrammaticName;",
                @"ControlType.Pane");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
