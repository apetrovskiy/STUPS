/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/4/2012
 * Time: 5:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Driver.Firefox
{
    using System;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of StartSeFirefoxCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeFirefoxCommandTestFixture
    {
        public StartSeFirefoxCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        private void TestPrm_Firefox(string instanceName, string answer, string additions)
        {
            string instanceParam = string.Empty;
            if (string.Empty != instanceName) {
                instanceParam =
                    "-InstanceName '" +
                    instanceName +
                    "'";
            }
            string startCode = 
                @"$null = Start-SeFirefox " + 
                instanceParam +
                additions +
                "; ";
            string checkCode = string.Empty;
            if (string.Empty != instanceName) {
                checkCode =
                    @"[SePSX.CurrentData]::Drivers['" +
                    instanceName +
                    @"'].GetType().Name;";
            } else {
                checkCode =
                    @"[SePSX.CurrentData]::Drivers[" +
                    @"[SePSX.CurrentData]::Drivers.Keys[0]" +
                    "].GetType().Name;";
            }
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                startCode + checkCode,
                answer);
        }
    }
}
