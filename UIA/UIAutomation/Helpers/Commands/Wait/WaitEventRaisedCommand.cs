/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/12/2014
 * Time: 11:20 AM
 * 
 * To change cmdlet template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
    using System.Linq;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of WaitEventRaisedCommand.
    /// </summary>
    public class WaitEventRaisedCommand : UiaCommand
    {
        public WaitEventRaisedCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet = (WaitUiaEventRaisedCommand)Cmdlet;
            
            bool notFoundYet = true;
            
            // TODO: move to SearchTemplate
            do {
cmdlet.WriteTrace(cmdlet, "do");
                if (CurrentData.LastEventInfoAdded) {
cmdlet.WriteTrace(cmdlet, "if (CurrentData.LastEventInfoAdded)");
                    string name = string.Empty;
                    string automationId = string.Empty;
                    string controlType = string.Empty;
                    string eventId = string.Empty;

                    try {
cmdlet.WriteTrace(cmdlet, "name 1");
                        // 20140312
                        // name = CurrentData.LastEventSource.Cached.Name;
                        // name = (CurrentData.LastEventSource as ISupportsCached).Cached.Name;
                        name = CurrentData.LastEventSource.GetCached().Name;
cmdlet.WriteTrace(cmdlet, "name 2");
                    }
                    catch {}

                    try {
cmdlet.WriteTrace(cmdlet, "auId 1");
                        // 20140312
                        // automationId = CurrentData.LastEventSource.Cached.AutomationId;
                        // automationId = (CurrentData.LastEventSource as ISupportsCached).Cached.AutomationId;
                        automationId = CurrentData.LastEventSource.GetCached().AutomationId;
cmdlet.WriteTrace(cmdlet, "auId 2");
                    }
                    catch {}
                    
                    try {
cmdlet.WriteTrace(cmdlet, "type 1");
                        // 20140312
                        // controlType = CurrentData.LastEventSource.Cached.ControlType.ProgrammaticName;
                        // controlType = (CurrentData.LastEventSource as ISupportsCached).Cached.ControlType.ProgrammaticName;
                        controlType = CurrentData.LastEventSource.GetCached().ControlType.ProgrammaticName;
cmdlet.WriteTrace(cmdlet, "type 2");
                        controlType = controlType.Substring(12);
cmdlet.WriteTrace(cmdlet, "type 3");
                    }
                    catch {}

                    try {
cmdlet.WriteTrace(cmdlet, "eventId 1");
                        eventId = CurrentData.LastEventType;
cmdlet.WriteTrace(cmdlet, eventId);
cmdlet.WriteTrace(cmdlet, "eventId 2");
                    }
                    catch {}
                    //System.Windows.Automation.Peers.AutomationEvents.
                    //System.Windows.Automation.Peers.PatternInterface.Dock
                    if (cmdlet.Name != null &&
                        cmdlet.Name.Length > 0) {
cmdlet.WriteTrace(cmdlet, "name 001");
                        notFoundYet = !IsInArray(name, cmdlet.Name);
cmdlet.WriteTrace(cmdlet, "name 002");
                    }
                    
                    if (cmdlet.AutomationId != null &&
                        cmdlet.AutomationId.Length > 0) {
cmdlet.WriteTrace(cmdlet, "auId 001");
                        notFoundYet = !IsInArray(automationId, cmdlet.AutomationId);
cmdlet.WriteTrace(cmdlet, "auId 002");
                    }
                    
                    if (cmdlet.ControlType != null &&
                        cmdlet.ControlType.Length > 0) {
cmdlet.WriteTrace(cmdlet, "type 001");
                        notFoundYet = !IsInArray(controlType, cmdlet.ControlType);
cmdlet.WriteTrace(cmdlet, "type 002");
                    }
                    
                    if (cmdlet.EventId != null &&
                        cmdlet.EventId.Length > 0) {
cmdlet.WriteTrace(cmdlet, "eventId 001");
                        notFoundYet = !IsInArray(eventId, cmdlet.EventId);
cmdlet.WriteTrace(cmdlet, "eventId 002");
                    }
                }
                
                //System.Threading.Thread.Sleep(100);
                cmdlet.SleepAndRunScriptBlocks(cmdlet);
                DateTime nowDate = DateTime.Now;

                if ((nowDate - cmdlet.StartDate).TotalSeconds > cmdlet.Timeout / 1000)
                {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to catch the event",
                        "NoEventFound",
                        ErrorCategory.ObjectNotFound,
                        true);
                }

                if (notFoundYet) continue;
                CurrentData.LastEventInfoAdded = false;
                cmdlet.WriteObject(cmdlet, CurrentData.LastEventSource);

            } while (notFoundYet);
        }
        
        private bool IsInArray(string whatToSearch, IEnumerable<string> whereToSearch)
        {
            return whereToSearch.Any(t => String.Equals(whatToSearch, t, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
