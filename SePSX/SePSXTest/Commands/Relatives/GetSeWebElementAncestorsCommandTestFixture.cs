/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10.08.2012
 * Time: 6:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Relatives
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetSeWebElementAncestorsCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class GetSeWebElementAncestorsCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The Get-UIAWebElementAncestors cmdlet test")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementAncestors")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Ancestors_1()
        {
            Ancestors_1(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="The Get-UIAWebElementAncestors cmdlet test")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementAncestors")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Ancestors_1()
        {
            Ancestors_1(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="The Get-UIAWebElementAncestors cmdlet test")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeWebElementAncestors")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Ancestors_1()
        {
            Ancestors_1(Settings.DriverNameInternetExplorer);
        }
        
        private void Ancestors_1(string driverName)
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            
            //coll.Add((new PSObject("  Value1\r\n  Value 2\r\n  Value \\3\r\n  Value /4\r\n ")));
            coll.Add((new PSObject("div3\r\nMy first paragraph.\r\nMy second paragraph.")));
            coll.Add((new PSObject("div2\r\ndiv3\r\nMy first paragraph.\r\nMy second paragraph.")));
            coll.Add((new PSObject("div1\r\ndiv2\r\ndiv3\r\nMy first paragraph.\r\nMy second paragraph.")));
            coll.Add((new PSObject("My First Heading\r\ndiv1\r\ndiv2\r\ndiv3\r\nMy first paragraph.\r\nMy second paragraph.")));
            coll.Add((new PSObject("My First Heading\r\ndiv1\r\ndiv2\r\ndiv3\r\nMy first paragraph.\r\nMy second paragraph.")));
//            coll.Add((new PSObject("Test results 26.07.2012 16:16
//  Value1
//  Value 2
//  Value \3
//  Value /4
// 
//  Value1
//  Value 2
//  Value \3
//  Value /4
// 
//  Value1
//  Value 2
//  Value \3
//  Value /4
// 
//Value1 Value 2 Value \3 Value /4
//  Value1
//  Value 2
//  Value \3
//  Value /4
// 
//Value1 Value 2 Value \3 Value /4
//Suites:1 Passed:0 Failed:1 Not tested:0
//Scenarios:2 Passed:0 Failed:2 Not tested:0
//Test cases:21 Passed:11 Failed:7 Not tested:3 Time spent:6 seconds
//4 cases of non-critical issues are counted as Passed
//111 suite1 FAILED
//Scenarios:2 Passed:0 Failed:2 Not tested:0
//Test cases:21 Passed:11 Failed:7 Not tested:3 Time spent:6 seconds
//description description description description description description description description description description>
//)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect01Value03Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect01Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile06Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile06Controls1Element01XPath +
                //@"' | Get-SeWebElementAncestors | %{ $_ | Read-SeWebElementText; }",
                @"' | Get-SeWebElementAncestors | Read-SeWebElementText;",
                coll);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
