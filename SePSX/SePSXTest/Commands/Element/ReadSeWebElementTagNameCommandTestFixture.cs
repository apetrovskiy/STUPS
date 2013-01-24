/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-01
 * Time: 15:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Element
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of ReadSeWebElementTagNameCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class ReadSeWebElementTagNameCommandTestFixture
    {
        public ReadSeWebElementTagNameCommandTestFixture()
        {
        }

    
          [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="Read tag name")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementTagName")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Read_WebElement_TagName()
        {
            Read_WebElement_TagName(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Read tag name")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementTagName")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Read_WebElement_TagName()
        {
            Read_WebElement_TagName(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Read tag name")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementTagName")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Read_WebElement_TagName()
        {
            Read_WebElement_TagName(Settings.DriverNameInternetExplorer);
        }
        
        private void Read_WebElement_TagName(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementButton01Id +
                @"' | Read-SeWebElementTagName;",
                "button");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
