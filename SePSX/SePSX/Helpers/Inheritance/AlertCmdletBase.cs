/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of AlertCmdletBase.
    /// </summary>
    public class AlertCmdletBase : CommonCmdletBase
    {
        public AlertCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipeline = true)]
        public IAlert InputObject { get; set; }
        #endregion Parameters
    }
}
