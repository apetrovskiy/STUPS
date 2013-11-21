/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 5:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of HasWebElementInputCmdletBase.
    /// </summary>
    public class HasWebElementInputCmdletBase : CommonCmdletBase
    {
        public HasWebElementInputCmdletBase()
        {
            //this.InputObject = CurrentData.CurrentWebDriver;
            if (this.InputObject == null) {
                this.InputObject = new object[1];
                this.InputObject[0] = CurrentData.CurrentWebDriver;
            }
        }
        
        #region Parameters
//        [Parameter(Mandatory = true,
//                   ValueFromPipeline = true)]
//        public object InputObject { get; set; }
        
//        [Parameter(Mandatory = false, 
//            ValueFromPipeline = true, 
//            Position = 0,
//            HelpMessage = "This is usually the output from Get-UiaControl" )] 
//        public virtual System.Windows.Automation.AutomationElement InputObject { get; set; }
        
        [Parameter(Mandatory = false, 
            ValueFromPipeline = true, 
            //Position = 0,
            HelpMessage = "This is usually the output from Start-Se[Driver] or Get-SeWebElement" )] 
            public virtual object[] InputObject { get; set; } // virtual ??
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            SeHelper.SetBrowserInstanceForeground(this);
        }
    }
}
