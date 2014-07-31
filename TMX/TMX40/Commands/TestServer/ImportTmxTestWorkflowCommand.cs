/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 5:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of ImportTmxTestWorkflowCommand.
	/// </summary>
	[Cmdlet(VerbsData.Import, "TmxTestWorkflow")]
	public class ImportTmxTestWorkflowCommand : ServerCmdletBase
	{
		[Parameter(Mandatory = true,
		           Position = 0)]
		public string Path { get; set; }
		
		protected override void BeginProcessing()
		{
			var command = new ImportTestWorkflowCommand(this);
			command.Execute();
		}
	}
}
