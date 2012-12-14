/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 2:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using PSTestLib;
    
    /// <summary>
    /// Description of CSLanguage.
    /// </summary>
    public class CSLanguage : ILanguagePackage
    {
        public CSLanguage()
        {
        }
        
        public string Name { get { return "CSharp"; } }
        public string RegionOpen { get { return "\r\n#region element's properties"; } }
        public string RegionClose { get { return "\r\n#endregion element's properties"; } }
        public string HereStringOpen { get { return "\r\n// Text = \r\n\"\r\n"; } }
        public string HereStringClose { get { return "\r\n\""; } }
        public string SingleLineComment { get { return "\r\n// "; } }
        public string ElementCode { get { return "\r\ndriver.FindElementBy(By.XPath, "; } }
        public string ElementIdentity { get; set; }
        public string ActionCode { get { return ".Click();"; } }
        public string Separator { get { return "; "; } }
    }
}
