/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/7/2014
 * Time: 8:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetTmxServerSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TmxServerSettings")]
    public class SetTmxServerSettingsCommand : ClientCmdletBase
    {
        [Parameter(Mandatory = true)]
        public string ServerUrl { get; set; }
        
        protected override void BeginProcessing()
        {
            var command = new SetServerSettingsCommand(this);
            command.Execute();
        }
    }
}
