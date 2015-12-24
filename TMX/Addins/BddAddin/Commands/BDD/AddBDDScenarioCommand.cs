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
    /// Description of AddBddScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "BddScenario")]
    public class AddBddScenarioCommand : BddScenarioCmdletBase
    {
        protected override void ProcessRecord()
        {
            if (!CheckInputFeature(InputObject)) {
                return;
                
                // error !!!!!!!!
                
            }
            
            var command = new BddAddScenarioCommand(this);
            command.Execute();
        }
    }
}
