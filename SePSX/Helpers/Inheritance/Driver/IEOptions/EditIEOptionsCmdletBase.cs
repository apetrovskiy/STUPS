/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    
    /// <summary>
    /// Description of EditIEOptionsCmdletBase.
    /// </summary>
    public class EditIEOptionsCmdletBase : IEOptionsCmdletBase
    {
        public EditIEOptionsCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        public InternetExplorerOptions InputObject { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter EnableNativeEvents { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter IgnoreZoomLevel { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter IntroduceInstabilityByIgnoringProtectedModeSettings { get; set; }
        
        [Parameter(Mandatory = false)]
        public string InitialBrowserUrl { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public InternetExplorerElementScrollBehavior ElementScrollBehavior { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public InternetExplorerUnexpectedAlertBehavior UnexpectedAlertBehavior { get; set; }
        #endregion Parameters
    }
}
