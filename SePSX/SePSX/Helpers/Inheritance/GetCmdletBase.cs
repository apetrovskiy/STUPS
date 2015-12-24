/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 10:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System.Management.Automation;

    /// <summary>
    /// Description of GetCmdletBase.
    /// </summary>
    public class GetCmdletBase : HasWebElementInputCmdletBase
    {
        public GetCmdletBase()
        {
//            if (this.InputObject == null) {
//                //this.InputObject[0] = CurrentData.CurrentWebDriver;
//                this.InputObject = new object[1];
//                this.InputObject[0] = CurrentData.CurrentWebDriver;
//            }
            
            
//            this.Wait = true;
            Timeout = Preferences.Timeout;
            Seconds = Timeout / 1000;
//            this.OnErrorScreenShot = Preferences.OnErrorScreenShot;
//            this.OnSuccessAction = null;
//            this.OnErrorAction = null;


            First = false;
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "Id")]
        public string Id { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Class")]
        public string ClassName { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Tag")]
        public string TagName { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Name")]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Link")]
        public string LinkText { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "PartialLink")]
        public string PartialLinkText { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "CSS")]
        [Alias("CSS")]
        public string CssSelector { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "XPath")]
        public string XPath { get; set; }

        [Parameter(Mandatory = false,
                   ParameterSetName = "JavaScript")]
        public string JavaScript { get; set; }
        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "All")]
//        public bool All { get; set; }

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
