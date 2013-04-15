/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/12/2013
 * Time: 8:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Win32Utils
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
            
            if (!UnitTestMode && !ModuleAlreadyLoaded) {

//                DataFactory.AutofacModule = new DataModule();
//
//                DataFactory.Init();
//
//                ModuleAlreadyLoaded = true;
            }
            
            //CurrentData.Init();
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
        }
        
        internal static bool ModuleAlreadyLoaded { get; set; }
        
        protected override void WriteLog(string logRecord)
        {
            Console.WriteLine("Here should be logging Win32");
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
            this.WriteVerbose(this, " Win32");
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " Win32");
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            this.WriteVerbose(this, " Win32");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " Win32");
        }

        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot Data");
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " Win32");
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
            this.WriteVerbose(this, " Win32");
        }
    }
}
