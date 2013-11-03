/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 16:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Relatives
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
	/// <summary>
	/// Description of GetSeWebElementParentCommandTestFixture.
	/// </summary>
	[TestFixture] // [TestFixture(Description=" test")]
	public class GetSeWebElementParentCommandTestFixture
	{
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The Get-UIAWebElementParent cmdlet test")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementParent")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Parent_1()
        {
            Parent_1(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The Get-UIAWebElementParent cmdlet test")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementParent")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Parent_1()
        {
            Parent_1(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The Get-UIAWebElementParent cmdlet test")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementParent")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Parent_1()
        {
            Parent_1(Settings.DriverNameInternetExplorer);
        }
        
        private void Parent_1(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile01Result1ElementXPath1 +
                @"' | Get-SeWebElementParent | Read-SeWebElementText).Substring(0,19);",
                Settings.TestFile01Result1ElementXPath1Answer + "\r\n");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
	}
}
