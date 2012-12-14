/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/11/2012
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of StopUIACacheRequestCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "UIACacheRequest")]
    public class StopUIACacheRequestCommand : CacheRequestCmdletBase
    {
        public StopUIACacheRequestCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            try {
                CurrentData.CacheRequest.Pop();
                CurrentData.CacheRequest = null;
                Preferences.FromCache = false;
                this.WriteObject(this, true);
            }
            catch (Exception eCacheRequest) {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Unable to stop cache request"),
                        "CacheRequestFailedToPop",
                        ErrorCategory.InvalidOperation,
                        null);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to stop a cache request\r\n" +
                        eCacheRequest.Message);
                WriteError(this, err, true);
            }
        }
    }
}
