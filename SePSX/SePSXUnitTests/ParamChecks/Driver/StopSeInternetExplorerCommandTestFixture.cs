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
    /// Description of StopSeInternetExplorer32CommandTestFixture.
    /// </summary>
    public class StopSeInternetExplorer32Command_ParamCheck
    {
        public StopSeInternetExplorer32Command_ParamCheck()
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
        public void InternetExplorer32_InputObject_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Stop-SeInternetExplorer -InputObject $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void InternetExplorer32_InstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Stop-SeInternetExplorer -InstanceName aaa;");
        }
    }
}
