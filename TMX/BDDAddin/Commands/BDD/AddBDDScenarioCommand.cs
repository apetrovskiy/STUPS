/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 5:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddBDDScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "BDDScenario")]
    public class AddBDDScenarioCommand : BDDScenarioCmdletBase
    {
        public AddBDDScenarioCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            if (!this.CheckInputFeature(this.InputObject)) {
                return;
                
                // error !!!!!!!!
                
            }
            
            BDDAddScenarioCommand command =
                new BDDAddScenarioCommand(this);
            command.Execute();
        }
    }
}
