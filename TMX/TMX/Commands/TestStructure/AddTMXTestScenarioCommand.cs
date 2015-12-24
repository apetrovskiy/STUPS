/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTmxTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestScenario")]
    public class AddTmxTestScenarioCommand : AddScenarioCmdletBase
    {
        protected override void ProcessRecord()
        {
            var command = new TmxAddTestScenarioCommand(this);
            command.Execute();
        }
    }
}
