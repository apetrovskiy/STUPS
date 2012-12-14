/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2012
 * Time: 2:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    /// <summary>
    /// Description of EditFirefoxProfileCmdletBase.
    /// </summary>
    public class EditFirefoxProfileCmdletBase : FirefoxProfileCmdletBase
    {
        public EditFirefoxProfileCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        public FirefoxProfile InputObject { get; set; }
        #endregion Parameters
    }
}
