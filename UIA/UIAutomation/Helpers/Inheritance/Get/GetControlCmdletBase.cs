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
    using System.Collections;

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
            // 20131128
            // ControlType = string.Empty;
            AutomationId = string.Empty;
            Value = string.Empty;
            
            InputObject =
                // 20131109
                //new System.Windows.Automation.AutomationElement[] { CurrentData.CurrentWindow };
                new UiElement[] { (UiElement)CurrentData.CurrentWindow };
            
            // CacheRequest
            FromCache = Preferences.FromCache;
            
            // 20130204
//            this.Fake = true;
            
            // 20131122
            Regex = false;
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "UiaSearch")]
        public virtual string ContainsText { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        [Alias("Title")]
        public virtual string Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual string Value { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual string AutomationId { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        [Alias("ClassName")]
        public virtual string Class { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual string[] ControlType { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaSearch")]
        public virtual SwitchParameter Win32 { get; set; }
        
        [Parameter (Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UiaClassic")]
        public virtual SwitchParameter FromCache { get; set; }
        
        [Parameter (Mandatory = false,
                   ParameterSetName = "UiaWildCard")]
        public SwitchParameter Regex { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter CaseSensitive { get; set; }
        
        // 20131203
        [Parameter (Mandatory = false)]
        public SwitchParameter Force { get; set; }
        #endregion Parameters

    }
}
