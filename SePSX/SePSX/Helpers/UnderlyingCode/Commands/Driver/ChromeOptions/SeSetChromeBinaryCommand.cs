/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/28/2012
 * Time: 9:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
	using PSTestLib;
    
    /// <summary>
    /// Description of SeSetChromeBinaryCommand.
    /// </summary>
    internal class SeSetChromeBinaryCommand : AbstractCommand
    {
        internal SeSetChromeBinaryCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.SetChromeOptionsBinary(this.Cmdlet);
        }
    }
}
