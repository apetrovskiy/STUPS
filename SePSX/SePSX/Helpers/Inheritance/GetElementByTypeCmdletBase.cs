/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/10/2012
 * Time: 11:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System.Management.Automation;
    using System.Collections;
    
    /// <summary>
    /// Description of GetElementByTypeCmdletBase.
    /// </summary>
    public class GetElementByTypeCmdletBase : HasWebElementInputCmdletBase
    {
        public GetElementByTypeCmdletBase()
        {
            Timeout = Preferences.Timeout;
            Seconds = Timeout / 1000;
            First = false;
        }
        
        internal protected string TagName { get; set; }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public string Id { get; set; }
        
        [Parameter(Mandatory = false)]
        public string ClassName { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        public string PartialText { get; set; }
        
        [Parameter(Mandatory = false)]
        public Hashtable[] SearchCriteria { get; set; }
        
//        [Parameter(Mandatory = false)]
//        [Alias("CSS")]
//        public string CssSelector { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public string XPath { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter First { get; set; }


        [Alias("Milliseconds")]
        [Parameter(Mandatory = false)]
        public int Timeout { get; set; }
        [Parameter(Mandatory = false)]
        public int Seconds {
            get { return Timeout / 1000; }
            set{ Timeout = value * 1000; }
        }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] OnSleepAction { get; set; }
        #endregion Parameters
    }
}
