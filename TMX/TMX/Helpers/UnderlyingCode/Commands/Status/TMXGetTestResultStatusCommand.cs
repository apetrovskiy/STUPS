/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/31/2013
 * Time: 8:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using TMX.Commands;
    
    /// <summary>
    /// Description of TmxGetTestResultStatusCommand.
    /// </summary>
    internal class TmxGetTestResultStatusCommand : TmxCommand
    {
        internal TmxGetTestResultStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            GetTmxTestResultStatusCommand cmdlet =
                (GetTmxTestResultStatusCommand)this.Cmdlet;
            
            TmxHelper.GetCurrentTestResultStatus(cmdlet);
        }
    }
}
