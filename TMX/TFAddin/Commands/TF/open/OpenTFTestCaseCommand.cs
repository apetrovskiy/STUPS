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
//    /// Description of OpenTFTestCaseCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TFTestCase")]
//    public class OpenTFTestCaseCommand : TFTestCaseCmdletBase
//    {
//        public OpenTFTestCaseCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            this.CheckCmdletParameters();
//            
//            TFSrvOpenTestCaseCommand command =
//                new TFSrvOpenTestCaseCommand(this);
//            command.Execute();
//        }
//    }
//}
