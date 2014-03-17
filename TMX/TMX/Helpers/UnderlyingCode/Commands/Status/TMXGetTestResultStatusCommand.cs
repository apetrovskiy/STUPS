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
    using PSTestLib;
    
    /// <summary>
    /// Description of TmxGetTestResultStatusCommand.
    /// </summary>
    internal class TmxGetTestResultStatusCommand : AbstractCommand // : TmxCommand
    {
        internal TmxGetTestResultStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            var cmdlet =
                (GetTmxTestResultStatusCommand)this.Cmdlet;
            
            TmxHelper.GetCurrentTestResultStatus(cmdlet);
        }
    }
}
