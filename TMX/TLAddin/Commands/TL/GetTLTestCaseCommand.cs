/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTLTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TLTestCase", DefaultParameterSetName = "TestProjectInput")]
    public class GetTLTestCaseCommand : TLTestCaseCmdletBase
    {
        public GetTLTestCaseCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            TLSrvGetTestCaseCommand command =
                new TLSrvGetTestCaseCommand(this);
            command.Execute();
        }
    }
}
