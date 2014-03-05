/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/28/2014
 * Time: 1:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
    using System.Collections.Generic;
    using System.Linq;
    // using System.Management.Automation;
    
    /// <summary>
    /// Description of ControlFromUiaComProvider.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromUiaComProvider : ControlProviderTemplate
    {
        public Condition Condition { get; set; }
        public TreeScope TreeScope { get; set; }
        
        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
        {
            return new List<IUiElement>();
        }
    }
}
