/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2013
 * Time: 6:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
	using System;
	using System.Management.Automation;
	using TMX.Interfaces.TestStructure;

	/// <summary>
	/// Description of AddTmxSimpleTestResultCommand.
	/// </summary>
	[Cmdlet(VerbsCommon.Add, "TmxSimpleTestResult")]
	public class AddTmxSimpleTestResultCommand : TestResultCmdletBase
	{
		public AddTmxSimpleTestResultCommand()
		{
            this.TestOrigin = TestResultOrigins.Logical;
		}
		
		#region Parameters
		[Parameter(Mandatory = false)]
		public string TestSuiteName { get; set; }
		
		[Parameter(Mandatory = false)]
		public string TestSuiteId { get; set; }
		
		[Parameter(Mandatory = false)]
		public string TestScenarioName { get; set; }
		
		[Parameter(Mandatory = false)]
		public string TestScenarioId { get; set; }
		#endregion Parameters
		
		protected override void BeginProcessing()
		{
			var command = new TmxAddSimpleTestResultCommand(this);
			command.Execute();
		}
	}
}
