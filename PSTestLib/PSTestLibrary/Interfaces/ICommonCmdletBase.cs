/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/22/2012
 * Time: 7:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ICommonCmdletBase.
    /// </summary>
    public interface ICommonCmdletBase
    {
        
        bool WriteObjectMethod010CheckOutputObject(object outputObject);
        void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject);
        void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject);
        void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject);
        void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject);
        void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject);
        void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject);
        void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject);
        void WriteObjectMethod080ReportFailure();
        
        void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet);
        void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord);
        void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating);
        void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord);
        void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet, object outputObject);
        void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet);
        void WriteErrorMethod060OutputResult(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating);
        void WriteErrorMethod070Report(PSCmdletBase cmdlet);
        
        void WriteLog(string logRecord);
    }
}
