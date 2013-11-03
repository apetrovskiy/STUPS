/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTFTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TFTestSuite")]
    public class GetTFTestSuiteCommand : TFTestSuiteCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvGetTestSuiteCommand command =
                new TFSrvGetTestSuiteCommand(this);
            command.Execute();
        }
    }
}
