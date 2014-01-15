/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 1/15/2014
 * Time: 1:41 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    /// <summary>
    /// Description of WindowSearchData.
    /// </summary>
    public class WindowSearchData : SearchTemplateData
    {
        public Process[] InputObject { get; set; }
        public string[] Name { get; set; }
        public string AutomationId { get; set; }
        public string Class { get; set; }
        public int[] ProcessIds { get; set; }
        public string[] ProcessNames { get; set; }
        public Hashtable[] WithControl { get; set; }
        public Hashtable[] SearchCriteria { get; set; } 
        public bool First { get; set; }
        public bool Recurse { get; set; }
        public bool TestMode { get; set; }
        public bool Win32 { get; set; }
        public bool WaitNoWindow { get; set; }
    }
}
