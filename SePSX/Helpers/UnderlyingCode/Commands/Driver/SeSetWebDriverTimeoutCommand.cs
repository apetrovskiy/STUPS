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
    /// Description of SeSetWebDriverTimeoutCommand.
    /// </summary>
    internal class SeSetWebDriverTimeoutCommand : SeWebDriverCommand
    {
        internal SeSetWebDriverTimeoutCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SetSeWebDriverTimeoutCommand cmdlet = (SetSeWebDriverTimeoutCommand)this.Cmdlet;
            if (0 != cmdlet.ImplicitlyWaitTimeout) {
                SeHelper.SetDriverTimeout(cmdlet, cmdlet.InputObject, DriverTimeoutTypes.ImplicitlyWait, cmdlet.ImplicitlyWaitTimeout);
            }
            
            if (0 != cmdlet.PageLoadTimeout) {
                SeHelper.SetDriverTimeout(cmdlet, cmdlet.InputObject, DriverTimeoutTypes.PageLoad, cmdlet.PageLoadTimeout);
            }
            
            if (0 != cmdlet.ScriptTimeout) {
                SeHelper.SetDriverTimeout(cmdlet, cmdlet.InputObject, DriverTimeoutTypes.Script, cmdlet.ScriptTimeout);
            }
        }
    }
}
