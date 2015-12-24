/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2014
 * Time: 6:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections.Generic;

    /// <summary>
    /// Description of ControlFromUiaProvider.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromUiaProvider : ControlProviderTemplate
    {
        public classic.Condition Condition { get; set; }
        public classic.TreeScope TreeScope { get; set; }
        
//        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
//        {
//            return new List<IUiElement>();
//        }
        
        internal override List<IUiElement> FilterElements(SingleControlSearcherData controlSearcherData, List<IUiElement> initialCollection)
        {
            return ResultCollection;
        }
        
        internal override List<IUiElement> LoadElements(SingleControlSearcherData controlSearcherData)
        {
            return ResultCollection;
        }
    }
}
