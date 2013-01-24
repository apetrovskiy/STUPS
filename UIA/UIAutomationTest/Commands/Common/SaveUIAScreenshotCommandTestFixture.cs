/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/21/2012
 * Time: 12:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of SaveUIAScreenshotCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Save-UIAScreenshotCommand test")]
    public class SaveUIAScreenshotCommandTestFixture
    {
        public SaveUIAScreenshotCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="Saving a screenshot with description")]
        [Category("Slow")][Category("NoForms")]
        [Category("Slow")][Category("Screenshot")]
        public void ScreenshotFile_Description()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Set-UIAFocus) ) { 1; } else { 0; }",
                "0");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
