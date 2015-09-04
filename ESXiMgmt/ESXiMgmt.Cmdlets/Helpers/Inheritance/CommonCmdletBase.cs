/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets
{
    using System.Management.Automation;
    using PSTestLib;
    using System.Collections;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    public class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
        }
        
#region commented
//        protected override bool WriteObjectMethod010CheckOutputObject(object outputObject)
//        {
//            bool result = false;
//            
//            WriteVerbose(this, "WriteObjectMethod010CheckOutputObject ESXiMgmt");
//            
//            return result;
//        }
#endregion commented
        
        // 20130430
//        //protected override void WriteLog(string logRecord)
//        protected override void WriteLog(LogLevels logLevel, string logRecord)
//        {
//            Console.WriteLine("Here should be logging ESXiMgmt");
//        }
        
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            //if (Preferences.AutoLog) {
                
                // 20140317
                // turning off the logger
//                switch (logLevel) {
//                    case LogLevels.Fatal:
//                        Tmx.Logger.Fatal(logRecord);
//                        break;
//                    case LogLevels.Error:
//                        Tmx.Logger.Error(logRecord);
//                        break;
//                    case LogLevels.Warn:
//                        Tmx.Logger.Warn(logRecord);
//                        break;
//                    case LogLevels.Info:
//                        Tmx.Logger.Info(logRecord);
//                        break;
//                    case LogLevels.Debug:
//                        Tmx.Logger.Debug(logRecord);
//                        break;
//                    case LogLevels.Trace:
//                        Tmx.Logger.Trace(logRecord);
//                        break;
//                }
            //}
        }
        
        protected void WriteLog(LogLevels logLevel, ErrorRecord errorRecord)
        {
            //if (Preferences.AutoLog) {
                
            WriteLog(logLevel, errorRecord.Exception.Message);
            WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());
            //}
        }
        
#region commented
//        //public override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object square)
//        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
//        {
//            WriteVerbose(this, "WriteObjectMethod020Highlight ESXiMgmt");
//        }
//        
//        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
//        {
//            WriteVerbose(this, "WriteObjectMethod030RunScriptBlocks ESXiMgmt");
//        }
//        
//        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
//        {
//            WriteVerbose(this, " ESXiMgmt");
//        }
//        
//        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
//        {
//            WriteVerbose(this, " ESXiMgmt");
//        }
//        
//        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
//        {
//            WriteVerbose(this, " ESXiMgmt");
//        }
//        
//        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
//        {
//            WriteVerbose(this, " ESXiMgmt");
//            
//            try {
//                this.WriteObject(outputObject);
//            }
//            catch {}
//        }
//        
//        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
//        {
//            WriteVerbose(this, " ESXiMgmt");
//        }
//        
//        protected override void WriteObjectMethod080ReportFailure()
//        {
//            WriteVerbose(this, " ESXiMgmt");
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
            WriteVerbose(this, " ESXiMgmt");
            try {
                base.WriteObject(outputObject);
                
//                if (Preferences.AutoLog) {
//                    
//                    string reportString =
//                        CmdletSignature(((CommonCmdletBase)cmdlet));
//                    
//                    reportString +=
//                        
//                    
//                    this.WriteLog(LogLevels.Info, reportString);
//                }
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
        
        // 20131114
        protected override void WriteSingleError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            WriteErrorMethod010RunScriptBlocks(cmdlet);
            
            WriteErrorMethod020SetTestResult(cmdlet, errorRecord);
            
            WriteErrorMethod030ChangeTimeoutSettings(cmdlet, terminating);
            
            WriteErrorMethod040AddErrorToErrorList(cmdlet, errorRecord);
            
            WriteErrorMethod045OnErrorScreenshot(cmdlet);
            
            WriteErrorMethod050OnErrorDelay(cmdlet);
            
            WriteErrorMethod060OutputError(cmdlet, errorRecord, terminating);
            
            WriteErrorMethod070Report(cmdlet);
        }
        
        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        

    }
}
