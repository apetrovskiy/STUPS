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
    /// Description of StartSeChromeCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeChromeCommand_ParamCheck
    {
        public StartSeChromeCommand_ParamCheck()
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
        public void StartSeChrome_Bare()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
                "Start-SeChrome;");
        }
        
//        [Test]
//        [Category("Fast")]
//        public void Chrome_AsService()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeChrome -AsService;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void Chrome_AsServiceTrue()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeChrome -AsService:$true;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void Chrome_AsServiceFalse()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Start-SeChrome -AsService:$false;");
//        }
    }
}
