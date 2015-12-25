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
    /// <summary>
    /// Description of SaveUiaScreenshotCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Save-UiaScreenshotCommand test")]
    public class SaveUiaScreenshotCommandTestFixture
    {
        public SaveUiaScreenshotCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Saving a screenshot with description")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Screenshot")]
        public void ScreenshotFile_Description()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Set-UiaFocus) ) { 1; } else { 0; }",
                "0");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
