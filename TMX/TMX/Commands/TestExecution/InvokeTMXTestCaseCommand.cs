/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/15/2013
 * Time: 4:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of InvokeTMXTestCaseCommand.
	/// </summary>
	[Cmdlet(VerbsLifecycle.Invoke, "TMXTestCase")]
	public class InvokeTMXTestCaseCommand : TestCaseExecCmdletBase
	{
		public InvokeTMXTestCaseCommand()
		{
		}
	}
}
