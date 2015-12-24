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

    /// <summary>
    /// Description of GetControlCmdletBase.
    /// </summary>
    public class GetControlCmdletBase : GetCmdletBase
    {
        #region Constructor
        public GetControlCmdletBase()
        {
            Class = string.Empty;
            Name = string.Empty;
            AutomationId = string.Empty;
            Value = string.Empty;
            
            InputObject =
                new IUiElement[] { CurrentData.CurrentWindow };
            
            // CacheRequest
            FromCache = Preferences.FromCache;
            
            Regex = false;
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "UiaSearch")]
        public virtual string ContainsText { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        [Alias("Title")]
        public virtual string Name { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual string Value { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual string AutomationId { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        [Alias("ClassName")]
        public virtual string Class { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual string[] ControlType { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaSearch")]
        public virtual SwitchParameter Win32 { get; set; }
        
        [Parameter (Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual SwitchParameter FromCache { get; set; }
        
        [Parameter (Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        public SwitchParameter Regex { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter CaseSensitive { get; set; }
        
        // 20131203
        [Parameter (Mandatory = false)]
        public SwitchParameter Force { get; set; }
        #endregion Parameters

    }
}
