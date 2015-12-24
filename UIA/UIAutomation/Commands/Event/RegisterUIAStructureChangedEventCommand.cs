/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaStructureChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaStructureChangedEvent")]
    
    public class RegisterUiaStructureChangedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUiaStructureChangedEventCommand()
        {
            AutomationEventType = 
                classic.AutomationElement.StructureChangedEvent;
            // base.AutomationEventHandler = OnUIStructureChangedEvent;
            StructureChangedEventHandler = 
                OnUIStructureChangedEvent;
            
// ChildAdded = false;
// ChildRemoved = false;
// ChildrenBulkAdded = false;
// ChildrenBulkRemoved = false;
// ChildrenInvalidated = false;
// ChildrenReordered = false;
            
// base.ChildAdded = this.ChildAdded;
// base.ChildRemoved = this.ChildRemoved;
// base.ChildrenBulkAdded = this.ChildrenBulkAdded;
// base.ChildrenBulkRemoved = this.ChildrenBulkRemoved;
// base.ChildrenInvalidated = this.ChildrenInvalidated;
// base.ChildrenReordered = this.ChildrenReordered;

// this.childAdded = this.ChildAdded;
// this.childRemoved = this.ChildRemoved;
// this.childrenBulkAdded = this.ChildrenBulkAdded;
// this.childrenBulkRemoved = this.ChildrenBulkRemoved;
// this.childrenInvalidated = this.ChildrenInvalidated;
// this.childrenReordered = this.ChildrenReordered;
            
            Child = this;
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter ChildAdded {get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter ChildRemoved {get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter ChildrenInvalidated {get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter ChildrenBulkAdded {get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter ChildrenBulkRemoved {get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter ChildrenReordered {get; set; }
        #endregion Parameters
    }
}
