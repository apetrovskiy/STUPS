/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of AddTmxTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestCase")]
    [OutputType(typeof(ITestCase))]
    public class AddTmxTestCaseCommand : AddTestCaseCmdletBase
    {
        protected override void ProcessRecord()
        {
            var command = new TmxAddTestCaseCommand(this);
            command.Execute();
        }
    }
}
