/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvCommand.
    /// </summary>
    internal abstract class TFSrvCommand
    {
        internal TFSrvCommand(TFSCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
        }
        
        internal TFSCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
    
//    internal abstract class BaseUploadCommand
//    {
//        protected ArchiveTransferManager manager;
//        protected UploadOptions options;
//        protected string vaultName;
//        protected string archiveDescription;
//        protected string filePath;
//
//        internal BaseUploadCommand(ArchiveTransferManager manager, string vaultName, string archiveDescription, string filePath, UploadOptions options)
//        {
//            this.manager = manager;
//            this.vaultName = vaultName;
//            this.archiveDescription = archiveDescription;
//            this.filePath = filePath;
//            this.options = options;
//
//            if (this.options == null)
//                this.options = new UploadOptions();
//        }
//
//        internal abstract void Execute();
//
//
//        public UploadResult UploadResult
//        {
//            get;
//            protected set;
//        }
//    }
}
