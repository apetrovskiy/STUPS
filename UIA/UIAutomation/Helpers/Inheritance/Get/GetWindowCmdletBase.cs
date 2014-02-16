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
            Class = string.Empty;
            AutomationId = string.Empty;
            Recurse = false;
            UseNameAuIdClass = true;
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   ValueFromPipeline = true,
                   ParameterSetName = "Process1",
                   HelpMessage="Accepts a process object")]
        [Alias("Process", "p")]
        public new Process[] InputObject { get; set; }
        
        [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "Win32")]
        public SwitchParameter Win32 { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UIA",
                   HelpMessage="Accepts the name (title) of a window")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Alias("Title")]
        public string[] Name { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UIA",
                   HelpMessage="Accepts AutomationId of a window")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        public string AutomationId { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UIA",
                   HelpMessage="Accepts ClassName of a window")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        public string Class { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName",
                   HelpMessage="Accepts the name of a process")]
        [Alias("pn")]
        public string[] ProcessName { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId",
                   HelpMessage="Accepts Id of a process (PID)")]
        [Alias("pid")]
        public int[] ProcessId { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIA")]
        public SwitchParameter First { get; set; }

        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "ProcessName")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process")]
        // experimental
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIA")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Process1")]
        public SwitchParameter Recurse { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public Hashtable[] WithControl { get; set; }
        
        [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "UIA")]
        internal SwitchParameter UseNameAuIdClass { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        internal new Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
    }
}
