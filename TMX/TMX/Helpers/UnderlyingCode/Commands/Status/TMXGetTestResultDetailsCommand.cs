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
    
    /// <summary>
    /// Description of TMXGetTestResultDetailsCommand.
    /// </summary>
    internal class TMXGetTestResultDetailsCommand : TMXCommand
    {
        internal TMXGetTestResultDetailsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            GetTMXTestResultDetailsCommand cmdlet =
                (GetTMXTestResultDetailsCommand)this.Cmdlet;
            
            TMXHelper.GetCurrentTestResultDetails(cmdlet);
        }
    }
}
