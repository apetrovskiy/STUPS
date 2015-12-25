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
    /// <summary>
    /// Description of GetUiaDesktopCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Get-UiaDesktopCommand test")]
    public class GetUiaDesktopCommandTestFixture
    {
        public GetUiaDesktopCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Get_UiaDesktop")]
        public void GetDesktop_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaDesktop).Current.ClassName;",
                @"#32769");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Get_UiaDesktop")]
        public void GetDesktop_ControlType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaDesktop).Current.ControlType.ProgrammaticName;",
                @"ControlType.Pane");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Get_UiaDesktop")]
        public void GetDesktop_Stored_ClassName()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaDesktop; " +
                @"[UIAutomation.CurrentData]::CurrentWindow.Current.ClassName;",
                @"#32769");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Get_UiaDesktop")]
        public void GetDesktop_Stored_ControlType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaDesktop; " +
                @"[UIAutomation.CurrentData]::CurrentWindow.Current.ControlType.ProgrammaticName;",
                @"ControlType.Pane");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
