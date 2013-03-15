/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 5:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;
   
    /// <summary>
    /// Description of StopSeChromeCommandTestFixture.
    /// </summary>
    public class StopSeChromeCommand_ParamCheck
    {
        public StopSeChromeCommand_ParamCheck()
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
        public void StopSeChrome_InputObject_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Stop-SeChrome -InputObject $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void StopSeChrome_Chrome_InstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Stop-SeChrome -InstanceName aaa;");
        }
    }
}
