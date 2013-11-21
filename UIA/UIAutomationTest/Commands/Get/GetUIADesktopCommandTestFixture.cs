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
    /// Description of GetUiaDesktopCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Get-UiaDesktopCommand test")]
    public class GetUiaDesktopCommandTestFixture
    {
        public GetUiaDesktopCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UiaDesktop")]
        public void GetDesktop_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaDesktop).Current.ClassName;",
                @"#32769");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UiaDesktop")]
        public void GetDesktop_ControlType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaDesktop).Current.ControlType.ProgrammaticName;",
                @"ControlType.Pane");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UiaDesktop")]
        public void GetDesktop_Stored_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaDesktop; " +
                @"[UIAutomation.CurrentData]::CurrentWindow.Current.ClassName;",
                @"#32769");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Get_UiaDesktop")]
        public void GetDesktop_Stored_ControlType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaDesktop; " +
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
