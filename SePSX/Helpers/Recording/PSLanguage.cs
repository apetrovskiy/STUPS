/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 2:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using PSTestLib;
    
    /// <summary>
    /// Description of PSLanguage.
    /// </summary>
    public class PSLanguage : ILanguagePackage
    {
        public PSLanguage()
        {
        }
        
        public string Name { get { return "PowerShell"; } }
        public string RegionOpen { get { return "\r\n#region element's properties"; } }
        public string RegionClose { get { return "\r\n#endregion element's properties"; } }
        public string HereStringOpen { get { return "\r\n# Text = \r\n@\"\r\n"; } }
        public string HereStringClose { get { return "\r\n\"@"; } }
        public string SingleLineComment { get { return "\r\n# "; } }
        public string ElementCode { get { return "\r\nGet-SeWebElementClick -XPath "; } }
        public string ElementIdentity { get; set; }
        public string ActionCode { get { return " | Invoke-SeWebElementClick;"; } }
        public string Separator { get { return "; "; } }
    }
}
