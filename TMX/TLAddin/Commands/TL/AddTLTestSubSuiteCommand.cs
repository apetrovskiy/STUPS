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
    /// Description of AddTLTestSubSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TLTestSubSuite")]
    public class AddTLTestSubSuiteCommand : TLTestSubSuiteCmdletBase
    {
        public AddTLTestSubSuiteCommand()
        {
        }
        
//        protected override void ProcessRecord()
//        {
//            TLSrvAddTestSubSuiteCommand command =
//                new TLSrvAddTestSubSuiteCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
    }
}
