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
    /// Description of GetSeWebElementCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class GetSeWebElementCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_Id_WebDriverInput()
        {
            TestPrm_Id_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_Id_WebDriverInput()
        {
            TestPrm_Id_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_Id_WebDriverInput()
        {
            TestPrm_Id_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_Id_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile01Result1ElementId1 +
                @"' -First | Read-SeWebElementAttribute -AttributeName id;",
                Settings.TestFile01Result1ElementId1);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_Id_WebElementInput()
        {
            TestPrm_Id_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_Id_WebElementInput()
        {
            TestPrm_Id_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_Id_WebElementInput()
        {
            TestPrm_Id_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_Id_WebElementInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile01Result1ElementId1 +
                @"' -First | Get-SeWebElement -Id '" +
                Settings.TestFile01Result1ElementId2 +
                @"' -First | Read-SeWebElementAttribute -AttributeName id;",
                Settings.TestFile01Result1ElementId2);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as default input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_Id_3()
        {
            TestPrm_Id_3(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as default input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_Id_3()
        {
            TestPrm_Id_3(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -Id parameter test with WebDriver as default input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_Id_3()
        {
            TestPrm_Id_3(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_Id_3(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)) +
                @"'; Get-SeWebElement -Id '" +
                Settings.TestFile01Result1ElementId1 +
                @"' -First | Read-SeWebElementAttribute -AttributeName id;",
                Settings.TestFile01Result1ElementId1);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_ClassName_WebDriverInput()
        {
            TestPrm_ClassName_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_ClassName_WebDriverInput()
        {
            TestPrm_ClassName_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_ClassName_WebDriverInput()
        {
            TestPrm_ClassName_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_ClassName_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Class '" +
                Settings.TestFile05Controls1ElementText02Class +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementText02Answer);
        }

        [Test] //[Test(Description="The -ClassName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_ClassName_WebElementInput()
        {
            TestPrm_ClassName_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_ClassName_WebElementInput()
        {
            TestPrm_ClassName_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -ClassName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_ClassName_WebElementInput()
        {
            TestPrm_ClassName_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_ClassName_WebElementInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementText02Div +
                @"' -First | Get-SeWebElement -Class '" +
                Settings.TestFile05Controls1ElementText02Class +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementText02Answer);
        }

        
        [Test] //[Test(Description="The -Name parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_Name_WebDriverInput()
        {
            TestPrm_Name_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -Name parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_Name_WebDriverInput()
        {
            TestPrm_Name_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -Name parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_Name_WebDriverInput()
        {
            TestPrm_Name_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_Name_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                  MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Name '" +
                Settings.TestFile05Controls1ElementText02Name +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementText02Answer);
        }
        
        [Test] //[Test(Description="The -Name parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_Name_WebElementInput()
        {
            TestPrm_Name_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -Name parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_Name_WebElementInput()
        {
            TestPrm_Name_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -Name parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_Name_WebElementInput()
        {
            TestPrm_Name_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_Name_WebElementInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                  MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementText02Div +
                @"' -First | Get-SeWebElement -Name '" +
                Settings.TestFile05Controls1ElementText02Name +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementText02Answer);
        }
        
        
//        [Test] //[Test(Description="The -Name parameter test with WebElement as input")]
//        [Category("Slow")][Category("WebElement")]
//        [Category("Slow")][Category("Get_SeWebElement")]
//        [Category("Slow")][Category("Firefox")]
//        public void FF_TestPrm_Name_WebElementInput_WrongInput()
//        {
//            TestPrm_Name_WebElementInput_WrongInput(Settings.DriverNameFirefox);
//        }
//        
//        [Test] //[Test(Description="The -Name parameter test with WebElement as input")]
//        [Category("Slow")][Category("WebElement")]
//        [Category("Slow")][Category("Get_SeWebElement")]
//        [Category("Slow")][Category("Chrome")]
//        public void Ch_TestPrm_Name_WebElementInput_WrongInput()
//        {
//            TestPrm_Name_WebElementInput_WrongInput(Settings.DriverNameChrome);
//        }
//        
//        [Test] //[Test(Description="The -Name parameter test with WebElement as input")]
//        [Category("Slow")][Category("WebElement")]
//        [Category("Slow")][Category("Get_SeWebElement")]
//        [Category("Slow")][Category("InternetExplorer")]
//        public void IE_TestPrm_Name_WebElementInput_WrongInput()
//        {
//            TestPrm_Name_WebElementInput_WrongInput(Settings.DriverNameInternetExplorer);
//        }
//        
//        private void TestPrm_Name_WebElementInput_WrongInput(string driverName)
//        {
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"$null | Get-SeWebElement -Name '" +
//                Settings.TestFile05Controls1ElementText02Name +
//                @"' -First | Read-SeWebElementText;",
//                "333",
//                "444");
//        }


        [Test] //[Test(Description="The -TagName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_TagName_WebDriverInput()
        {
            TestPrm_TagName_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_TagName_WebDriverInput()
        {
            TestPrm_TagName_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_TagName_WebDriverInput()
        {
            TestPrm_TagName_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_TagName_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -TagName '" +
                "text" +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementText01Text);
        }

        
        [Test] //[Test(Description="The -TagName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_TagName_WebElementInput()
        {
            TestPrm_TagName_WebElementInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_TagName_WebElementInput()
        {
            TestPrm_TagName_WebElementInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -TagName parameter test with WebElement as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_TagName_WebElementInput()
        {
            TestPrm_TagName_WebElementInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_TagName_WebElementInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -Id '" +
                Settings.TestFile05Controls1ElementText02Div +
                @"' -First | Get-SeWebElement -TagName '" +
                "text" +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementText02Text);
        }
        
        
        [Test] //[Test(Description="The -LinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_LinkText_WebDriverInput()
        {
            TestPrm_LinkText_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -LinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_LinkText_WebDriverInput()
        {
            TestPrm_LinkText_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -LinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_LinkText_WebDriverInput()
        {
            TestPrm_LinkText_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_LinkText_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -LinkText '" +
                Settings.TestFile05Controls1ElementLink01LinkText +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementLink01Answer);
        }
        
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_PartialLinkText_WebDriverInput()
        {
            TestPrm_PartialLinkText_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_PartialLinkText_WebDriverInput()
        {
            TestPrm_PartialLinkText_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -PartialLinkText parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_PartialLinkText_WebDriverInput()
        {
            TestPrm_PartialLinkText_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_PartialLinkText_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -PartialLinkText '" +
                Settings.TestFile05Controls1ElementLink02LinkText +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile05Controls1ElementLink02Answer);
        }
        
        
        
        [Test] //[Test(Description="The -CSS parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_CSS_WebDriverInput()
        {
            TestPrm_CSS_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -CSS parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_CSS_WebDriverInput()
        {
            TestPrm_CSS_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -CSS parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_CSS_WebDriverInput()
        {
            TestPrm_CSS_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_CSS_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)) +
                @"' | Get-SeWebElement -CSS '" +
                Settings.TestFile01Result1ElementCSSValue1 +
                @"' -First | Read-SeWebElementText).Substring(0, 17);",
                Settings.TestFile01Result1ElementCSS1Answer);
        }
        
        
        
        
        [Test] //[Test(Description="The -XPath parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_XPath_WebDriverInput()
        {
            TestPrm_XPath_WebDriverInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -XPath parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_XPath_WebDriverInput()
        {
            TestPrm_XPath_WebDriverInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -XPath parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_XPath_WebDriverInput()
        {
            TestPrm_XPath_WebDriverInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_XPath_WebDriverInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile01Result1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile01Result1ElementXPath1 +
                @"' -First | Read-SeWebElementText;",
                Settings.TestFile01Result1ElementXPath1Answer);
        }
        
        
        [Test] //[Test(Description="The -XPath parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_XPath_WrongInput()
        {
            TestPrm_XPath_WrongInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The -XPath parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_XPath_WrongInput()
        {
            TestPrm_XPath_WrongInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The -XPath parameter test with WebDriver as input")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElement")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_XPath_WrongInput()
        {
            TestPrm_XPath_WrongInput(Settings.DriverNameInternetExplorer);
        }
        
        private void TestPrm_XPath_WrongInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null | Get-SeWebElement -XPath '" +
                Settings.TestFile01Result1ElementXPath1 +
                @"' -First | Read-SeWebElementText;",
                "CmdletInvocationException",
                "The pipeline input is null or not of IWebDriver or IWebElement type");
        }
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
