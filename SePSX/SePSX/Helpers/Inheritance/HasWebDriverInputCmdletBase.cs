/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 11:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of HasWebDriverInputCmdletBase.
    /// </summary>
    public class HasWebDriverInputCmdletBase : CommonCmdletBase
    {
        public HasWebDriverInputCmdletBase()
        {
            WriteVerbose(this, "trying to set: this.InputObject[0] = CurrentData.CurrentWebDriver;");
            if (null == InputObject) {
                InputObject = new IWebDriver[1];
                InputObject[0] = CurrentData.CurrentWebDriver;
            }
            WriteVerbose(this, "succeed to set: this.InputObject[0] = CurrentData.CurrentWebDriver;");
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public IWebDriver[] InputObject { get; set; }
        #endregion Parameters
        
        // 20121011
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            SeHelper.SetBrowserInstanceForeground(this);
        }
    }
}
