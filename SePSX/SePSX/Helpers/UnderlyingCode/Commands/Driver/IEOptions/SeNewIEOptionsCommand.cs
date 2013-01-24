/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SeNewIEOptionsCommand.
    /// </summary>
    internal class SeNewIEOptionsCommand : SeCommand
    {
        internal SeNewIEOptionsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetNewIEOptions(this.Cmdlet);
        }
    }
}
