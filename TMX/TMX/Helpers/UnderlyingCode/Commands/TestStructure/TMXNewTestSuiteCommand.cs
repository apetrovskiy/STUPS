/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Core;

    /// <summary>
    /// Description of TmxNewTestSuiteCommand.
    /// </summary>
    class TmxNewTestSuiteCommand : TmxCommand
    {
        internal TmxNewTestSuiteCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewSuiteCmdletBase)Cmdlet;
            
            Guid testPlatformId = Guid.Empty;
            if (string.IsNullOrEmpty(cmdlet.TestPlatformId))
                if (null != TestData.CurrentTestPlatform)
                    testPlatformId = TestData.CurrentTestPlatform.UniqueId;
            
            if (!string.IsNullOrEmpty(cmdlet.TestPlatformId)) {
                if (TestData.TestPlatforms.All(tp => tp.Id != cmdlet.TestPlatformId))
                    throw new Exception("Couldn't find test platfiorm with Id = " + cmdlet.TestPlatformId);
                testPlatformId = TestData.TestPlatforms.First(tp => tp.Id == cmdlet.TestPlatformId).UniqueId;
            }
            
            bool result = 
                TmxHelper.NewTestSuite(
                    cmdlet.Name,
                    cmdlet.Id,
                    testPlatformId,
                    cmdlet.Description,
                    // 20141211
                    // cmdlet.BeforeScenario,
                    // cmdlet.AfterScenario);
                    // (cmdlet.BeforeScenario.Select(scriptblock => new CodeBlock { Code = scriptblock.ToString() }) ?? new CodeBlock[]{}).ToArray(),
                    // (cmdlet.AfterScenario.Select(scriptblock => new CodeBlock { Code = scriptblock.ToString() }) ?? new CodeBlock[]{}).ToArray());
                    cmdlet.BeforeScenario.Select(scriptblock => new CodeBlock { Code = scriptblock.ToString() }).ToArray(),
                    cmdlet.AfterScenario.Select(scriptblock => new CodeBlock { Code = scriptblock.ToString() }).ToArray());
            
            if (result)
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite);
            else
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't create a test suite",
                    "CreatingTestSuite",
                    ErrorCategory.InvalidArgument,
                    true);
        }
    }
}
