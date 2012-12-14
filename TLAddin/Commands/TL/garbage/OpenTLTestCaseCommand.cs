///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/9/2012
// * Time: 6:53 PM
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
//    /// Description of OpenTLTestCaseCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TLTestCase")]
//    public class OpenTLTestCaseCommand : TLTestCaseCmdletBase
//    {
//        public OpenTLTestCaseCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            TLSrvOpenTestCaseCommand command =
//                new TLSrvOpenTestCaseCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
//    }
//}
