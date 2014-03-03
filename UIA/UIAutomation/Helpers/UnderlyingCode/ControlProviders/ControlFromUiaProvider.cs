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
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
//    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
//    using System.Management.Automation;
//    using PSTestLib;
    
    /// <summary>
    /// Description of ControlFromUiaProvider.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromUiaProvider : ControlProvider
    {
        public Condition Condition { get; set; }
        public TreeScope TreeScope { get; set; }
        
        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
        {
            return new List<IUiElement>();
        }
    }
}
