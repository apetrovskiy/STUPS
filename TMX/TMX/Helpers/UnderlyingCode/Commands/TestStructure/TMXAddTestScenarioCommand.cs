/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 11:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Tmx.Core;
	using Tmx.Interfaces;
	using Tmx;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TmxAddTestScenarioCommand.
    /// </summary>
    class TmxAddTestScenarioCommand : TmxCommand
    {
        internal TmxAddTestScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (AddScenarioCmdletBase)Cmdlet;
            
            // 20141112
            var testPlatformId = cmdlet.TestPlatformId;
            if (string.IsNullOrEmpty(testPlatformId)) {
                // 20141114
                // if (null == cmdlet.InputObject || string.IsNullOrEmpty(cmdlet.InputObject.PlatformId))
                // 20141119
                // if (null == cmdlet.InputObject || Guid.Empty == cmdlet.InputObject.PlatformId)
                // 20141121
                ITestPlatform testPlatform = null;
                
                if (null == cmdlet.InputObject || Guid.Empty == cmdlet.InputObject.PlatformUniqueId) {
                    // 20141114
                    // testPlatformId = TestData.CurrentTestSuite.PlatformId;
                    // 20141119
                    // testPlatformId = TestData.TestPlatforms.FirstOrDefault(tp => tp.UniqueId == TestData.CurrentTestSuite.PlatformId).Id;
                    // 20141121
                    // testPlatformId = TestData.TestPlatforms.FirstOrDefault(tp => tp.UniqueId == TestData.CurrentTestSuite.PlatformUniqueId).Id;
                    testPlatform = TestData.TestPlatforms.FirstOrDefault(tp => tp.UniqueId == TestData.CurrentTestSuite.PlatformUniqueId);
                } else {
                    // 20141114
                    // testPlatformId = cmdlet.InputObject.PlatformId;
                    // 20141119
                    // testPlatformId = TestData.TestPlatforms.FirstOrDefault(tp => tp.UniqueId == cmdlet.InputObject.PlatformId).Id;
                    // 20141121
                    // testPlatformId = TestData.TestPlatforms.FirstOrDefault(tp => tp.UniqueId == cmdlet.InputObject.PlatformUniqueId).Id;
                    testPlatform = TestData.TestPlatforms.FirstOrDefault(tp => tp.UniqueId == cmdlet.InputObject.PlatformUniqueId);
                }
            
            // 20140721
            var dataObject = new AddScenarioCmdletBaseDataObject {
                // 20141211
                // AfterTest = cmdlet.AfterTest,
                // BeforeTest = cmdlet.BeforeTest,
                AfterTest = cmdlet.AfterTest.Select(scriptblock => new CodeBlock { Code = scriptblock.ToString() }).ToArray(),
                BeforeTest = cmdlet.BeforeTest.Select(scriptblock => new CodeBlock { Code = scriptblock.ToString() }).ToArray(),
                Description = cmdlet.Description,
                Id = cmdlet.Id,
                InputObject = cmdlet.InputObject,
                Name = cmdlet.Name,
                // 20141112
                // TestPlatformId = cmdlet.TestPlatformId,
                // TestPlatformId = string.IsNullOrEmpty(cmdlet.TestPlatformId) ? (stri cmdlet.InputObject.PlatformId) : cmdlet.TestPlatformId,
                // 20141121
                // TestPlatformId = testPlatformId,
                TestPlatformId = testPlatform.Id,
                TestPlatformUniqueId = testPlatform.UniqueId,
                TestSuiteId = cmdlet.TestSuiteId,
                // 20141122
                // TestSuiteUniqueId = null != cmdlet.InputObject ? cmdlet.InputObject.UniqueId : TestData.CurrentTestSuite.UniqueId,
                TestSuiteName = cmdlet.TestSuiteName
            };
            
            // bool result = TmxHelper.AddTestScenario(cmdlet);
            bool result = TmxHelper.AddTestScenario(dataObject);
            
            if (result)
                cmdlet.WriteObject(
                    cmdlet,
                    TestData.CurrentTestScenario);
            else
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't add a test scenario",
                    "AddingTestScenario",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
