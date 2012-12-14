/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ESXiMgmt
{
    using System;
    using System.Management.Automation;
    
    using PSTestLib;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    public class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
        }
        
        
        //public override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        protected override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        {
            bool result = false;
            
            WriteVerbose(this, "WriteObjectMethod010CheckOutputObject ESXiMgmt");
            
            return result;
        }
        
        protected override void WriteLog(string logRecord)
        {
            Console.WriteLine("Here should be logging");
        }
        
        //public override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object square)
        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, "WriteObjectMethod020Highlight ESXiMgmt");
        }
        
        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, "WriteObjectMethod030RunScriptBlocks ESXiMgmt");
        }
        
        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, " ESXiMgmt");
            
            try {
                this.WriteObject(outputObject);
            }
            catch {}
        }
        
        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, " ESXiMgmt");
        }
        
        protected override void WriteObjectMethod080ReportFailure()
        {
            WriteVerbose(this, " ESXiMgmt");
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
