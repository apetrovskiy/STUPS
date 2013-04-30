/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/2/2012
 * Time: 7:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS
{
    using System;
    using System.Management.Automation;
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
        
        // 20130430
//        protected override void WriteLog(string logRecord)
//        {
//            Console.WriteLine("Here should be logging TAMS");
//        }
        
        // 20130430
//        protected override void WriteLog(string logRecord)
//        {
//            if (Preferences.AutoLog) {
//                TMX.Logger.Info(logRecord);
//            }
//        }
        
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            if (Preferences.AutoLog) {
                
                switch (logLevel) {
                    case LogLevels.Fatal:
                        TMX.Logger.Fatal(logRecord);
                        break;
                    case LogLevels.Error:
                        TMX.Logger.Error(logRecord);
                        break;
                    case LogLevels.Warn:
                        TMX.Logger.Warn(logRecord);
                        break;
                    case LogLevels.Info:
                        TMX.Logger.Info(logRecord);
                        break;
                    case LogLevels.Debug:
                        TMX.Logger.Debug(logRecord);
                        break;
                    case LogLevels.Trace:
                        TMX.Logger.Trace(logRecord);
                        break;
                }
            }
        }
        
#region commented
//        protected override bool WriteObjectMethod010CheckOutputObject(object outputObject)
//        {
//            bool result = false;
//            
//            
//            
//            return result;
//        }
//        
//        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//        }
//        
//        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//        }
//        
//        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//        }
//        
//        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//        }
//        
//        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//        }
//        
//        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//        }
//        
//        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
//        {
//            
//        }
//        
//        protected override void WriteObjectMethod080ReportFailure()
//        {
//            
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
            //WriteVerbose(this, " TAMS");
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
            
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            
        }
        
        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            
        }
        
//        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
//        {
//            
//        }
        
        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            if (terminating) {
                //this.WriteVerbose(this, "terminating error !!!");
                try {
                    
                    // 20130430
                    WriteLog(LogLevels.Fatal, errorRecord);
                    
                    ThrowTerminatingError(errorRecord);
                }
                catch {}
            } else {
                //this.WriteVerbose(this, "regular error !!!");
                try {
                    
                    // 20130430
                    WriteLog(LogLevels.Error, errorRecord);
                    
                    WriteError(errorRecord);
                }
                catch {}
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            
        }
    }
}
