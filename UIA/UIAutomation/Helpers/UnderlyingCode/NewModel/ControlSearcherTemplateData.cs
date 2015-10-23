/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/18/2014
 * Time: 1:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of ControlSearcherTemplateData.
    /// </summary>
    public class ControlSearcherTemplateData : SearcherTemplateData
    {
        //
        public IUiElement[] InputObject { get; set; }
        //
        public string ContainsText { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string[] ControlType { get; set; }
        public bool Regex { get; set; }
        public bool CaseSensitive { get; set; }
    }
}
