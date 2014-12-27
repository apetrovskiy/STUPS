/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 11:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToFrameCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "SeToFrame")]
    [OutputType(typeof(IWebDriver))]
    public class SwitchSeToFrameCommand : SwitchToFrameCmdletBase //SwitchToCmdletBase //NavigationCmdletBase
    {
        public SwitchSeToFrameCommand()
        {
        }
        
//        #region Parameters
//        [Parameter(Mandatory = true,
//                   Position = 0,
//                   ParameterSetName = "FrameIndex")]
//        [ValidateNotNullOrEmpty()]
//        public int FrameIndex { get; set; }
//        
//        [Parameter(Mandatory = true,
//                   Position = 0,
//                   ParameterSetName = "FrameName")]
//        [ValidateNotNullOrEmpty()]
//        public string FrameName { get; set; }
//        
//        [Parameter(Mandatory = true,
//                   Position = 0,
//                   ParameterSetName = "FrameElement")]
//        [ValidateNotNullOrEmpty()]
//        public IWebElement FrameElement { get; set; }
//        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            checkInputWebDriver(true);
            
            //SeHelper.SwitchToFrame(this, ((IWebDriver[])this.InputObject), this.FrameIndex);
            // if (null != this.FrameElement && null == this.FrameIndex && null == this.FrameName) {
            if (null != FrameElement && null == FrameName) {
                SeHelper.SwitchToFrame(this, InputObject, SwitchToFrameWays.FrameElement);
            }
            // if (null != this.FrameIndex && null == this.FrameElement && null == this.FrameName) {
            if (null == FrameElement && null == FrameName) {
                SeHelper.SwitchToFrame(this, InputObject, SwitchToFrameWays.FrameIndex);
            }
            // if (null != this.FrameName && null == this.FrameElement && null == this.FrameIndex) {
            if (null != FrameName && null == FrameElement) {
                SeHelper.SwitchToFrame(this, InputObject, SwitchToFrameWays.FrameName);
            }
        }
    }
}
