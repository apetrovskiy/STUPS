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
            this.StartDate = System.DateTime.Now;
        }
        
        protected override void ProcessRecord()
        {
            
            bool notFoundYet = true;
            
            do {
this.WriteTrace(this, "do");
                if (CurrentData.LastEventInfoAdded) {
this.WriteTrace(this, "if (CurrentData.LastEventInfoAdded)");
                    string name = string.Empty;
                    string automationId = string.Empty;
                    string controlType = string.Empty;
                    string eventId = string.Empty;

                    try {
this.WriteTrace(this, "name 1");
                        name = CurrentData.LastEventSource.Cached.Name;
this.WriteTrace(this, "name 2");
                    }
                    catch {}

                    try {
this.WriteTrace(this, "auId 1");
                        automationId = CurrentData.LastEventSource.Cached.AutomationId;
this.WriteTrace(this, "auId 2");
                    }
                    catch {}
                    
                    try {
this.WriteTrace(this, "type 1");
                        controlType = CurrentData.LastEventSource.Cached.ControlType.ProgrammaticName;
this.WriteTrace(this, "type 2");
                        controlType = controlType.Substring(12);
this.WriteTrace(this, "type 3");
                    }
                    catch {}

                    try {
this.WriteTrace(this, "eventId 1");
                        eventId = CurrentData.LastEventType;
this.WriteTrace(this, eventId);
this.WriteTrace(this, "eventId 2");
                    }
                    catch {}
                    //System.Windows.Automation.Peers.AutomationEvents.
                    //System.Windows.Automation.Peers.PatternInterface.Dock
                    if (this.Name != null &&
                        this.Name.Length > 0) {
this.WriteTrace(this, "name 001");
                        notFoundYet = !IsInArray(name, this.Name);
this.WriteTrace(this, "name 002");
                    }
                    
                    if (this.AutomationId != null &&
                        this.AutomationId.Length > 0) {
this.WriteTrace(this, "auId 001");
                        notFoundYet = !IsInArray(automationId, this.AutomationId);
this.WriteTrace(this, "auId 002");
                    }
                    
                    if (this.ControlType != null &&
                        this.ControlType.Length > 0) {
this.WriteTrace(this, "type 001");
                        notFoundYet = !IsInArray(controlType, this.ControlType);
this.WriteTrace(this, "type 002");
                    }
                    
                    if (this.EventId != null &&
                        this.EventId.Length > 0) {
this.WriteTrace(this, "eventId 001");
                        notFoundYet = !IsInArray(eventId, this.EventId);
this.WriteTrace(this, "eventId 002");
                    }
                }
                
                //System.Threading.Thread.Sleep(100);
                SleepAndRunScriptBlocks(this);
                System.DateTime nowDate = System.DateTime.Now;

                if ((nowDate - StartDate).TotalSeconds > this.Timeout / 1000)
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
