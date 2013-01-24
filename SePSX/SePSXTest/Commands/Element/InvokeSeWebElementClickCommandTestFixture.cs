/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-01
 * Time: 15:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Element
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeSeWebElementClickCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class InvokeSeWebElementClickCommandTestFixture
    {
        public InvokeSeWebElementClickCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The WebElement.Click() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Invoke_SeWebElementClick")]
        [Category("Slow")][Category("Firefox")]
        public void FF_WebElement_Click_1()
        {
            WebElement_Click_1(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The WebElement.Click() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Invoke_SeWebElementClick")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_WebElement_Click_1()
        {
            WebElement_Click_1(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The WebElement.Click() method")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Invoke_SeWebElementClick")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_WebElement_Click_1()
        {
            WebElement_Click_1(Settings.DriverNameInternetExplorer);
        }
        
        private void WebElement_Click_1(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementButton01Id +
                @"' | Invoke-SeWebElementClick; " +
                @"Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementText01Id +
                @"' | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementButton01Answer);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
