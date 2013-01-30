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
    /// Description of TLSrvGetTestCaseCommand.
    /// </summary>
    internal class TLSrvGetTestCaseCommand : TLSrvCommand
    {
        internal TLSrvGetTestCaseCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TLHelper.GetTestCase(
                this.Cmdlet,
                ((GetTLTestCaseCommand)this.Cmdlet).Name);
        }
    }
}
