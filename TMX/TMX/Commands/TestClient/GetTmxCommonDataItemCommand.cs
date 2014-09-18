/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/12/2014
 * Time: 5:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxTestCommonDataCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxCommonDataItem")]
    public class GetTmxCommonDataItemCommand : ServerCmdletBase
    {
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string Key { get; set; }
        
		protected override void BeginProcessing()
		{
			var command = new GetCommonDataItemCommand(this);
			command.Execute();
		}
    }
}
