/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/15/2014
 * Time: 1:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Collections;
    
    /// <summary>
    /// Description of SearcherTemplateData.
    /// </summary>
    public abstract class SearcherTemplateData
    {
        public string AutomationId { get; set; }
        public string Class { get; set; }
        public bool Win32 { get; set; }
        public Hashtable[] SearchCriteria { get; set; }
    }
}
