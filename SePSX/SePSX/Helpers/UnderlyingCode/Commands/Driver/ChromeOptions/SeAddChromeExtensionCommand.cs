/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
	using PSTestLib;
    
    /// <summary>
    /// Description of SeAddChromeExtensionCommand.
    /// </summary>
    internal class SeAddChromeExtensionCommand : AbstractCommand
    {
        internal SeAddChromeExtensionCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.AddChromeExtension(this.Cmdlet);
        }
    }
}
