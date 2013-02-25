/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/25/2013
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of DataCommand.
    /// </summary>
    internal abstract class DataCommand
    {
        internal DataCommand(CommonCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
