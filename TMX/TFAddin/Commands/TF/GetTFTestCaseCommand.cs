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
    /// Description of GetTFTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TFTestCase")]
    public class GetTFTestCaseCommand : TFTestCaseCmdletBase
    {
        public GetTFTestCaseCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvGetTestCaseCommand command =
                new TFSrvGetTestCaseCommand(this);
            command.Execute();
        }
    }
}
