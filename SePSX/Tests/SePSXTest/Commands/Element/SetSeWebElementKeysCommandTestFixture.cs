/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-01
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Element
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SetSeWebElementKeysCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class SetSeWebElementKeysCommandTestFixture
    {
        [Test] //[Test(Description="The WebElement.Clear() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeWebElementKeys")]
        [Category("Slow")][Category("Firefox")]
        public void FF_WebElement_SendKeys_1()
        {
            WebElement_SendKeys_1(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The WebElement.Clear() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeWebElementKeys")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_WebElement_SendKeys_1()
        {
            WebElement_SendKeys_1(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The WebElement.Clear() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeWebElementKeys")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_WebElement_SendKeys_1()
        {
            WebElement_SendKeys_1(Settings.DriverNameInternetExplorer);
        }
        
        private void WebElement_SendKeys_1(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementInput01Id +
                @"' | Set-SeWebElementKeys -Text '" +
                Settings.TestFile05Controls1ElementInput01Text +
                @"' | Read-SeWebElementAttribute -AttributeName value;",
                Settings.TestFile05Controls1ElementInput01Text);
        }
 
    
       [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
