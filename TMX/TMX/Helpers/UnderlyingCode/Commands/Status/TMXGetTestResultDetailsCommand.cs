/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2013
 * Time: 3:49 PM
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
    /// Description of TmxGetTestResultDetailsCommand.
    /// </summary>
    internal class TmxGetTestResultDetailsCommand : AbstractCommand // : TmxCommand
    {
        internal TmxGetTestResultDetailsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            var cmdlet =
                (GetTmxTestResultDetailsCommand)this.Cmdlet;
            /*
            GetTmxTestResultDetailsCommand cmdlet =
                (GetTmxTestResultDetailsCommand)this.Cmdlet;
            */
            TmxHelper.GetTestResultDetails(cmdlet);
        }
    }
}
