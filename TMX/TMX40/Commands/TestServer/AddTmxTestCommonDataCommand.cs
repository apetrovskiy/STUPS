/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 9:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTmxTestCommonDataCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxCommonDataItem")]
    public class AddTmxCommonDataItemCommand : ServerCmdletBase
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
			var command = new AddCommonDataItemCommand(this);
			command.Execute();
		}
    }
}
