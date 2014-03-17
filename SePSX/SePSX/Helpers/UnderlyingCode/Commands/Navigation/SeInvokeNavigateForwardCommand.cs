/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 3:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    
    /// <summary>
    /// Description of SeInvokeNavigateForwardCommand.
    /// </summary>
    internal class SeInvokeNavigateForwardCommand : SeNavigationCommand
    {
        internal SeInvokeNavigateForwardCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.NavigateForward(
                this.Cmdlet,
                ((InvokeSeNavigateForwardCommand)this.Cmdlet).InputObject);
        }
    }
}
