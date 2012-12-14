/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/4/2012
 * Time: 5:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Driver.Chrome
{
    using System;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of StartSeChromeCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeChromeCommandTestFixture
    {
        public StartSeChromeCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        private void TestPrm_Chrome(string instanceName, string answer, string additions)
        {
            string instanceParam = string.Empty;
            if (string.Empty != instanceName) {
                instanceParam =
                    "-InstanceName '" +
                    instanceName +
                    "'";
            }
            string startCode = 
                @"$null = Start-SeChrome " + 
                instanceParam +
                additions +
                "; ";
            string checkCode = string.Empty;
            if (string.Empty != instanceName) {
                checkCode =
                    @"[SePSX.CurrentData]::Drivers['" +
                    instanceName +
                    @"'].GetType().Name;";
            } else {
                checkCode =
                    @"[SePSX.CurrentData]::Drivers[" +
                    @"[SePSX.CurrentData]::Drivers.Keys[0]" +
                    "].GetType().Name;";
            }
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                startCode + checkCode,
                answer);
        }
        
//        [Test]
//        [Category("Slow")]
//        [Category("WebDriver")]
//        [Category("Start_SeChrome")]
//        [Category("Chrome")]
//        public void TestPrm_Bare_DriverName()
//        {
//            string instanceName = "my chrome";
//            string additions = " -AsService:$false";
//            TestPrm_Chrome(instanceName, Settings.ObjectNameChrome, additions);
//        }
//        
//        [Test]
//        [Category("Slow")]
//        [Category("WebDriver")]
//        [Category("Start_SeChrome")]
//        [Category("Chrome")]
//        public void TestPrm_Bare_NoDriverName()
//        {
//            string instanceName = string.Empty;
//            string additions = " -AsService:$false";
//            TestPrm_Chrome(instanceName, Settings.ObjectNameChrome, additions);
//        }
        
        [Test]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeChrome")]
        [Category("Chrome")]
        public void TestPrm_Service_DriverName()
        {
            string instanceName = "my chrome";
            string additions = string.Empty;
            TestPrm_Chrome(instanceName, Settings.ObjectNameChrome, additions);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeChrome")]
        [Category("Chrome")]
        public void TestPrm_Service_NoDriverName()
        {
            string instanceName = string.Empty;
            string additions = string.Empty;
            TestPrm_Chrome(instanceName, Settings.ObjectNameChrome, additions);
        }
    }
}
