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
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeInternetExplorer32CommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeInternetExplorer32Command_ParamCheck
    {
        public StartSeInternetExplorer32Command_ParamCheck()
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
        public void StartSeInternetExplorer32_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Start-SeInternetExplorer32;");
        }
        
//        [Test]
//        [Category("Fast")]
//        public void InternetExplorer32_AsService()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeInternetExplorer32 -AsService;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void InternetExplorer32_AsServiceTrue()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeInternetExplorer32 -AsService:$true;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void InternetExplorer32_AsServiceFalse()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeInternetExplorer32 -AsService:$false;");
//        }
    }
}
