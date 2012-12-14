/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ESXiMgmtTest.Commands
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    /// <summary>
    /// Description of ConnectESXiServerCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="VMwareHelper test")]
    public class ConnectESXiServerCommandTestFixture
    {
        public ConnectESXiServerCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="1")]
        [Category("Slow")][Category("Connect_ESXiHost")]
        public void TestPrm_Server_Simple()
        {
            string serverName = "10.30.36.97";
            string userName = "root";
            string password = "=1qwerty";
            string datastoreName = "datastore1";
            string result = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Connect-ESXiHost -Server " + 
                serverName + 
                " -Username " +
                userName +
                " -Password " +
                password +
                " -DatastoreName " +
                datastoreName +
                ";",
                result);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Connect_ESXiHost")]
        public void TestPrm_ServerPort_Simple()
        {
            string serverName = "10.30.36.97";
            string port = "22";
            string userName = "root";
            string password = "=1qwerty";
            string datastoreName = "datastore1";
            string result = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Connect-ESXiHost -Server " + 
                serverName + 
                " -Port " +
                port +
                " -Username " +
                userName +
                " -Password " +
                password +
                " -DatastoreName " +
                datastoreName +
                ";",
                result);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Connect_ESXiHost")]
        public void TestPrm_ServerPortProtocol_Simple()
        {
            string serverName = "10.30.36.97";
            string port = "22";
            string protocol = "HTTPS";
            string userName = "root";
            string password = "=1qwerty";
            string datastoreName = "datastore1";
            string result = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Connect-ESXiHost -Server " + 
                serverName + 
                " -Port " +
                port +
                " -Protocol " +
                protocol +
                " -Username " +
                userName +
                " -Password " +
                password +
                " -DatastoreName " +
                datastoreName +
                ";",
                result);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
