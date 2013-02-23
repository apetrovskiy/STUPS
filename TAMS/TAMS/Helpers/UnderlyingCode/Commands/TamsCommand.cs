/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2013
 * Time: 10:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TamsCommand.
    /// </summary>
    internal abstract class TamsCommand
    {
        internal TamsCommand(TAMS.CommonCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
        }
        
        internal TAMS.CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
