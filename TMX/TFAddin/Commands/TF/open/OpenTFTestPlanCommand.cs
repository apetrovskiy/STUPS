///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/9/2012
// * Time: 5:47 PM
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
//    /// Description of OpenTFTestPlanCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TFTestPlan")]
//    public class OpenTFTestPlanCommand : TFTestPlanCmdletBase
//    {
//        public OpenTFTestPlanCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            this.CheckCmdletParameters();
//            
//            TFSrvOpenTestPlanCommand command =
//                new TFSrvOpenTestPlanCommand(this);
//            command.Execute();
//        }
//    }
//}
