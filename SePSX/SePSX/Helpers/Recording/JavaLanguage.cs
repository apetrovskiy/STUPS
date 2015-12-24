/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/10/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using PSTestLib;

    /// <summary>
    /// Description of JavaLanguage.
    /// </summary>
    public class JavaLanguage : ILanguagePackage
    {
        public JavaLanguage()
        {
        }
        
        public string Name { get { return "Java"; } }
        public string RegionOpen { get { return "\r\n#region element's properties"; } }
        public string RegionClose { get { return "\r\n#endregion element's properties"; } }
        public string HereStringOpen { get { return "\r\n// Text = \r\n\"\r\n"; } }
        public string HereStringClose { get { return "\r\n\""; } }
        public string SingleLineComment { get { return "\r\n// "; } }
        public string ElementCode { get { return "\r\ndriver.findElementBy(By.XPath, "; } }
        public string ElementIdentity { get; set; }
        public string ActionCode { get { return ".click();"; } }
        public string Separator { get { return "; "; } }
    }
}
