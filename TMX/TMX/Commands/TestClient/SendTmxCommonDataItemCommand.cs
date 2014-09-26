/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 3:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SendTmxTestCommonDataCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "TmxCommonDataItem")]
    public class SendTmxCommonDataItemCommand : ClientCmdletBase
    {
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }
        
		protected override void BeginProcessing()
		{
			var command = new SendCommonDataItemCommand(this);
			command.Execute();
		}
    }
}
