/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Navigation
{
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeSeNavigateForwardCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class InvokeSeNavigateForwardCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        
        [Test] //[Test(Description="The navigation forward test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeNavigateForward")]
        [Category("Slow")][Category("Firefox")]
        public void FF_NavigateForward_Firefox()
        {
            NavigateForward(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        [Test] //[Test(Description="The navigation forward test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeNavigateForward")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_NavigateForward_Chrome()
        {
            NavigateForward(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        [Test] //[Test(Description="The navigation forward test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Invoke_SeNavigateForward")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_NavigateForward_IE()
        {
            NavigateForward(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)));
        }
        
        public void NavigateForward(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL +
                @"' | Get-SeWebElement -XPath '" + 
                Settings.TestFile05Controls1ElementLink01XPath + 
                @"' | Invoke-SeWebElementClick; " +
                @"$null = Invoke-SeNavigateBack; " +
                @"(Invoke-SeNavigateForward).Title;",
                Settings.TestFile06Controls1Title);
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
