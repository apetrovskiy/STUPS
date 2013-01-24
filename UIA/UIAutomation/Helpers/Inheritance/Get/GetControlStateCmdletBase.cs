/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 22/02/2012
 * Time: 05:33 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Collections;

    /// <summary>
    /// Description of GetControlStateCmdletBase.
    /// </summary>
    public class GetControlStateCmdletBase : GetControlCmdletBase
    {
        public GetControlStateCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Class { get; set; }
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        [Parameter(Mandatory = false)]
        internal new string ControlType { get; set; }
        [Parameter(Mandatory = false)]
        internal new string AutomationId { get; set; }
        [Parameter(Mandatory = false)]
        internal new SwitchParameter Win32 { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        // 20120917
        //public System.Collections.Hashtable[] SearchCriteria { get; set; }
        public new Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
        
    }
}
