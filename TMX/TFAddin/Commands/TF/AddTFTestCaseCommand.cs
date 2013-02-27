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
    /// Description of AddTFTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TFTestCase")]
    public class AddTFTestCaseCommand : TFTestCaseCmdletBase
    {
        public AddTFTestCaseCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvAddTestCaseCommand command =
                new TFSrvAddTestCaseCommand(this);
            command.Execute();
        }
    }
}
