/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/29/2012
 * Time: 11:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Navigation
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SwitchSeToDefaultContentCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class SwitchSeToDefaultContentCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeSwitchToDefaultContent")]
        [Category("Slow")][Category("Firefox")]
        public void FF_SwitchToDefaultContent_Firefox()
        {
            SwitchToDefaultContent(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile07Frames1)));
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeSwitchToDefaultContent")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_SwitchToDefaultContent_Chrome()
        {
            SwitchToDefaultContent(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile07Frames1)));
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeSwitchToDefaultContent")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_SwitchToDefaultContent_IE()
        {
            SwitchToDefaultContent(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile07Frames1)));
        }
        
        public void SwitchToDefaultContent(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$html = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL + 
                @"' | Switch-SeToFrame -FrameIndex 3 | Switch-SeToDefaultContent | Get-SeWebElement -TagName 'html'; " +
                @"if ($null -ne $html) { ""1""; } else { ""0""; }",
                "1");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
