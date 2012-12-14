/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-01
 * Time: 15:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Element
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of ReadSeWebElementAttributeCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class ReadSeWebElementAttributeCommandTestFixture
    {
        public ReadSeWebElementAttributeCommandTestFixture()
        {
        }
        
       [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="Read id")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementAttribute")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Read_WebElement_Attribute_Id()
        {
            Read_WebElement_Attribute_Id(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Read id")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementAttribute")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Read_WebElement_Attribute_Id()
        {
            Read_WebElement_Attribute_Id(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Read id")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Read_SeWebElementAttribute")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Read_WebElement_Attribute_Id()
        {
            Read_WebElement_Attribute_Id(Settings.DriverNameInternetExplorer);
        }
        
        private void Read_WebElement_Attribute_Id(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementButton01Id +
                @"' | Read-SeWebElementAttribute -AttributeName 'id';",
                Settings.TestFile05Controls1ElementButton01Id);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
