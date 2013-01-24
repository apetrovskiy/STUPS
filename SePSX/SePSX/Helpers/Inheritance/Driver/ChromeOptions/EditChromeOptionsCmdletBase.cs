/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    /// <summary>
    /// Description of EditChromeOptionsCmdletBase.
    /// </summary>
    public class EditChromeOptionsCmdletBase : ChromeOptionsCmdletBase
    {
        public EditChromeOptionsCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        public ChromeOptions InputObject { get; set; }
        #endregion Parameters
    }
}
