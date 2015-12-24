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
//    /// Description of GetTLCollectionCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "TLCollection")]
//    public class GetTLCollectionCommand : TLCollectionCmdletBase
//    {
//        public GetTLCollectionCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            TLSrvGetCollectionCommand command =
//                new TLSrvGetCollectionCommand();
//            command.Cmdlet = this;
//            command.Execute();
//        }
//    }
//}
