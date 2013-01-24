/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 5:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;
   
    /// <summary>
    /// Description of StopSeFirefoxCommandTestFixture.
    /// </summary>
    public class StopSeFirefoxCommand_ParamCheck
    {
        public StopSeFirefoxCommand_ParamCheck()
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
        public void Firefox_InputObject_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Stop-SeFirefox -InputObject $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void Firefox_InstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Stop-SeFirefox -InstanceName aaa;");
        }
    }
}
