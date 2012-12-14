/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 3:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX;
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
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        public void InternetExplorer32_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeInternetExplorer32;");
        }
        
//        [Test]
//        public void InternetExplorer32_AsService()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeInternetExplorer32 -AsService;");
//        }
//        
//        [Test]
//        public void InternetExplorer32_AsServiceTrue()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeInternetExplorer32 -AsService:$true;");
//        }
//        
//        [Test]
//        public void InternetExplorer32_AsServiceFalse()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeInternetExplorer32 -AsService:$false;");
//        }
    }
}
