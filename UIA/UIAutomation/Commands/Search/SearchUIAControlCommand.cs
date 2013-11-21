// /*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 4/5/2012
// * Time: 6:16 PM
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
//    /// Description of SearchUiaControlCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Search, "UiaControl", DefaultParameterSetName = "UiaWildCard")]
//    public class SearchUiaControlCommand : SearchCmdletBase
//    {
//        public SearchUiaControlCommand()
//        {
//        }
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
//                    false);
//                
//            } // 20120824
//            
//        }
//    }
//}
