/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/5/2014
 * Time: 10:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    //    using System.Collections;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of ConvertToSearchCriteriaCommand.
    /// </summary>
    public class ConvertToSearchCriteriaCommand : UiaCommand
    {
        public ConvertToSearchCriteriaCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet = (ConvertToUiaSearchCriteriaCommand)Cmdlet;
            
            var converter = AutomationFactory.GetObject<ElementToSearchCriteriaConverter>();
            
//            foreach (IUiElement element in cmdlet.InputObject) {
//                WriteObject(this, ConvertElementToSearchCriteria(element));
//            }
        }
    }
}
