/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 8:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
	using System;
	using System.Management.Automation;
	using Tmx;
	
    /// <summary>
    /// Description of SendTmxDetailedStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "TmxDetailedStatus")]
    public class SendTmxDetailedStatusCommand : ClientCmdletBase
    {
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string Status { get; set; }
        
		protected override void BeginProcessing()
		{
			var command = new SendDetailedStatusCommand(this);
			command.Execute();
		}
    }
}
