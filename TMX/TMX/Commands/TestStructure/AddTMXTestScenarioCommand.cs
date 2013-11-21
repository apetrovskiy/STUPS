/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTmxTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestScenario")]
    public class AddTmxTestScenarioCommand : AddScenarioCmdletBase
    {
        public AddTmxTestScenarioCommand()
        {
            // 20130605
//            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
//                TestData.InitTestData();
//            }
        }
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            TmxAddTestScenarioCommand command =
                new TmxAddTestScenarioCommand(this);
            command.Execute();
        }
    }
}
