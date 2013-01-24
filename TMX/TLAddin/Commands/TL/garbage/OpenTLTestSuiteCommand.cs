///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/9/2012
// * Time: 6:51 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace TMX
//{
//    using System;
//    using System.Management.Automation;
//    
//    /// <summary>
//    /// Description of OpenTLTestSuiteCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TLTestSuite")]
//    public class OpenTLTestSuiteCommand : TLTestSuiteCmdletBase
//    {
//        public OpenTLTestSuiteCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            TLSrvOpenTestSuiteCommand command =
//                new TLSrvOpenTestSuiteCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
//    }
//}
