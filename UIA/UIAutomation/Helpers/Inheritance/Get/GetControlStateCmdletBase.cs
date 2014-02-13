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
    using System.Management.Automation;
    using System.Collections;

    /// <summary>
    /// Description of GetControlStateCmdletBase.
    /// </summary>
    public class GetControlStateCmdletBase : GetControlCmdletBase
    {
//        public GetControlStateCmdletBase()
//        {
//        }
        
        #region Parameters
        [My][Parameter(Mandatory = false)]
        internal new string Class { get; set; }
        [My][Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        [My][Parameter(Mandatory = false)]
        internal new string ControlType { get; set; }
        [My][Parameter(Mandatory = false)]
        internal new string AutomationId { get; set; }
        // 20130130
        [My][Parameter(Mandatory = false)]
        internal new string Value { get; set; }
        [My][Parameter(Mandatory = false)]
        internal new string ContainsText { get; set; }
        [My][Parameter(Mandatory = false)]
        internal new SwitchParameter Win32 { get; set; }
        
        // 20130130
        //[My][Parameter(Mandatory = true)]
        [My][Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = "Search")]
        [ValidateNotNullOrEmpty]
        public new Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
        
    }
}
