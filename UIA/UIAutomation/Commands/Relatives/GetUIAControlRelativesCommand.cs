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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

//    /// <summary>
//    /// Description of GetUiaControlChildrenCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlChildren", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlChildrenCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            GetAutomationElements(TreeScope.Children);
//        }
//    }
//    
//    /// <summary>
//    /// Description of GetUiaControlDescendantsCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlDescendants", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlDescendantsCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            GetAutomationElements(classic.TreeScope.Descendants);
//        }
//    }
//    
//    /// <summary>
//    /// Description of GetUiaControlParentCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlParent", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlParentCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            GetAutomationElements(TreeScope.Parent);
//        }
//    }
//    
//    /// <summary>
//    /// Description of GetUiaControlAncestorsCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlAncestors", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlAncestorsCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            GetAutomationElements(TreeScope.Ancestors);
//        }
//    }
    
//    /// <summary>
//    /// Description of GetUiaControlNextSiblingCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlNextSibling", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlNextSiblingCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            GetAutomationElementsSiblings(true);
//        }
//    }
//    
//    /// <summary>
//    /// Description of GetUiaControlPreviousSiblingCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlPreviousSibling", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlPreviousSiblingCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            GetAutomationElementsSiblings(false);
//        }
//    }
//    
//    /// <summary>
//    /// Description of GetUiaControlFirstChildCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlFirstChild", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlFirstChildCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            // 20120824
//            // 20131109
//            //foreach (AutomationElement inputObject in this.InputObject) {
//            foreach (IUiElement inputObject in InputObject) {
//            
//                GetAutomationElementsChildren(inputObject, true);
//            
//            } // 20120824
//        }
//    }
//    
//    /// <summary>
//    /// Description of GetUiaControlLastChildCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "UiaControlLastChild", DefaultParameterSetName = "UiaWildCard")]
//    
//    public class GetUiaControlLastChildCommand : GetRelativesCmdletBase
//    {
//        /// <summary>
//        /// Processes the pipeline.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//            foreach (IUiElement inputObject in InputObject) {
//                
//                GetAutomationElementsChildren(inputObject, false);
//            } // 20120824
//            
//        }
//    }
}
