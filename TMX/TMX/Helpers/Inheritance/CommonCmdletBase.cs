/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 18/02/2012
 * Time: 01:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    using PSTestLib;
    using System.Collections.ObjectModel;
    using System.Collections;
	using Tmx;
    
    /// <summary>
    /// Description of CmdletBase.
    /// </summary>
    public partial class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
            this.Id = string.Empty;
            
            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
                TestData.InitTestData();
            }
            
            // 20141112
            // removed
            // this.TestPlatformId = TestData.CurrentTestPlatform.Id;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Id { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string TestPlatformId { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter TestPassed { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter KnownIssue { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter TestLog { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string TestResultName { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string TestResultId { get; set; }
        #endregion Parameters
        
        protected void notImplementedCase()
        {
            this.WriteError(
                this,
                "Not implemented",
                "NotImplemented",
                ErrorCategory.NotImplemented,
                true);
        }
        
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            if (!Preferences.AutoLog) return;
            
            // 20140314
            // turning off the logger
            return;
            
            //Tmx.Logger.Info(logRecord);
                
//            switch (logLevel) {
//                case LogLevels.Fatal:
//                    Tmx.Logger.Fatal(logRecord);
//                    break;
//                case LogLevels.Error:
//                    Tmx.Logger.Error(logRecord);
//                    break;
//                case LogLevels.Warn:
//                    Tmx.Logger.Warn(logRecord);
//                    break;
//                case LogLevels.Info:
//                    Tmx.Logger.Info(logRecord);
//                    break;
//                case LogLevels.Debug:
//                    Tmx.Logger.Debug(logRecord);
//                    break;
//                case LogLevels.Trace:
//                    Tmx.Logger.Trace(logRecord);
//                    break;
//                    //default:
//                    //    throw new Exception("Invalid value for LogLevels");
//            }

            /*
            if (Preferences.AutoLog) {
                //Tmx.Logger.Info(logRecord);
                
                switch (logLevel) {
                    case LogLevels.Fatal:
                        Tmx.Logger.Fatal(logRecord);
                        break;
                    case LogLevels.Error:
                        Tmx.Logger.Error(logRecord);
                        break;
                    case LogLevels.Warn:
                        Tmx.Logger.Warn(logRecord);
                        break;
                    case LogLevels.Info:
                        Tmx.Logger.Info(logRecord);
                        break;
                    case LogLevels.Debug:
                        Tmx.Logger.Debug(logRecord);
                        break;
                    case LogLevels.Trace:
                        Tmx.Logger.Trace(logRecord);
                        break;
                    //default:
                    //    throw new Exception("Invalid value for LogLevels");
                }
            }
            */
        }

        protected void WriteLog(LogLevels logLevel, System.Management.Automation.ErrorRecord errorRecord)
        {
            if (!Preferences.AutoLog) return;
            this.WriteLog(logLevel, errorRecord.Exception.Message);
            this.WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());

            /*
            if (Preferences.AutoLog) {
                
                this.WriteLog(logLevel, errorRecord.Exception.Message);
                this.WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());
            }
            */
        }
        
//        protected void WriteLog(NLog.LogLevel logLevel, string logRecord)
//        {
//            
//        }
        
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
                // 20140314
                // base.WriteObject(outputObject);
                WriteObject(outputObject);
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
        
        // 20131113
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
            //this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            //this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            //this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            //this.WriteVerbose(this, " TMX");
        }

        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            //WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot TMX");
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            //this.WriteVerbose(this, " TMX");
        }

        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            if (terminating) {
                //this.WriteVerbose(this, "terminating error !!!");
                try {
                    // 20130430
                    // 20140317
                    // turning off the logger
                    // WriteLog(LogLevels.Fatal, errorRecord);
                    
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
            //this.WriteVerbose(this, " TMX");
        }

    }
}
