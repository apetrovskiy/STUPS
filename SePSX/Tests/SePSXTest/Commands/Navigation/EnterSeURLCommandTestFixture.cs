/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Navigation
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of EnterSeURLCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class EnterSeURLCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -URL parameter test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Enter_SeURL")]
        [Category("Slow")][Category("Firefox")]
        public void FF_NavigateTo_Firefox()
        {
            NavigateTo(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)));
        }
        
        [Test] //[Test(Description="The -URL parameter test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Enter_SeURL")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_NavigateTo_Chrome()
        {
            NavigateTo(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)));
        }
        
        [Test] //[Test(Description="The -URL parameter test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Enter_SeURL")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_NavigateTo_IE()
        {
            NavigateTo(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)));
        }
        
        public void NavigateTo(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL +
                @"').Title;",
                Settings.TestFile01Result1Title);
        }
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
