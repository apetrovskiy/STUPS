/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 5:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.CheckParameters
{
    using System;
    using System.Management.Automation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ConnectTLServerCommand.
    /// </summary>
    [TestFixture]
    public class ConnectTLServerCommandTestFixture
    {
        public ConnectTLServerCommandTestFixture()
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
        public void Connect_TLServer_Server_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters_ParameterMissing(
        		"Connect-TLServer -Server 1.2.3.4;");
        }
        
        [Test]
        public void Connect_TLServer_Apikey_Only()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters_ParameterMissing(
        		"Connect-TLServer -Apikey '0123456789';");
        }
        
        [Test]
        public void Connect_TLServer_Server_Apikey()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
        		"Connect-TLServer -Server 1.2.3.4 -Apikey '0123456789';");
        }
    }
}
