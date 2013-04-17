/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2013
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Win32Utils
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXCommand.
    /// </summary>
    internal abstract class Win32Command
    {
        internal Win32Command(CommonCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
