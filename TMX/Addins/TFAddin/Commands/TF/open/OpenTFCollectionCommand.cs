///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/9/2012
// * Time: 5:46 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace Tmx
//{
//    using System;
//    using System.Management.Automation;
//    
//    /// <summary>
//    /// Description of OpenTFCollectionCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Open, "TFCollection")]
//    public class OpenTFCollectionCommand : TFCollectionCmdletBase
//    {
//        public OpenTFCollectionCommand()
//        {
//        }
//        
//        protected override void BeginProcessing()
//        {
//            this.CheckCmdletParameters();
//            
//            TFSrvOpenCollectionCommand command =
//                new TFSrvOpenCollectionCommand(this);
//            command.Execute();
//        }
//    }
//}
