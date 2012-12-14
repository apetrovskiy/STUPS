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
    /// Description of AddTLTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TLTestCase")]
    public class AddTLTestCaseCommand : TLTestCaseCmdletBase
    {
        public AddTLTestCaseCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            TLSrvAddTestCaseCommand command =
                new TLSrvAddTestCaseCommand(this);
            command.Execute();
        }
    }
}
