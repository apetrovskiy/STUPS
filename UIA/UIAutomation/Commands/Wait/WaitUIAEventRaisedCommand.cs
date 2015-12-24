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
    using Helpers.Commands;
    
    /// <summary>
    /// Description of WaitUiaEventRaisedCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaEventRaised")]
    public class WaitUiaEventRaisedCommand : WaitCmdletBase
    {
        [UiaParameter][Parameter(Mandatory = false)]
        //public new string[] ControlType { get; set; }
        public string[] ControlType { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        //public new string Name { get; set; }
        public string[] Name { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        //public new string AutomationId { get; set; }
        public string[] AutomationId { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        //public new string Name { get; set; }
        public string[] EventId { get; set; }
        
        protected override void BeginProcessing()
        {
            StartDate = DateTime.Now;
        }
        
        protected override void ProcessRecord()
        {
            var command =
                AutomationFactory.GetCommand<WaitEventRaisedCommand>(this);
            command.Execute();
            
//            bool notFoundYet = true;
//            
//            // TODO: move to SearchTemplate
//            do {
//WriteTrace(this, "do");
//                if (CurrentData.LastEventInfoAdded) {
//WriteTrace(this, "if (CurrentData.LastEventInfoAdded)");
//                    string name = string.Empty;
//                    string automationId = string.Empty;
//                    string controlType = string.Empty;
//                    string eventId = string.Empty;
//
//                    try {
//WriteTrace(this, "name 1");
//                        name = CurrentData.LastEventSource.Cached.Name;
//WriteTrace(this, "name 2");
//                    }
//                    catch {}
//
//                    try {
//WriteTrace(this, "auId 1");
//                        automationId = CurrentData.LastEventSource.Cached.AutomationId;
//WriteTrace(this, "auId 2");
//                    }
//                    catch {}
//                    
//                    try {
//WriteTrace(this, "type 1");
//                        controlType = CurrentData.LastEventSource.Cached.ControlType.ProgrammaticName;
//WriteTrace(this, "type 2");
//                        controlType = controlType.Substring(12);
//WriteTrace(this, "type 3");
//                    }
//                    catch {}
//
//                    try {
//WriteTrace(this, "eventId 1");
//                        eventId = CurrentData.LastEventType;
//WriteTrace(this, eventId);
//WriteTrace(this, "eventId 2");
//                    }
//                    catch {}
//                    //System.Windows.Automation.Peers.AutomationEvents.
//                    //System.Windows.Automation.Peers.PatternInterface.Dock
//                    if (Name != null &&
//                        Name.Length > 0) {
//WriteTrace(this, "name 001");
//                        notFoundYet = !IsInArray(name, Name);
//WriteTrace(this, "name 002");
//                    }
//                    
//                    if (AutomationId != null &&
//                        AutomationId.Length > 0) {
//WriteTrace(this, "auId 001");
//                        notFoundYet = !IsInArray(automationId, AutomationId);
//WriteTrace(this, "auId 002");
//                    }
//                    
//                    if (ControlType != null &&
//                        ControlType.Length > 0) {
//WriteTrace(this, "type 001");
//                        notFoundYet = !IsInArray(controlType, ControlType);
//WriteTrace(this, "type 002");
//                    }
//                    
//                    if (EventId != null &&
//                        EventId.Length > 0) {
//WriteTrace(this, "eventId 001");
//                        notFoundYet = !IsInArray(eventId, EventId);
//WriteTrace(this, "eventId 002");
//                    }
//                }
//                
//                //System.Threading.Thread.Sleep(100);
//                SleepAndRunScriptBlocks(this);
//                DateTime nowDate = DateTime.Now;
//
//                if ((nowDate - StartDate).TotalSeconds > Timeout / 1000)
//                {
//                    this.WriteError(
//                        this,
//                        "Failed to catch the event",
//                        "NoEventFound",
//                        ErrorCategory.ObjectNotFound,
//                        true);
//                }
//
//                if (notFoundYet) continue;
//                CurrentData.LastEventInfoAdded = false;
//                WriteObject(this, CurrentData.LastEventSource);
//
//            } while (notFoundYet);
        }
        
//        private bool IsInArray(string whatToSearch, IEnumerable<string> whereToSearch)
//        {
//            return whereToSearch.Any(t => String.Equals(whatToSearch, t, StringComparison.CurrentCultureIgnoreCase));
//        }
    }
}
