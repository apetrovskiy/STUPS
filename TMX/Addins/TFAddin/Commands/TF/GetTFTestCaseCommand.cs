/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTFTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TFTestCase")]
    public class GetTFTestCaseCommand : TFTestCaseCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvGetTestCaseCommand command =
                new TFSrvGetTestCaseCommand(this);
            command.Execute();
        }
    }
}
