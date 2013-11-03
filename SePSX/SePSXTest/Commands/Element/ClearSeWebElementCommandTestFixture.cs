/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Element
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
	/// <summary>
	/// Description of ClearSeWebElementCommandTestFixture.
	/// </summary>
	[TestFixture] // [TestFixture(Description=" test")]
	public class ClearSeWebElementCommandTestFixture
	{
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        
        [Test] //[Test(Description="The WebElement.Clear() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Clear_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_WebElement_Clear_1()
        {
            WebElement_Clear_1(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The WebElement.Clear() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Clear_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_WebElement_Clear_1()
        {
            WebElement_Clear_1(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The WebElement.Clear() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Clear_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_WebElement_Clear_1()
        {
            WebElement_Clear_1(Settings.DriverNameInternetExplorer);
        }
        
        private void WebElement_Clear_1(string driverName)
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
                @"' | Clear-SeWebElement | Read-SeWebElementAttribute -AttributeName value;",
                Settings.TestFile05Controls1ElementInput01Answer);
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
	}
}
