/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Navigation
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeSePageRefreshCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class InvokeSePageRefreshCommandTestFixture
    {
        public InvokeSePageRefreshCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SePageRefresh")]
        [Category("Slow")][Category("Firefox")]
        public void FF_PageRefresh_Firefox()
        {
            PageRefresh(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SePageRefresh")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_PageRefresh_Chrome()
        {
            PageRefresh(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        [Test] //[Test(Description="The page refresh test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SePageRefresh")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_PageRefresh_IE()
        {
            PageRefresh(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        public void PageRefresh(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL +
                @"' | Invoke-SePageRefresh; " +
                "Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementLink01XPath + 
                @"' | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementLink01LinkText);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
