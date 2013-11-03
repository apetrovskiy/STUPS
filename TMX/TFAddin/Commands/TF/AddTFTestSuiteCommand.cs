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
    /// Description of AddTFTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TFTestSuite")]
    public class AddTFTestSuiteCommand : TFTestSuiteCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvAddTestSuiteCommand command =
                new TFSrvAddTestSuiteCommand(this);
            command.Execute();
        }
    }
}
