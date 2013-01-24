/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLSrvCommand.
    /// </summary>
    internal abstract class TLSrvCommand
    {
        internal TLSrvCommand(TLSCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
        }
        
        internal TLSCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
