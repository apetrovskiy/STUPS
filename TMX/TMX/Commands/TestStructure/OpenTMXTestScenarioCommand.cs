/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of OpenTmxTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TmxTestScenario")]
    public class OpenTmxTestScenarioCommand : OpenScenarioCmdletBase
    {
        protected override void ProcessRecord()
        {
            bool result = TmxHelper.OpenTestScenario(this);

            if (result) {

                WriteObject(TestData.CurrentTestScenario);

            } else {

                WriteError(
                    this,
                    "Couldn't open a test scenario",
                    "GettingTestScenario",
                    ErrorCategory.InvalidData,
                    true);
            }
        }
    }
}
