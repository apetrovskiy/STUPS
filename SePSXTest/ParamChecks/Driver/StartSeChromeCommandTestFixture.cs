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
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        public void Chrome_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Start-SeChrome;");
        }
        
//        [Test]
//        public void Chrome_AsService()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeChrome -AsService;");
//        }
//        
//        [Test]
//        public void Chrome_AsServiceTrue()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeChrome -AsService:$true;");
//        }
//        
//        [Test]
//        public void Chrome_AsServiceFalse()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Start-SeChrome -AsService:$false;");
//        }
    }
}
