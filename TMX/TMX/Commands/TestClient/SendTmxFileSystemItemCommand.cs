/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 9:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SendTmxFileSystemItemCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "TmxFileSystemItem")]
    public class SendTmxFileSystemItemCommand : ClientCmdletBase
    {
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string Path { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 1)]
        public string Destination { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Recurse { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }
        
        protected override void BeginProcessing()
        {
            var command = new SendFileSystemItemCommand(this);
            command.Execute();
        }
    }
}
