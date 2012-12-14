/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/31/2012
 * Time: 9:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchToFrameCmdletBase.
    /// </summary>
    public class SwitchToFrameCmdletBase : SwitchToCmdletBase
    {
        public SwitchToFrameCmdletBase()
        {
        }
        

        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = "FrameIndex")]
        [ValidateNotNullOrEmpty()]
        public int FrameIndex { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = "FrameName")]
        [ValidateNotNullOrEmpty()]
        public string FrameName { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = "FrameElement")]
        [ValidateNotNullOrEmpty()]
        public IWebElement FrameElement { get; set; }
        #endregion Parameters
    }
}
