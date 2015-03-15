/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 11:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Navigation
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SwitchSeToFrameCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class SwitchSeToFrameCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeSwitchToFrame")]
        [Category("Slow")][Category("Firefox")]
        public void FF_SwitchToFrame_Firefox()
        {
            SwitchToFrame(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile07Frames1)));
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeSwitchToFrame")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_SwitchToFrame_Chrome()
        {
            SwitchToFrame(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile07Frames1)));
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeSwitchToFrame")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_SwitchToFrame_IE()
        {
            SwitchToFrame(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile07Frames1)));
        }
        
        public void SwitchToFrame(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL + 
                @"' | Switch-SeToFrame -FrameIndex 3 | Get-SeWebElement -LinkText '" +
                Settings.TestFile05Controls1ElementLink01LinkText +
                "' | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementLink01LinkText);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
