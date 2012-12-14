/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 6:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of StartSeRecorderCommandTestFixture.
    /// </summary>
    public class StartSeRecorderCommandTestFixture
    {
        public StartSeRecorderCommandTestFixture()
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
                @"Start-SeRecorder -Timeout 10000 -FileName C:\1\1.txt;");
        }
        
        [Test]
        public void Seconds_FileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                @"Start-SeRecorder -Timeout 10 -FileName C:\1\1.txt;");
        }
        
        [Test]
        public void Seconds_NoFileName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                @"Start-SeRecorder -Timeout 10;");
        }
    }
}
