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
    /// Description of StopSeInternetExplorer32CommandTestFixture.
    /// </summary>
    public class StopSeInternetExplorer32CommandTestFixture
    {
        public StopSeInternetExplorer32CommandTestFixture()
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
        public void InternetExplorer32_InputObject_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Stop-SeInternetExplorer -InputObject $null;");
        }
        
        [Test]
        public void InternetExplorer32_InstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Stop-SeInternetExplorer -InstanceName aaa;");
        }
    }
}
