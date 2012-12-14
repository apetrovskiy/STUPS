/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/25/2012
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeTranscriptCommand.
    /// </summary>
    [TestFixture]
    public class StartSeTranscriptCommandTestFixture
    {
        public StartSeTranscriptCommandTestFixture()
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
        public void Timeout_FileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                @"Start-SeTranscript -Timeout 10000 -FileName C:\1\1.txt;");
        }
        
        [Test]
        public void Seconds_FileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                @"Start-SeTranscript -Timeout 10 -FileName C:\1\1.txt;");
        }
        
        [Test]
        public void Seconds_NoFileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                @"Start-SeTranscript -Timeout 10;");
        }
    }
}
