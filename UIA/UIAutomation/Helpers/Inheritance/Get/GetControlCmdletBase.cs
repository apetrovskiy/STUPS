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
    //using System.Windows.Automation;
    
    using System.Collections;

    /// <summary>
    /// Description of GetControlCmdletBase.
    /// </summary>
    public class GetControlCmdletBase : GetCmdletBase
    {
        #region Constructor
        public GetControlCmdletBase()
        {
            this.Class = string.Empty;
            this.Name = string.Empty;
            this.ControlType = string.Empty;
            this.AutomationId = string.Empty;
            this.Value = string.Empty;
            this.InputObject = 
                new System.Windows.Automation.AutomationElement[] { CurrentData.CurrentWindow };
            
            // CacheRequest
            this.FromCache = Preferences.FromCache;
            
            // 20130204
//            this.Fake = true;
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "UIASearch")]
        public string ContainsText { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAClassic")]
        [Alias("Title")]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAClassic")]
        public string Value { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAWildCard")]
        // 20130218
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAClassic")]
        public string AutomationId { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAWildCard")]
        // 20130218
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAClassic")]
        [Alias("ClassName")]
        public string Class { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAWildCard")]
        // 20130218
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAClassic")]
        public string ControlType { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Win32")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIASearch")]
        public SwitchParameter Win32 { get; set; }
        
        [Parameter (Mandatory = false,
                   ParameterSetName = "UIAWildCard")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "UIAClassic")]
        public SwitchParameter FromCache { get; set; }
        
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "First")]
        //public SwitchParameter First { get; set; }
        
        // 20130127
        [Parameter(Mandatory = false)]
        public SwitchParameter CaseSensitive { get; set; }
        
        // 20130204
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "fake")]
//        internal SwitchParameter Fake { get; set; }
        #endregion Parameters

    }
}
