/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 5:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of BddAddScenarioCommand.
    /// </summary>
    class BddAddScenarioCommand : BddCommand
    {
        internal BddAddScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (BddScenarioCmdletBase)Cmdlet;
            
            BDDHelper.AddScenario(cmdlet);
        }
    }
}
