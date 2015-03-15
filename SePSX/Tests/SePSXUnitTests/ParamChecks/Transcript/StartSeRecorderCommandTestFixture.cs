/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 6:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeRecorderCommandTestFixture.
    /// </summary>
    public class StartSeRecorderCommand_ParamCheck
    {
        public StartSeRecorderCommand_ParamCheck()
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
        public void StartSeRecorder_Timeout_FileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Start-SeRecorder -Timeout 10000 -FileName C:\1\1.txt;");
        }
        
        [Test]
        [Category("Fast")]
        public void StartSeRecorder_Seconds_FileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Start-SeRecorder -Timeout 10 -FileName C:\1\1.txt;");
        }
        
        [Test]
        [Category("Fast")]
        public void StartSeRecorder_Seconds_NoFileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Start-SeRecorder -Timeout 10;");
        }
    }
}
