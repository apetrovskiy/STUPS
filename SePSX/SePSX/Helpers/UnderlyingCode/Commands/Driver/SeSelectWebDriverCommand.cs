/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    
    /// <summary>
    /// Description of SeSelectWebDriverCommand.
    /// </summary>
    internal class SeSelectWebDriverCommand : SeWebDriverCommand
    {
        internal SeSelectWebDriverCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.GetWebDriver(
                ((SelectSeWebDriverCommand)this.Cmdlet),
                ((SelectSeWebDriverCommand)this.Cmdlet).InstanceName);
        }
    }
}
