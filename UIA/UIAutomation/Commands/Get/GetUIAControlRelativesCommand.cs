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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of GetUIAControlChildrenCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlChildren", DefaultParameterSetName = "UIAWildCard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlChildrenCommand : GetRelativesCmdletBase
    {
        #region Constructor
        public GetUIAControlChildrenCommand()
        {
        }
        #endregion Constructor

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
        #region Constructor
        public GetUIAControlDescendantsCommand()
        {
        }
        #endregion Constructor

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
        #region Constructor
        public GetUIAControlParentCommand()
        {
        }
        #endregion Constructor

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
        #region Constructor
        public GetUIAControlAncestorsCommand()
        {
        }
        #endregion Constructor

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
        #region Constructor
        public GetUIAControlNextSiblingCommand()
        {
        }
        #endregion Constructor

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
        #region Constructor
        public GetUIAControlPreviousSiblingCommand()
        {
        }
        #endregion Constructor

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
        #region Constructor
        public GetUIAControlFirstChildCommand()
        {
        }
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // 20120824
            foreach (AutomationElement inputObject in this.InputObject) {
            
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
        #region Constructor
        public GetUIAControlLastChildCommand()
        {
        }
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // 20120824
            foreach (AutomationElement inputObject in this.InputObject) {
                GetAutomationElementsChildren(inputObject, false);
            } // 20120824
            
        }
    }
}
