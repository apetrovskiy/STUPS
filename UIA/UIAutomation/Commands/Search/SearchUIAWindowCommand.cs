///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 4/9/2012
// * Time: 9:48 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace UIAutomation.Commands
//{
//    using System;
//    using System.Management.Automation;
//    using System.Windows.Automation;
//    
//    /// <summary>
//    /// Description of SearchUIAWindowCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Search, "UIAWindow", DefaultParameterSetName = "UIAWildCard")]
//    public class SearchUIAWindowCommand : SearchCmdletBase
//    {
//        public SearchUIAWindowCommand()
//        {
//        }
//        
//        #region Parameters
////        [Parameter(Mandatory = false)]
////        internal new AutomationElement InputObject { get; set; }
//        [Parameter(Mandatory = false)]
//        internal new string[] ControlType { get; set; }
//        #endregion Parameters
//        
//        protected override void ProcessRecord()
//        {
//            this.caseSensitive = this.CaseSensitive;
//            
//            // 20120824
//            foreach (AutomationElement inputObject in this.InputObject) {
//            
//                GetAutomationElementsViaWildcards(
//                    // 20120824
//                    inputObject,
//                    this.CaseSensitive,
//                    false,
//                    true);
//                
//            } // 20120824
//
//        }
//    }
//}
