/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/25/2012
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeTranscriptCommand.
    /// </summary>
    [TestFixture]
    public class StartSeTranscriptCommand_ParamCheck
    {
        public StartSeTranscriptCommand_ParamCheck()
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
        public void StartSeTranscript_Timeout_FileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Start-SeTranscript -Timeout 10000 -FileName C:\1\1.txt;");
        }
        
        [Test]
        [Category("Fast")]
        public void StartSeTranscript_Seconds_FileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Start-SeTranscript -Timeout 10 -FileName C:\1\1.txt;");
        }
        
        [Test]
        [Category("Fast")]
        public void StartSeTranscript_Seconds_NoFileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Start-SeTranscript -Timeout 10;");
        }
    }
}
