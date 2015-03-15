/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest
{
    using System;
    
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public static class Settings
    {
        static Settings()
        {
            
            
            // test files
            //TestFile01Result1 = @".\..\..\..\TestData\result1.htm";
            //TestFile01Result1Title = @"Test results";
            //TestFile01Result1ElementId1 = @"global";
            //TestFile01Result1ElementId2 = @"suite";
            TestFile01Result1ElementClassName1 = @"";
            TestFile01Result1ElementClassName2 = @"";
            TestFile01Result1ElementTagName1 = @"";
            TestFile01Result1ElementTagName2 = @"";
            TestFile01Result1ElementName1 = @""; //111 suite1 FAILED";
            TestFile01Result1ElementName2 = @"";
            TestFile01Result1ElementLinkPath1 = @"";
            TestFile01Result1ElementLinkPath2 = @"";
            TestFile01Result1ElementPartialLinkPath1 = @"";
            TestFile01Result1ElementPartialLinkPath2 = @"";
            //TestFile01Result1ElementCSSValue1 = @"";
            TestFile01Result1ElementCSSValue2 = @"";
            //TestFile01Result1ElementXPath1 = @"";
            TestFile01Result1ElementXPath2 = @"";
            
            
            TestFile02Summary1 = @".\..\..\..\TestData\summary1.htm";
            TestFile02Summary1Title = @"";
            
            
            TestFile03Result2 = @".\..\..\..\TestData\test_result.htm";
            TestFile03Result2Title = @"";
            
            
            TestFile04Summary2 = @".\..\..\..\TestData\test_summary.htm";
            TestFile04Summary2Title = @"";
            
            
        }
        
        public static string RunspaceCommand = 
//#if DEBUG
//                        @"Import-Module '..\..\..\TMX\bin\Debug\Tmx.dll' -Force;" + //);
//#else
//                        @"Import-Module '..\..\..\TMX\bin\Release35\Tmx.dll' -Force;" + //);
//#endif
//                        @"";
        
                        @"Import-Module '.\SePSX.dll' -Force;" +
                        //@"Import-Module '.\UIAutomation.dll' -Force;" + 
                        //@"Import-Module '.\Tmx.dll' -Force;";
        
                        //@"[Tmx.TestData]::TestSuites.Clear();";
//                        @"[UIAutomation.Preferences]::OnSuccessDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnErrorDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnClickDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnSleepDelay = 0;" +
//                        @"[UIAutomation.Preferences]::Timeout = 3000;" + 
//                        @"[UIAutomation.Preferences]::OnErrorScreenShot = $false;" + 
//                        @"[UIAutomation.Preferences]::Log = $false;";
            
                        @"[SePSX.Preferences]::OnSuccessDelay = 0; " +
                        @"[SePSX.Preferences]::OnErrorDelay = 0; " +
//                        @"[SePSX.Preferences]::OnClickDelay = 0; " +
                        @"[SePSX.Preferences]::OnSleepDelay = 100; " +
                        @"[SePSX.Preferences]::Timeout = 3000; " + 
                        @"[SePSX.Preferences]::OnErrorScreenShot = $false; " + 
                        @"[SePSX.Preferences]::Log = $false; ";

        
        // drivers
        public static string DriverNameFirefox { get { return "firefox"; } }
        public static string DriverNameFF { get { return "ff"; } }
        public static string ObjectNameFirefox { get { return "FirefoxDriver"; } }
        public static string DriverNameChrome { get { return "chrome"; } }
        public static string DriverNameCh { get { return "ch"; } }
        public static string ObjectNameChrome { get { return "ChromeDriver"; } }
        public static string DriverNameInternetExplorer { get { return "internetexplorer"; } }
        public static string DriverNameIE { get { return "ie"; } }
        public static string ObjectNameInternetExplorer { get { return "InternetExplorerDriver"; } }
        
        // constants
        public static string AnswerTrue { get { return "True";} }
        public static string AnswerFalse { get { return "False";} }
        
        
        // test files
        public static string TestFile01Result1 { get { return @".\..\..\..\TestData\result1.htm"; } }
        public static string TestFile01Result1Title { get { return "Test results"; } }
        public static string TestFile01Result1ElementId1 { get { return "global"; } }
        public static string TestFile01Result1ElementId2 { get { return "suite"; } }
        public static string TestFile01Result1ElementClassName1 { get; set; }
        public static string TestFile01Result1ElementClassName2 { get; set; }
        public static string TestFile01Result1ElementTagName1 { get; set; }
        public static string TestFile01Result1ElementTagName2 { get; set; }
        public static string TestFile01Result1ElementName1 { get; set; }
        public static string TestFile01Result1ElementName2 { get; set; }
        public static string TestFile01Result1ElementLinkPath1 { get; set; }
        public static string TestFile01Result1ElementLinkPath2 { get; set; }
        public static string TestFile01Result1ElementPartialLinkPath1 { get; set; }
        public static string TestFile01Result1ElementPartialLinkPath2 { get; set; }
        public static string TestFile01Result1ElementCSSValue1 { get { return "#suite"; } }
        public static string TestFile01Result1ElementCSSValue2 { get; set; }
        public static string TestFile01Result1ElementXPath1 { get { return @"//*[@id=""suite""]/li/h2"; } }
        public static string TestFile01Result1ElementXPath2 { get; set; }
        
        public static string TestFile01Result1ElementCSS1Answer { get { return @"111 suite1 FAILED"; } }
        public static string TestFile01Result1ElementXPath1Answer { get { return @"111 suite1 FAILED"; } }
        
        
        public static string TestFile02Summary1 { get; set; }
        public static string TestFile02Summary1Title { get; set; }
        
        
        public static string TestFile03Result2 { get; set; }
        public static string TestFile03Result2Title { get; set; }
        
        
        public static string TestFile04Summary2 { get; set; }
        public static string TestFile04Summary2Title { get; set; }
        
        
        public static string TestFile05Controls1 { get { return @".\..\..\..\TestData\controls.htm"; } }
        public static string TestFile05Controls1Title { get { return "Controls"; } }
        
        // Select
        public static string TestFile05Controls1ElementSelectsDiv { get { return @"selects"; } }
        
        public static string TestFile05Controls1ElementSelect01XPath { get { return @"//*[@id=""select sample 01""]/select"; } }
        public static string TestFile05Controls1ElementSelect01Value01 { get { return "val1"; } }
        public static string TestFile05Controls1ElementSelect01Value01Name { get { return "Value1"; } }
        public static string TestFile05Controls1ElementSelect01Value02 { get { return "val2"; } }
        public static string TestFile05Controls1ElementSelect01Value02Name { get { return "Value 2"; } }
        public static string TestFile05Controls1ElementSelect01Value03 { get { return "val3"; } }
        public static string TestFile05Controls1ElementSelect01Value03Name { get { return @"Value \3"; } }
        public static string TestFile05Controls1ElementSelect01Value04 { get { return "val4"; } }
        public static string TestFile05Controls1ElementSelect01Value04Name { get { return "Value /4"; } }
        
        public static string TestFile05Controls1ElementSelect02XPath { get { return @"//*[@id=""select02""]"; } }
        public static string TestFile05Controls1ElementSelect02ClassName { get { return @"select02class"; } }
        public static string TestFile05Controls1ElementSelect02Div { get { return @"select sample 02"; } }
        public static string TestFile05Controls1ElementSelect02Answer { get { return "Value1\r\nValue 2\r\nValue \\3\r\nValue /4"; } }
        public static string TestFile05Controls1ElementSelect02Value01 { get { return "val1"; } }
        public static string TestFile05Controls1ElementSelect02Value01Name { get { return "Value1"; } }
        public static string TestFile05Controls1ElementSelect02Value02 { get { return "val2"; } }
        public static string TestFile05Controls1ElementSelect02Value02Name { get { return "Value 2"; } }
        public static string TestFile05Controls1ElementSelect02Value03 { get { return "val3"; } }
        public static string TestFile05Controls1ElementSelect02Value03Name { get { return @"Value \3"; } }
        public static string TestFile05Controls1ElementSelect02Value04 { get { return "val4"; } }
        public static string TestFile05Controls1ElementSelect02Value04Name { get { return "Value /4"; } }
        
        public static string TestFile05Controls1ElementSelect03XPath { get { return @"//*[@id=""select sample 03""]/select"; } }
        public static string TestFile05Controls1ElementSelect03Value01 { get { return "val1"; } }
        public static string TestFile05Controls1ElementSelect03Value01Name { get { return "Value1"; } }
        public static string TestFile05Controls1ElementSelect03Value02 { get { return "val2"; } }
        public static string TestFile05Controls1ElementSelect03Value02Name { get { return "Value 2"; } }
        public static string TestFile05Controls1ElementSelect03Value03 { get { return "val3"; } }
        public static string TestFile05Controls1ElementSelect03Value03Name { get { return @"Value \3"; } }
        public static string TestFile05Controls1ElementSelect03Value04 { get { return "val4"; } }
        public static string TestFile05Controls1ElementSelect03Value04Name { get { return "Value /4"; } }
        
        public static string TestFile05Controls1ElementSelect04XPath { get { return @"//*[@id=""select sample 04""]/select"; } }
        public static string TestFile05Controls1ElementSelect04Value01 { get { return "val1"; } }
        public static string TestFile05Controls1ElementSelect04Value01Name { get { return "Value1"; } }
        public static string TestFile05Controls1ElementSelect04Value02 { get { return "val2"; } }
        public static string TestFile05Controls1ElementSelect04Value02Name { get { return "Value 2"; } }
        public static string TestFile05Controls1ElementSelect04Value03 { get { return "val3"; } }
        public static string TestFile05Controls1ElementSelect04Value03Name { get { return @"Value \3"; } }
        public static string TestFile05Controls1ElementSelect04Value04 { get { return "val4"; } }
        public static string TestFile05Controls1ElementSelect04Value04Name { get { return "Value /4"; } }
        
        public static string TestFile05Controls1ElementSelect05XPath { get { return @"//*[@id=""select sample 05""]/select"; } }
        public static string TestFile05Controls1ElementSelect05Name { get { return @"select with name"; } }
        public static string TestFile05Controls1ElementSelect05Div { get { return @"select sample 05"; } }
        //public static string TestFile05Controls1ElementSelect05Answer { get { return "  Value1\r\n  Value 2\r\n  Value \\3\r\n  Value /4\r\n "; } }
        public static string TestFile05Controls1ElementSelect05Answer { get { return "Value1\r\nValue 2\r\nValue \\3\r\nValue /4"; } }
        public static string TestFile05Controls1ElementSelect05Value01 { get { return "val1"; } }
        public static string TestFile05Controls1ElementSelect05Value01Name { get { return "Value1"; } }
        public static string TestFile05Controls1ElementSelect05Value02 { get { return "val2"; } }
        public static string TestFile05Controls1ElementSelect05Value02Name { get { return "Value 2"; } }
        public static string TestFile05Controls1ElementSelect05Value03 { get { return "val3"; } }
        public static string TestFile05Controls1ElementSelect05Value03Name { get { return @"Value \3"; } }
        public static string TestFile05Controls1ElementSelect05Value04 { get { return "val4"; } }
        public static string TestFile05Controls1ElementSelect05Value04Name { get { return "Value /4"; } }
        
        public static string TestFile05Controls1ElementSelect06XPath { get { return @"//*[@id=""select sample 06""]/select"; } }
        public static string TestFile05Controls1ElementSelect06Value01 { get { return "val1"; } }
        public static string TestFile05Controls1ElementSelect06Value01Name { get { return "Value1"; } }
        public static string TestFile05Controls1ElementSelect06Value02 { get { return "val2"; } }
        public static string TestFile05Controls1ElementSelect06Value02Name { get { return "Value 2"; } }
        public static string TestFile05Controls1ElementSelect06Value03 { get { return "val3"; } }
        public static string TestFile05Controls1ElementSelect06Value03Name { get { return @"Value \3"; } }
        public static string TestFile05Controls1ElementSelect06Value04 { get { return "val4"; } }
        public static string TestFile05Controls1ElementSelect06Value04Name { get { return "Value /4"; } }
        
        public static string TestFile05Controls1ElementId2 { get { return "suite"; } }
        public static string TestFile05Controls1ElementClassName1 { get; set; }
        public static string TestFile05Controls1ElementClassName2 { get; set; }
        public static string TestFile05Controls1ElementTagName1 { get; set; }
        public static string TestFile05Controls1ElementTagName2 { get; set; }
        public static string TestFile05Controls1ElementName1 { get; set; }
        public static string TestFile05Controls1ElementName2 { get; set; }
        public static string TestFile05Controls1ElementLinkPath1 { get; set; }
        public static string TestFile05Controls1ElementLinkPath2 { get; set; }
        public static string TestFile05Controls1ElementPartialLinkPath1 { get; set; }
        public static string TestFile05Controls1ElementPartialLinkPath2 { get; set; }
        public static string TestFile05Controls1ElementCSSValue1 { get { return "#suite"; } }
        public static string TestFile05Controls1ElementCSSValue2 { get; set; }
        public static string TestFile05Controls1ElementXPath1 { get { return @"//*[@id='suite']/li/h2"; } }
        public static string TestFile05Controls1ElementXPath2 { get; set; }
        
        // Links
        public static string TestFile05Controls1ElementLinksDiv { get { return "links"; } }
        public static string TestFile05Controls1ElementLinksPartialLinkText { get { return "Link 0"; } }
        public static string TestFile05Controls1ElementLinkIds { get { return @"l1"; } }
        
        public static string TestFile05Controls1ElementLink01LinkText { get { return "Link 01"; } }
        public static string TestFile05Controls1ElementLink01Answer { get { return @"Link 01"; } }
        //".//*[@id='link sample 01']/a"
        public static string TestFile05Controls1ElementLink01XPath { get { return "//*[@id=\"link sample 01\"]/a"; } } 
        public static string TestFile05Controls1ElementLink02LinkText { get { return "02"; } }
        public static string TestFile05Controls1ElementLink02Answer { get { return @"Link 02"; } }
        public static string TestFile05Controls1ElementLink03LinkText { get { return "Link 03"; } }
        public static string TestFile05Controls1ElementLink03Answer { get { return @"Link 03"; } }
        public static string TestFile05Controls1ElementLink04LinkText { get { return "04"; } }
        public static string TestFile05Controls1ElementLink04Answer { get { return @"Link 04"; } }
        public static string TestFile05Controls1ElementLink05LinkText { get { return "04"; } }
        public static string TestFile05Controls1ElementLink05Answer { get { return @"Link 04"; } }
        
        // Input
        public static string TestFile05Controls1ElementInputsDiv { get { return "inputs"; } }
        
        public static string TestFile05Controls1ElementInput01Id { get { return @"input 01"; } }
        public static string TestFile05Controls1ElementInput01Text { get { return @"test input 01"; } }
        public static string TestFile05Controls1ElementInput01Answer { get { return ""; } }

        // Button
        public static string TestFile05Controls1ElementButtonsDiv { get { return "buttons"; } }
        public static string TestFile05Controls1ElementButtonsClass { get { return "btn"; } }
        
        public static string TestFile05Controls1ElementButton01Id { get { return @"button 01"; } }
        public static string TestFile05Controls1ElementButton01Div { get { return @"button sample 01"; } }
        public static string TestFile05Controls1ElementButton01Text { get { return @"Button 01"; } }
        public static string TestFile05Controls1ElementButton01XPath { get { return @".//*[@id='button 01']"; } }
        public static string TestFile05Controls1ElementButton01Answer { get { return @"button clicked"; } }
        public static string TestFile05Controls1ElementButton02Id { get { return @"button 02"; } }
        public static string TestFile05Controls1ElementButton02Div { get { return @"button sample 02"; } }
        public static string TestFile05Controls1ElementButton02Text { get { return @"Button 02"; } }
        public static string TestFile05Controls1ElementButton02Answer { get { return @"button clicked"; } }
        public static string TestFile05Controls1ElementButton03Id { get { return @"button 03"; } }
        public static string TestFile05Controls1ElementButton03Div { get { return @"button sample 03"; } }
        public static string TestFile05Controls1ElementButton03Text { get { return @"Button 03"; } }
        public static string TestFile05Controls1ElementButton03Answer { get { return @"button clicked"; } }
        
        // Text
        public static string TestFile05Controls1ElementTextsDiv { get { return "texts"; } }
        
        public static string TestFile05Controls1ElementText01Id { get { return @"text 01"; } }
        public static string TestFile05Controls1ElementText01Div { get { return @"text sample 01"; } }
        public static string TestFile05Controls1ElementText01Text { get { return @"Text 01"; } }
        public static string TestFile05Controls1ElementText01Answer { get { return @"Text 01"; } }
        public static string TestFile05Controls1ElementText02Id { get { return @"text 02"; } }
        public static string TestFile05Controls1ElementText02Div { get { return @"text sample 02"; } }
        public static string TestFile05Controls1ElementText02Text { get { return @"Text 02"; } }
        public static string TestFile05Controls1ElementText02Class { get { return @"text02class"; } }
        public static string TestFile05Controls1ElementText02Name { get { return @"text02"; } }
        public static string TestFile05Controls1ElementText02Answer { get { return @"Text 02"; } }
        
        
        public static string TestFile06Controls1 { get { return @".\..\..\..\TestData\containers.htm"; } }
        public static string TestFile06Controls1Title { get { return "Containers"; } }
        
        public static string TestFile06Controls1Element01XPath { get { return @"//*[@id=""div3""]/p[1]"; } }
        public static string TestFile06Controls1Element01Value01 { get { return "Val1"; } }
        public static string TestFile06Controls1Element01Value01Name { get { return "Value1"; } }
        public static string TestFile06Controls1Element01Value02 { get { return "Val2"; } }
        public static string TestFile06Controls1Element01Value02Name { get { return "Value 2"; } }
        public static string TestFile06Controls1Element01Value03 { get { return "Val3"; } }
        public static string TestFile06Controls1Element01Value03Name { get { return @"Value \3"; } }
        public static string TestFile06Controls1Element01Value04 { get { return "Val4"; } }
        public static string TestFile06Controls1Element01Value04Name { get { return "Value /4"; } }
        
        
        
        
        public static string TestFile07Frames1 { get { return @".\..\..\..\TestData\frames1.htm"; } }
        public static string TestFile07Frames1Title { get { return "Frames"; } }
        

        
        
        
        public static string TestFile08Frames1 { get { return @".\..\..\..\TestData\frames2.htm"; } }
        public static string TestFile08Frames1Title { get { return "Frames"; } }
        
        public static string TestFile09Frames1 { get { return @".\..\..\..\TestData\frames3.htm"; } }
        public static string TestFile09Frames1Title { get { return "Frames"; } }
        
        
        
        public static string TestFile10Alerts1 { get { return @".\..\..\..\TestData\alerts.htm"; } }
        public static string TestFile10Alerts1Title { get { return "Alerts"; } }
        
        public static string TestFile10Alerts1ElementButton01XPath { get { return @"//*[@id=""button 01""]"; } }
        public static string TestFile10Alerts1ElementButton01Text { get { return @"button 01"; } }
        
        public static string TestFile10Alerts1ElementButton02XPath { get { return @"//*[@id=""button 02""]"; } }
        public static string TestFile10Alerts1ElementButton02Text { get { return @"button 02"; } }
        
        public static string TestFile10Alerts1ElementButton03XPath { get { return @"//*[@id=""button 03""]"; } }
        public static string TestFile10Alerts1ElementButton03Text { get { return @"button 03"; } }
        
    }
}
