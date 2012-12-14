/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 5:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;
   
    /// <summary>
    /// Description of StopSeFirefoxCommandTestFixture.
    /// </summary>
    public class StopSeFirefoxCommandTestFixture
    {
        public StopSeFirefoxCommandTestFixture()
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
        public void Firefox_InputObject_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Stop-SeFirefox -InputObject $null;");
        }
        
        [Test]
        public void Firefox_InstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Stop-SeFirefox -InstanceName aaa;");
        }
    }
}
