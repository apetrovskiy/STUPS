/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 19/01/2012
 * Time: 11:32 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Diagnostics;
    using System.Collections;

    /// <summary>
    /// Description of GetWindowCmdletBase.
    /// </summary>
    public class GetWindowCmdletBase : GetCmdletBase
    {
        #region Constructor
        public GetWindowCmdletBase()
        {
            this.Class = string.Empty;
            //this.Name = string.Empty;
            //this.ControlType = string.Empty;
            this.AutomationId = string.Empty;
            
            // 20130222
            //this.Recurse = true;
            // 20130223
            this.Recurse = false;
            
            // 20130224
            this.UseNameAuIdClass = true;
        }
        #endregion Constructor
        
        #region Parameters
        // 20130513
        [Parameter(Mandatory = true,
                   ParameterSetName = "Win32")]
        public SwitchParameter Win32 { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIA",
                   HelpMessage="Accepts the name (title) of a window")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        // 20130513
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]

//        [Parameter(Mandatory = false,
//                   HelpMessage="Accepts the name (title) of a window")]
        [Alias("Title")]
        public string[] Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIA",
                   HelpMessage="Accepts AutomationId of a window")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        // 20130513
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]

//        [Parameter(Mandatory = false,
//                   HelpMessage="Accepts AutomationId of a window")]
        public string AutomationId { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIA",
                   HelpMessage="Accepts ClassName of a window")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        // 20130513
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        
//        [Parameter(Mandatory = false,
//                   HelpMessage="Accepts ClassName of a window")]
        public string Class { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName",
                   HelpMessage="Accepts the name of a process")]
        [Alias("pn")]
        public string[] ProcessName { get; set; }
        
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "Process",
                   HelpMessage="Accepts a process object")]
        [Alias("Process", "p")]
        public new Process[] InputObject { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId",
                   HelpMessage="Accepts Id of a process (PID)")]
        [Alias("pid")]
        public int[] ProcessId { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIA")]
        public SwitchParameter First { get; set; }

        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        // 20130316
        // experimental
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIA")]
        public SwitchParameter Recurse { get; set; }
        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ProcessName")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ProcessId")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "Process")]
        [Parameter(Mandatory = false)]
        public Hashtable[] WithControl { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "UIA")]
        internal SwitchParameter UseNameAuIdClass { get; set; }
        #endregion Parameters
    }
}
