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
    //    using System.Collections;
    //    using System.Collections.Generic;
    //    using System.Management.Automation;
//
    extern alias UIANET;
    using System;
//    using System.Windows.Automation;
//    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
//    using System.Management.Automation;
//    using PSTestLib;
    
//    using System.Globalization;
//    using System.Threading;
//    using System.Windows.Forms;
//    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of ControlFromUiaProvider.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromUiaProvider : ControlProvider
    {
        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
        {
            return new List<IUiElement>();
        }
    }
}
