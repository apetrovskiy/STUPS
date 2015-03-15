/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTFTestSubSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TFTestSubSuite")]
    public class GetTFTestSubSuiteCommand : TFTestSubSuiteCmdletBase
    {
        public GetTFTestSubSuiteCommand()
        {
        }
        
//        protected override void BeginProcessing()
//        {
//            TFSrvGetTestSubSuiteCommand command =
//                new TFSrvGetTestSubSuiteCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
    }
}
