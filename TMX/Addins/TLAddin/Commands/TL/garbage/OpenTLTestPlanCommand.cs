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
//    /// Description of OpenTLTestPlanCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TLTestPlan")]
//    public class OpenTLTestPlanCommand : TLTestPlanCmdletBase
//    {
//        public OpenTLTestPlanCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            TLSrvOpenTestPlanCommand command =
//                new TLSrvOpenTestPlanCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
//    }
//}
