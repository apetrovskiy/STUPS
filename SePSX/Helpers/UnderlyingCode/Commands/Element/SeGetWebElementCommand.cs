/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    
    /// <summary>
    /// Description of SeGetWebElementCommand.
    /// </summary>
    internal class SeGetWebElementCommand : SeWebElementCommand
    {
        internal SeGetWebElementCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetWebElement(
                this.Cmdlet,
                ((GetSeWebElementCommand)this.Cmdlet).InputObject);
        }
    }
}
