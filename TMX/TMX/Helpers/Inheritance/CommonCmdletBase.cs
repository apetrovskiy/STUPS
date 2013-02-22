/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 18/02/2012
 * Time: 01:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using PSTestLib;
    using System.Collections.ObjectModel;
    using System.Collections;
    
    /// <summary>
    /// Description of CmdletBase.
    /// </summary>
    public partial class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }
        [Parameter(Mandatory = false)]
        //[ValidateNotNullOrEmpty()]
        public string Id { get; set; }
        #endregion Parameters
        
        protected void notImplementedCase()
        {
//            ErrorRecord err = 
//                new ErrorRecord(
//                    new Exception(),
//                    "",
//                    ErrorCategory.NotImplemented,
//                    null);
//            err.ErrorDetails = 
//                new ErrorDetails("Not implemented");
//            ThrowTerminatingError(err);
            
            this.WriteError(
                this,
                "Not implemented",
                "NotImplemented",
                ErrorCategory.NotImplemented,
                true);
        }
        
        protected override void WriteLog(string logRecord)
        {
            Console.WriteLine("Here should be logging");
        }
        
        protected override bool CheckSingleObject(PSCmdletBase cmdlet, object outputObject) { return true; }
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}
        protected override void BeforeWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}

        protected override void WriteSingleObject(PSCmdletBase cmdlet, object outputObject)
        {
            //WriteVerbose(this, " TMX");
            try {
                base.WriteObject(outputObject);
            }
            catch {}
        }
        
        protected override void AfterWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}

        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " TMX");
        }

        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot TMX");
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " TMX");
        }

        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            if (terminating) {
                this.WriteVerbose(this, "terminating error !!!");
                try {
                    ThrowTerminatingError(errorRecord);
                }
                catch {}
            } else {
                this.WriteVerbose(this, "regular error !!!");
                try {
                    WriteError(errorRecord);
                }
                catch {}
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " TMX");
        }

    }
}
