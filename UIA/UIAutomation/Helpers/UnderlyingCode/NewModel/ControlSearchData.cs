/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/15/2014
 * Time: 1:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using PSTestLib;
    
    /// <summary>
    /// Description of ControlSearchData.
    /// </summary>
    public class ControlSearchData : SearchTemplateData
    {
        public IUiElement[] InputObject { get; set; }
        public string ContainsText { get; set; }
        public string Name { get; set; }
//        public string AutomationId { get; set; }
//        public string Class { get; set; }
        public string Value { get; set; }
        public string[] ControlType { get; set; }
        // public int[] ProcessIds { get; set; }
        // public string[] ProcessNames { get; set; }
        // public Hashtable[] WithControl { get; set; }
        public Hashtable[] SearchCriteria { get; set; } 
        // public bool First { get; set; }
        public bool Regex { get; set; }
        // public bool TestMode { get; set; }
        public bool CaseSensitive { get; set; }
        public bool Win32 { get; set; }
        // public bool WaitNoWindow { get; set; }
        
        // public int Timeout { get; set; } // ??
        // public bool Wait { get; set; } // ??
        /*
        GetControlCmdletBase cmdlet
        cmdlet.ControlType
        cmdlet.ContainsText
        cmdlet.Regex
        cmdlet.CaseSensitive
        cmdlet.InputObject
        cmdlet.Win32
        cmdlet.Name,
        cmdlet.AutomationId,
        cmdlet.Class,
        cmdlet.Value,
        cmdlet.Timeout
        cmdlet.Wait
        */
    }
}
