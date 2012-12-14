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
    /// Description of StartSeInternetExplorer64CommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeInternetExplorer64CommandTestFixture
    {
        public StartSeInternetExplorer64CommandTestFixture()
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
        public void InternetExplorer64_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeInternetExplorer64;");
        }
        
//        [Test]
//        public void InternetExplorer64_AsService()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeInternetExplorer64 -AsService;");
//        }
//        
//        [Test]
//        public void InternetExplorer64_AsServiceTrue()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeInternetExplorer64 -AsService:$true;");
//        }
//        
//        [Test]
//        public void InternetExplorer64_AsServiceFalse()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeInternetExplorer64 -AsService:$false;");
//        }
    }
}
