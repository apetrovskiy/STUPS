/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvGetTestCaseCommand.
    /// </summary>
    internal class TFSrvGetTestCaseCommand : TFSrvCommand
    {
        internal TFSrvGetTestCaseCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.GetTestCase(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
