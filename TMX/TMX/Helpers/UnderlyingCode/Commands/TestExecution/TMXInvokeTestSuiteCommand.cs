/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 7:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Tmx;
    
    /// <summary>
    /// Description of TmxInvokeTestSuiteCommand.
    /// </summary>
    class TmxInvokeTestSuiteCommand : TmxCommand
    {
        internal TmxInvokeTestSuiteCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (TestSuiteExecCmdletBase)Cmdlet;
            
            var testSuite =
                TestData.GetTestSuite(
                    cmdlet.Name,
                    cmdlet.Id,
                    // 20141114
                    // cmdlet.TestPlatformId);
                    TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId);
            
            if (null == testSuite)
                cmdlet.WriteError(
                    cmdlet,
                    "failed to find test suite with Name = '" +
                    cmdlet.Name +
                    "', Id = '" +
                    cmdlet.Id +
                    "'",
                    "FailedToFindTestSuite",
                    ErrorCategory.InvalidArgument,
                    true);
            
            testSuite.BeforeScenarioParameters = cmdlet.BeforeScenarioParameters;
            testSuite.AfterScenarioParameters = cmdlet.AfterScenarioParameters;
            
            if (!cmdlet.OnlySetParameters)
                cmdlet.RunTestSuite(
                    cmdlet,
                    testSuite);
        }
    }
}
