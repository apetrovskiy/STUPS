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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAStructureChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAStructureChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAStructureChangedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUIAStructureChangedEventCommand()
        {
            base.AutomationEventType = 
                AutomationElement.StructureChangedEvent;
            // base.AutomationEventHandler = OnUIStructureChangedEvent;
            base.StructureChangedEventHandler = 
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
            
            base.Child = this;
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter ChildAdded {get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter ChildRemoved {get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter ChildrenInvalidated {get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter ChildrenBulkAdded {get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter ChildrenBulkRemoved {get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter ChildrenReordered {get; set; }
        #endregion Parameters
    }
}
