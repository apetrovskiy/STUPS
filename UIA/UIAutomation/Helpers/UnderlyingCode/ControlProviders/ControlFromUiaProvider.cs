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
    extern alias UIANET;using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;
//    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
//    using System.Management.Automation;
//    using PSTestLib;
    
    /// <summary>
    /// Description of ControlFromUiaProvider.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromUiaProvider : ControlProviderTemplate
    {
        public classic.Condition Condition { get; set; }
        public classic.TreeScope TreeScope { get; set; }
        
        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
        {
            return new List<IUiElement>();
        }
    }
}
