/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 11:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of WebElementCmdletBase.
    /// </summary>
    public class WebElementCmdletBase : HasWebElementInputCmdletBase //CommonCmdletBase //HasWebElementInputCmdletBase 
    {
        public WebElementCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        public new IWebElement[] InputObject { get; set; }
        #endregion Parameters
    }
}
