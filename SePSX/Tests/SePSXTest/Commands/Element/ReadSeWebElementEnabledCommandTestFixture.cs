/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-01
 * Time: 15:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Element
{
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of ReadSeWebElementEnabledCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class ReadSeWebElementEnabledCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="Read enabled")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementEnabled")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Read_WebElement_Enabled()
        {
            Read_WebElement_Enabled(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Read enabled")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementEnabled")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Read_WebElement_Enabled()
        {
            Read_WebElement_Enabled(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Read enabled")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementEnabled")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Read_WebElement_Enabled()
        {
            Read_WebElement_Enabled(Settings.DriverNameInternetExplorer);
        }
        
        private void Read_WebElement_Enabled(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementButton01Id +
                @"' | Read-SeWebElementEnabled;",
                "True");
        }
        
        
        [Test] //[Test(Description="Read disabled")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementEnabled")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Read_WebElement_Disabled()
        {
            Read_WebElement_Disabled(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Read disabled")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementEnabled")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Read_WebElement_Disabled()
        {
            Read_WebElement_Disabled(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Read disabled")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementEnabled")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Read_WebElement_Disabled()
        {
            Read_WebElement_Disabled(Settings.DriverNameInternetExplorer);
        }
        
        private void Read_WebElement_Disabled(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect03XPath +
                @"' | Read-SeWebElementEnabled;",
                "False");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
