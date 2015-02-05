/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 5:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of BddCommand.
    /// </summary>
    abstract class BddCommand
    {
        internal BddCommand(CommonCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
