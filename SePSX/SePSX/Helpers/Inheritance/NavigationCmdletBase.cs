/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 11:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Description of NavigationCmdletBase.
    /// </summary>
    public class NavigationCmdletBase : HasWebDriverInputCmdletBase
    {
        public NavigationCmdletBase()
        {
//            // 20120903
//            if (this.InputObject == null) {
//                this.InputObject = new object[1];
//                this.InputObject[0] = CurrentData.CurrentWebDriver;
//            }
        }
        
//        protected override void BeginProcessing()
//        {
//            SeHelper.SetBrowserInstanceForeground();
//        }
        
//        #region Parameters
//        [Parameter(Mandatory = true,
//                   Position = 0)]
//        [ValidateNotNullOrEmpty()]
//        //[ValidatePattern(@"h[t]{2}p[Ss]{0,1}[\:][\/]{2}.*|about[\:].*|ms-its[\:].*|file[\:][\/]{3}.*")]
//        public string URL { get; set; }
//        #endregion Parameters
    }
}
