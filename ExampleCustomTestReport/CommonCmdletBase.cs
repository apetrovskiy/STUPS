/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2012
 * Time: 12:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ExampleCustomTestReport
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
        
        protected override void WriteObjectMethod080ReportFailure()
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteLog(string logRecord)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            throw new NotImplementedException();
        }
        
        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet)
        {
            throw new NotImplementedException();
        }
    }
}
