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
    /// Description of InvokeSeNavigateBackCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class InvokeSeNavigateBackCommandTestFixture
    {
        public InvokeSeNavigateBackCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeNavigateBack")]
        [Category("Slow")][Category("Firefox")]
        public void FF_NavigateBack_Firefox()
        {
            NavigateBack(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeNavigateBack")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_NavigateBack_Chrome()
        {
            NavigateBack(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeNavigateBack")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_NavigateBack_IE()
        {
            NavigateBack(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        public void NavigateBack(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL +
                @"' | Get-SeWebElement -XPath '" + 
                Settings.TestFile05Controls1ElementLink01XPath + 
                @"' | Invoke-SeWebElementClick; " +
                @"(Invoke-SeNavigateBack).Title;",
                Settings.TestFile05Controls1Title);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
