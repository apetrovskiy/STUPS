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
            // 20130329
            this.Id = string.Empty;
            
            // 20130605
            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
                TestData.InitTestData();
            }
            
            //
            this.TestPlatformId = TestData.CurrentTestPlatform.Id;
        }
        
        #region Parameters
        
        // 20130330
        [Parameter(Mandatory = false)]
        // 20130331
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "DualLogic")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "EnumLogic")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "DefaultLogicName")]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }
        
        // 20130330
        [Parameter(Mandatory = false)]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "DualLogic")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "EnumLogic")]
        //[Parameter(Mandatory = true,
        //           ParameterSetName = "DefaultLogicId")]
        //[ValidateNotNullOrEmpty()]
        public string Id { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string TestPlatformId { get; set; }
        
        // 20130325
        [Parameter(Mandatory = false)]
        internal new SwitchParameter TestPassed { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter KnownIssue { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter TestLog { get; set; }
        
//        [Parameter(Mandatory = false)]
//        [AllowNull]
//        [AllowEmptyString]
//        public string Description { get; set; }
        
//        [Parameter(Mandatory = false)]
//        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string TestResultName { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string TestResultId { get; set; }
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
        
        // 20130430
//        protected override void WriteLog(string logRecord)
//        {
//            Console.WriteLine("Here should be logging TMX");
//        }
        
        // 20130430
        //protected override void WriteLog(string logRecord)
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            if (!Preferences.AutoLog) return;
            //TMX.Logger.Info(logRecord);
                
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
                    //default:
                    //    throw new Exception("Invalid value for LogLevels");
            }

            /*
            if (Preferences.AutoLog) {
                //TMX.Logger.Info(logRecord);
                
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
            //this.WriteVerbose(this, " TMX");
        }

    }
}
