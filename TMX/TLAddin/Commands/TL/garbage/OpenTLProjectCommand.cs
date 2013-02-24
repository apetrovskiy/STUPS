///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/9/2012
// * Time: 5:46 PM
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
//    /// Description of OpenTLProjectCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TLProject")]
//    public class OpenTLProjectCommand : TLProjectCmdletBase
//    {
//        public OpenTLProjectCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            TLSrvOpenProjectCommand command =
//                new TLSrvOpenProjectCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
//    }
//}
