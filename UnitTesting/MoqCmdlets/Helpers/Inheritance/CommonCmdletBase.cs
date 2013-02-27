/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 10:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace MoqCmdlets
{
    using System;
    using System.Management.Automation;
    using Moq;
    using PSTestLib;
    using System.Collections.ObjectModel;
    using System.Collections;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    public class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
        }
        
        protected override void WriteLog(string logRecord)
        {
            Console.WriteLine("Here should be logging");
        }
        
#region commented
//        protected override bool WriteObjectMethod010CheckOutputObject(object obj)
//        {
//            this.WriteVerbose(this, "OutputMethod010CheckOutputObject Moq");
//            
//            return true;
//        }

//        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object obj)
//        {
//            this.WriteVerbose(this, "OutputMethod020Highlight Moq");
//        }
//        
//        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
//        {
//            this.WriteVerbose(this, "OutputMethod030RunScriptBlocks Moq");
//        }
//        
//        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
//        {
//            this.WriteVerbose(this, "OutputMethod040SetTestResult Moq");
//        }
//        
//        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
//        {
//            this.WriteVerbose(this, " Moq");
//        }
//        
//        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
//        {
//            this.WriteVerbose(this, "OutputMethod050OnSuccessDelay Moq");
//        }
//        
//        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//            try {
//
////                //if (this.UnitTestMode) {
////                if (PSCmdletBase.UnitTestMode) {
////    
////                    if (null == UnitTestOutput) {
////
////                        UnitTestOutput =
////                           new System.Collections.Generic.List<object>();
////                    }
////                    UnitTestOutput.Add(outputObject);
////                } else {
//                    base.WriteObject(outputObject);
////                }
//            }
//            catch {}
//        }
//        
//        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
//        {
//            this.WriteVerbose(this, "OutputMethod070Report Moq");
//        }
//        
//        protected override void WriteObjectMethod080ReportFailure()
//        {
//            this.WriteVerbose(this, "OutputMethod070Report Moq");
//        }
#endregion commented
        
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
            WriteVerbose(this, " Moq");
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
            this.WriteVerbose(this, " Moq");
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " Moq");
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            this.WriteVerbose(this, " Moq");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " Moq");
        }

        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot Moq");
//            if (SePSX.Preferences.OnErrorScreenShot) {
//                UIAutomation.UIAHelper.GetDesktopScreenshot(
//                    this,
//                    string.Empty,
//                    true,
//                    0,
//                    0,
//                    0,
//                    0,
//                    string.Empty,
//                    SePSX.Preferences.OnErrorScreenShotFormat);
//            }
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " Moq");
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
            this.WriteVerbose(this, " Moq");
        }
    }
}
