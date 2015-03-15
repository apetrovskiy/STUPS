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
    /// Description of AddTFTestSubSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TFTestSubSuite")]
    public class AddTFTestSubSuiteCommand : TFTestSubSuiteCmdletBase
    {
        public AddTFTestSubSuiteCommand()
        {
        }
        
//        protected override void BeginProcessing()
//        {
//            TFSrvAddTestSubSuiteCommand command =
//                new TFSrvAddTestSubSuiteCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
    }
}
