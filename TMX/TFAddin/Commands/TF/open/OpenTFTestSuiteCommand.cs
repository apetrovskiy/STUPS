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
//    /// Description of OpenTFTestSuiteCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TFTestSuite")]
//    public class OpenTFTestSuiteCommand : TFTestSuiteCmdletBase
//    {
//        public OpenTFTestSuiteCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            this.CheckCmdletParameters();
//            
//            TFSrvOpenTestSuiteCommand command =
//                new TFSrvOpenTestSuiteCommand(this);
//            command.Execute();
//        }
//    }
//}
