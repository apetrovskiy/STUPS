/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 5:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;
   
    /// <summary>
    /// Description of StopSeChromeCommandTestFixture.
    /// </summary>
    public class StopSeChromeCommandTestFixture
    {
        public StopSeChromeCommandTestFixture()
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
        public void Chrome_InputObject_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Stop-SeChrome -InputObject $null;");
        }
        
        [Test]
        public void Chrome_InstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Stop-SeChrome -InstanceName aaa;");
        }
    }
}
