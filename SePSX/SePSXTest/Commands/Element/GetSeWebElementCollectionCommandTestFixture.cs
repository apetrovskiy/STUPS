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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetSeWebElementCollectionCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class GetSeWebElementCollectionCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_Id_WebDriverInput()
        {
            TestPrm_Id_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_Id_WebDriverInput()
        {
            TestPrm_Id_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_Id_WebDriverInput()
        {
            TestPrm_Id_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_Id_WebDriverInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink03Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementLinkIds +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }

        [Test] //[Test(Description="The -Id parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_Id_WebElementInput()
        {
            TestPrm_Id_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_Id_WebElementInput()
        {
            TestPrm_Id_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_Id_WebElementInput()
        {
            TestPrm_Id_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_Id_WebElementInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink03Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementLinksDiv +
                @"' -First | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementLinkIds +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }
        
        
        
        
        
        
        [Test] //[Test(Description="The -ClassName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_ClassName_WebDriverInput()
        {
            TestPrm_ClassName_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_ClassName_WebDriverInput()
        {
            TestPrm_ClassName_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_ClassName_WebDriverInput()
        {
            TestPrm_ClassName_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_ClassName_WebDriverInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementButton02Text)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementButton03Text)));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Class '" +
                Settings.TestFile05Controls1ElementButtonsClass +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }

        [Test] //[Test(Description="The -ClassName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_ClassName_WebElementInput()
        {
            TestPrm_ClassName_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_ClassName_WebElementInput()
        {
            TestPrm_ClassName_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_ClassName_WebElementInput()
        {
            TestPrm_ClassName_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_ClassName_WebElementInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementButton02Text)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementButton03Text)));

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementButtonsDiv +
                @"' -First | Get-SeWebElement -Class '" +
                Settings.TestFile05Controls1ElementButtonsClass +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The -TagName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_TagName_WebDriverInput()
        {
            TestPrm_TagName_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_TagName_WebDriverInput()
        {
            TestPrm_TagName_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_TagName_WebDriverInput()
        {
            TestPrm_TagName_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_TagName_WebDriverInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink01Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink02Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink03Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink05Answer)));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -TagName '" +
                "a" +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }

        [Test] //[Test(Description="The -TagName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_TagName_WebElementInput()
        {
            TestPrm_TagName_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_TagName_WebElementInput()
        {
            TestPrm_TagName_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_TagName_WebElementInput()
        {
            TestPrm_TagName_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_TagName_WebElementInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink01Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink02Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink03Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink05Answer)));

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementLinksDiv +
                @"' -First | Get-SeWebElement -TagName '" +
                "a" +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }
        
        
        
        
        [Test] //[Test(Description="The -LinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_LinkText_WebDriverInput()
        {
            TestPrm_LinkText_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -LinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_LinkText_WebDriverInput()
        {
            TestPrm_LinkText_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -LinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_LinkText_WebDriverInput()
        {
            TestPrm_LinkText_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_LinkText_WebDriverInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink05Answer)));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -LinkText '" +
                Settings.TestFile05Controls1ElementLink04Answer +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }

        [Test] //[Test(Description="The -LinkText parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_LinkText_WebElementInput()
        {
            TestPrm_LinkText_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -LinkText parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_LinkText_WebElementInput()
        {
            TestPrm_LinkText_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -LinkText parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_LinkText_WebElementInput()
        {
            TestPrm_LinkText_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_LinkText_WebElementInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink05Answer)));

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementLinksDiv +
                @"' -First | Get-SeWebElement -LinkText '" +
                Settings.TestFile05Controls1ElementLink04Answer +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }

        
        
        
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_PartialLinkText_WebDriverInput()
        {
            TestPrm_PartialLinkText_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_PartialLinkText_WebDriverInput()
        {
            TestPrm_PartialLinkText_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_PartialLinkText_WebDriverInput()
        {
            TestPrm_PartialLinkText_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_PartialLinkText_WebDriverInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink01Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink02Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink03Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink05Answer)));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -PartialLinkText '" +
                Settings.TestFile05Controls1ElementLinksPartialLinkText +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }

        [Test] //[Test(Description="The -PartialLinkText parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_PartialLinkText_WebElementInput()
        {
            TestPrm_PartialLinkText_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_PartialLinkText_WebElementInput()
        {
            TestPrm_PartialLinkText_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementCollection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_PartialLinkText_WebElementInput()
        {
            TestPrm_PartialLinkText_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_PartialLinkText_WebElementInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink01Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink02Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink03Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink04Answer)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementLink05Answer)));

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementLinksDiv +
                @"' -First | Get-SeWebElement -PartialLinkText '" +
                Settings.TestFile05Controls1ElementLinksPartialLinkText +
                //@"' | %{ $_ | Read-SeWebElementText; }",
                @"' | Read-SeWebElementText;",
                coll);
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
