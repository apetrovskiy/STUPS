/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 12:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of UiaCommand.
    /// </summary>
    internal abstract class UiaCommand
    {
        internal UiaCommand(CommonCmdletBase cmdlet)
        {
            Cmdlet = cmdlet;
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
