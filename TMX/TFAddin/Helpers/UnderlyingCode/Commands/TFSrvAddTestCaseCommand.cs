/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvAddTestCaseCommand.
    /// </summary>
    internal class TFSrvAddTestCaseCommand : TFSrvCommand
    {
        internal TFSrvAddTestCaseCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.AddTestCase(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
