/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 3:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeInternetExplorer64CommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeInternetExplorer64Command_ParamCheck
    {
        public StartSeInternetExplorer64Command_ParamCheck()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace(); // 20121226
        }
        
        [Test]
        [Category("Fast")]
        public void StartSeInternetExplorer64_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Start-SeInternetExplorer64;");
        }
        
//        [Test]
//        [Category("Fast")]
//        public void InternetExplorer64_AsService()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeInternetExplorer64 -AsService;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void InternetExplorer64_AsServiceTrue()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeInternetExplorer64 -AsService:$true;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void InternetExplorer64_AsServiceFalse()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeInternetExplorer64 -AsService:$false;");
//        }
    }
}
