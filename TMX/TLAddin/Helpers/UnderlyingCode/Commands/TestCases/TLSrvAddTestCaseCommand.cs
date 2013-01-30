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
    /// Description of TLSrvAddTestCaseCommand.
    /// </summary>
    internal class TLSrvAddTestCaseCommand : TLSrvCommand
    {
        internal TLSrvAddTestCaseCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TLHelper.AddTestCase(
                this.Cmdlet, 
                ((AddTLTestCaseCommand)this.Cmdlet).Name);
        }
    }
}
