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
    /// Description of SeGetElementByTypeCommand.
    /// </summary>
    internal class SeGetElementByTypeCommand : SeWebElementCommand
    {
        internal SeGetElementByTypeCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.GetWebElementViaJS(
                this.Cmdlet,
                ((GetSeElementByTypeCommand)this.Cmdlet).InputObject, 
                ((GetSeElementByTypeCommand)this.Cmdlet).TagName);
        }
    }
}
