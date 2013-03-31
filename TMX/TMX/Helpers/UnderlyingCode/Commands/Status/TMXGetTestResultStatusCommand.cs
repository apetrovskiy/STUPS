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
    /// Description of TMXGetTestResultStatusCommand.
    /// </summary>
    internal class TMXGetTestResultStatusCommand : TMXCommand
    {
        internal TMXGetTestResultStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            GetTMXTestResultStatusCommand cmdlet =
                (GetTMXTestResultStatusCommand)this.Cmdlet;
            
            TMXHelper.GetCurrentTestResultStatus(cmdlet);
        }
    }
}
