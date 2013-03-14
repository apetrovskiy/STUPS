/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/13/2013
 * Time: 8:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of Win32CmdletBase.
    /// </summary>
    public class Win32CmdletBase : GetControlCmdletBase
    {
        public Win32CmdletBase()
        {
        }
        
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string ContainsText { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Value { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string AutomationId { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Class { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string ControlType { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter Win32 { get; set; }
        
        [Parameter (Mandatory = false)]
        internal new SwitchParameter FromCache { get; set; }

        [Parameter(Mandatory = false)]
        internal new SwitchParameter CaseSensitive { get; set; }
        #endregion Parameters
    }
}
