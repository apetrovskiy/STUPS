/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/19/2012
 * Time: 12:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of WaitUIAEventRaisedCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAEventRaised")]
    public class WaitUIAEventRaisedCommand : WaitCmdletBase
    {
        public WaitUIAEventRaisedCommand()
        {
        }
        
        [Parameter(Mandatory = false)]
        //public new string[] ControlType { get; set; }
        public string[] ControlType { get; set; }
        [Parameter(Mandatory = false)]
        //public new string Name { get; set; }
        public string[] Name { get; set; }
        [Parameter(Mandatory = false)]
        //public new string AutomationId { get; set; }
        public string[] AutomationId { get; set; }
        [Parameter(Mandatory = false)]
        //public new string Name { get; set; }
        public string[] EventId { get; set; }
        
        protected override void BeginProcessing()
        {
            this.startDate = System.DateTime.Now;
        }
        
        protected override void ProcessRecord()
        {
            
            bool notFoundYet = true;
            
            do {
                
                if (CurrentData.LastEventInfoAdded) {
                    string name = string.Empty;
                    string automaitonId = string.Empty;
                    string controlType = string.Empty;
                    string eventId = string.Empty;

                    try {
                        name = CurrentData.LastEventSource.Cached.Name;
                    }
                    catch {}

                    try {
                        automaitonId = CurrentData.LastEventSource.Cached.AutomationId;
                    }
                    catch {}
                    
                    try {
                        controlType = CurrentData.LastEventSource.Cached.ControlType.ProgrammaticName;
                        controlType = controlType.Substring(12);
                    }
                    catch {}

                    try {
                        eventId = CurrentData.LastEventType;
                    }
                    catch {}
                    
                    if (this.Name != null &&
                        this.Name.Length > 0) {
                        notFoundYet = !IsInArray(name, this.Name);
                    }
                    
                    if (this.AutomationId != null &&
                        this.AutomationId.Length > 0) {
                        notFoundYet = !IsInArray(automaitonId, this.AutomationId);
                    }
                    
                    if (this.ControlType != null &&
                        this.ControlType.Length > 0) {
                        notFoundYet = !IsInArray(controlType, this.ControlType);
                    }
                    
                    if (this.EventId != null &&
                        this.EventId.Length > 0) {
                        notFoundYet = !IsInArray(eventId, this.EventId);
                    }
                }
                
                //System.Threading.Thread.Sleep(100);
                SleepAndRunScriptBlocks(this);
                System.DateTime nowDate = System.DateTime.Now;

                if ((nowDate - startDate).TotalSeconds > this.Timeout / 1000)
                {
                    ErrorRecord err =
                        new ErrorRecord(
                            new Exception("Failed to catch the event"),
                            "NoEventFound",
                            ErrorCategory.ObjectNotFound,
                            null);
                    err.ErrorDetails = 
                        new ErrorDetails(
                            "Could not catch the event");
                    WriteError(this, err, true);
                }
                
                if (!notFoundYet) {
                    CurrentData.LastEventInfoAdded = false;
                    WriteObject(this, CurrentData.LastEventSource);
                }
                
            } while (notFoundYet);
        }
        
        private bool IsInArray(string whatToSearch, string[] whereToSearch)
        {
            bool result = false;
            for (int i = 0; i < whereToSearch.Length; i++) {
                if (whatToSearch.ToUpper() == whereToSearch[i].ToUpper()) {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
