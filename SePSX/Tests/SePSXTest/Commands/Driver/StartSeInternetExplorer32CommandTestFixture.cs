/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/4/2012
 * Time: 5:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Driver.InternetExplorer
{
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of StartSeInternetExplorer32CommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeInternetExplorer32CommandTestFixture
    {
        public StartSeInternetExplorer32CommandTestFixture()
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
        
        private void TestPrm_IE32(string instanceName, string answer, string additions)
        {
            string instanceParam = string.Empty;
            if (string.Empty != instanceName) {
                instanceParam =
                    "-InstanceName '" +
                    instanceName +
                    "'";
            }
            string startCode = 
                @"$null = Start-SeInternetExplorer32 " + 
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
//        [Category("Start_SeInternetExplorer32")]
//        [Category("InternetExplorer32")]
//        public void TestPrm_Bare_DriverName()
//        {
//            string instanceName = "my InternetExplorer32";
//            string additions = " -AsService:$false";
//            TestPrm_IE32(instanceName, Settings.ObjectNameInternetExplorer, additions);
//        }
//        
//        [Test]
//        [Category("Slow")]
//        [Category("WebDriver")]
//        [Category("Start_SeInternetExplorer32")]
//        [Category("InternetExplorer32")]
//        public void TestPrm_Bare_NoDriverName()
//        {
//            string instanceName = string.Empty;
//            string additions = " -AsService:$false";
//            TestPrm_IE32(instanceName, Settings.ObjectNameInternetExplorer, additions);
//        }
        
        [Test]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeInternetExplorer32")]
        [Category("InternetExplorer32")]
        public void TestPrm_Service_DriverName()
        {
            string instanceName = "my InternetExplorer32";
            string additions = string.Empty;
            TestPrm_IE32(instanceName, Settings.ObjectNameInternetExplorer, additions);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeInternetExplorer32")]
        [Category("InternetExplorer32")]
        public void TestPrm_Service_NoDriverName()
        {
            string instanceName = string.Empty;
            string additions = string.Empty;
            TestPrm_IE32(instanceName, Settings.ObjectNameInternetExplorer, additions);
        }
    }
}
