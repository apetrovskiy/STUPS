/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Driver
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of StopSeWebDriverCommandTestFixture.
	/// </summary>
	[TestFixture] // [TestFixture(Description=" test")]
	public class StopSeWebDriverCommandTestFixture
	{
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        string answerString = "True";
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Stop_SeWebDriver")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_DriverName_Firefox()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$driver = Start-SeWebDriver -DriverName '" + 
                Settings.DriverNameFirefox + 
                "'; " +
                @"$driver | Stop-SeWebDriver;",
                Settings.AnswerTrue);
        }
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Stop_SeWebDriver")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_TestPrm_DriverName_Chrome()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$driver = Start-SeWebDriver -DriverName '" + 
                Settings.DriverNameChrome + 
                "'; " +
                @"$driver | Stop-SeWebDriver;",
                Settings.AnswerTrue);
        }
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Stop_SeWebDriver")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_TestPrm_DriverName_IE()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$driver = Start-SeWebDriver -DriverName '" + 
                Settings.DriverNameIE + 
                "'; " +
                @"$driver | Stop-SeWebDriver;",
                Settings.AnswerTrue);
        }
        
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Stop_SeWebDriver")]
        [Category("Slow")][Category("Firefox")]
        public void FF_TestPrm_DriverNameAsArray_Firefox()
        {
            
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
//            System.Collections.ObjectModel.Collection<string> coll = 
//                new System.Collections.ObjectModel.Collection<string>();
            
            coll.Add((new PSObject(Settings.AnswerTrue)));
            coll.Add((new PSObject(Settings.AnswerTrue)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$driver1 = Start-SeWebDriver -DriverName '" + 
                Settings.DriverNameFirefox + 
                "'; " +
                @"$driver2 = Start-SeWebDriver -DriverName '" + 
                Settings.DriverNameFirefox + 
                "'; " +
                @"$null = $driver1; $null = $driver2; " +
                @"Stop-SeWebDriver -InstanceName $([SePSX.CurrentData]::Drivers.Keys);",
                coll);
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
	}
}
