/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 5:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of BDDAddScenarioCommand.
    /// </summary>
    internal class BDDAddScenarioCommand : BDDCommand
    {
        internal BDDAddScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            BDDScenarioCmdletBase cmdlet =
                (BDDScenarioCmdletBase)this.Cmdlet;
            
            BDDHelper.AddScenario(cmdlet);
        }
    }
}
