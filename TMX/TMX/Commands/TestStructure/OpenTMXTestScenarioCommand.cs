/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using Tmx.Interfaces;
	using Tmx;
    
    /// <summary>
    /// Description of OpenTmxTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TmxTestScenario")]
    public class OpenTmxTestScenarioCommand : OpenScenarioCmdletBase
    {
        protected override void ProcessRecord()
        {
            // 20140721
            var dataObject = new OpenScenarioCmdletBaseDataObject {
                InputObject = this.InputObject,
                Name = this.Name,
                Id = this.Id,
                // Descriprion = this.Description,
                // 20141203
//                TestSuiteName = this.TestSuiteName,
//                TestSuiteId = this.TestSuiteId,
//                TestPlatformId = this.TestPlatformId
                TestSuiteName = this.TestSuiteName ?? TestData.CurrentTestSuite.Name,
                TestSuiteId = this.TestSuiteId ?? TestData.CurrentTestSuite.Id,
                TestPlatformId = this.TestPlatformId ?? TestData.CurrentTestPlatform.Id
            };
            
            // bool result = TmxHelper.OpenTestScenario(this);
            bool result = TmxHelper.OpenTestScenario(dataObject);
            
            if (result)
                WriteObject(TestData.CurrentTestScenario);
            else
                WriteError(
                    this,
                    "Couldn't open a test scenario",
                    "GettingTestScenario",
                    ErrorCategory.InvalidData,
                    true);
        }
    }
}
