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
    
    /// <summary>
    /// Description of CmdletBase.
    /// </summary>
    public partial class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
//            if (null == UnitTestOutput) {
//                UnitTestOutput =
//                    new System.Collections.Generic.List<object>();
//            }
        }
        
        //protected internal new bool UnitTestMode { get; set; }
        //protected internal override bool UnitTestMode { get; set; }
        //protected internal override bool UnitTestMode { get; set; }
        //protected 
        //internal new bool UnitTestMode { get; set; }
        //protected internal override bool UnitTestMode { get; set; }
        //[Parameter(Mandatory = false)]
        //public new SwitchParameter UnitTestMode { get; set; }
        //protected internal new System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        //internal static System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        //public static System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        
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
            ErrorRecord err = 
                new ErrorRecord(
                    new Exception(),
                    "",
                    ErrorCategory.NotImplemented,
                    null);
            err.ErrorDetails = 
                new ErrorDetails("Not implemented");
            //WriteError(err);
            ThrowTerminatingError(err);
        }
        
        protected override void WriteLog(string logRecord)
        {
            Console.WriteLine("Here should be logging");
        }
        
        protected override bool WriteObjectMethod010CheckOutputObject(object obj)
        {
            this.WriteVerbose(this, "OutputMethod010CheckOutputObject TMX");
            
            return true;
        }

        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object obj)
        {
            this.WriteVerbose(this, "OutputMethod020Highlight TMX");
        }
        
        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod030RunScriptBlocks TMX");
        }
        
        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod040SetTestResult TMX");
        }
        
        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod050OnSuccessDelay TMX");
        }
        
        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        {
            
            try {

                    base.WriteObject(outputObject);
            }
            catch {}
        }
        
        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod070Report TMX");
        }
        
        protected override void WriteObjectMethod080ReportFailure()
        {
            this.WriteVerbose(this, "OutputMethod070Report TMX");
        }

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
