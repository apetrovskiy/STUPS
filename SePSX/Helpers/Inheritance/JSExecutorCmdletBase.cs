/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 11:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of JSExecutorCmdletBase.
    /// </summary>
    public class JSExecutorCmdletBase : HasWebDriverInputCmdletBase
    {
        public JSExecutorCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string ScriptCode { get; set; }
        
        [Parameter(Mandatory = false)]
        public string[] ArgumentList { get; set; }
        #endregion Parameters
    }
}
