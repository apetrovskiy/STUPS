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

    /// <summary>
    /// Description of StopUiaCachedModeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "UiaCachedMode")]
    public class StopUiaCachedModeCommand : CacheRequestCmdletBase
    {
        protected override void BeginProcessing()
        {
            try {
                // 20140208
                // CurrentData.CacheRequest.Pop();
                CurrentData.CacheRequest = null;
                Preferences.FromCache = false;
                // 20140208
                Preferences.CacheRequestCalled = false;
                WriteObject(this, true);
            }
            catch (Exception eCacheRequest) {
                
                WriteError(
                    this,
                    "Unable to stop cache request. " +
                    eCacheRequest.Message,
                    "CacheRequestFailedToPop",
                    ErrorCategory.InvalidOperation,
                    true);

                // TODO
                //this.WriteError();
            }
        }
    }
}
