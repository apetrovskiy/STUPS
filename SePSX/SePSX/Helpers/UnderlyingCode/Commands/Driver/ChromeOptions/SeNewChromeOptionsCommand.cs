/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/26/2012
 * Time: 8:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
	using PSTestLib;
    
    /// <summary>
    /// Description of SeNewChromeOptionsCommand.
    /// </summary>
    internal class SeNewChromeOptionsCommand : AbstractCommand
    {
        internal SeNewChromeOptionsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.GetNewChromeOptions(this.Cmdlet);
        }
    }
}
