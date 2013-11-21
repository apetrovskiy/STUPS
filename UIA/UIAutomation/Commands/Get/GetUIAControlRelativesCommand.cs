/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01.02.2012
 * Time: 12:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of GetUIAControlChildrenCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlChildren", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlChildrenCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Children);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlDescendantsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlDescendants", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlDescendantsCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Descendants);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlParentCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlParent", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlParentCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Parent);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlAncestorsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlAncestors", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlAncestorsCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Ancestors);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlNextSiblingCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlNextSibling", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlNextSiblingCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElementsSiblings(true);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlPreviousSiblingCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlPreviousSibling", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlPreviousSiblingCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElementsSiblings(false);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlFirstChildCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlFirstChild", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlFirstChildCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // 20120824
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IMySuperWrapper inputObject in this.InputObject) {
            
                GetAutomationElementsChildren(inputObject, true);
            
            } // 20120824
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlLastChildCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlLastChild", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlLastChildCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // 20120824
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IMySuperWrapper inputObject in this.InputObject) {
                
                GetAutomationElementsChildren(inputObject, false);
            } // 20120824
            
        }
    }
}
