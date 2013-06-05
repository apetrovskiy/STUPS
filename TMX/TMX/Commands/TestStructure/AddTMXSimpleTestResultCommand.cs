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

	/// <summary>
	/// Description of AddTMXSimpleTestResultCommand.
	/// </summary>
	[Cmdlet(VerbsCommon.Add, "TMXSimpleTestResult")]
	public class AddTMXSimpleTestResultCommand : TestResultCmdletBase
	{
		public AddTMXSimpleTestResultCommand()
		{
		}
		
		#region Parameters
		// 20130605
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
			TMXAddSimpleTestResultCommand command =
			    new TMXAddSimpleTestResultCommand(this);
			command.Execute();
		}
	}
}
