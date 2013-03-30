/*
 * Created by SharpDevelop.
 * User: Alexander
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
		#endregion Parameters
		
		protected override void BeginProcessing()
		{
			//
		}
	}
}
