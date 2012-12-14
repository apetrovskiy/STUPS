/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSePageRefreshCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SePageRefresh")]
    [OutputType(typeof(IWebDriver))]
    public class InvokeSePageRefreshCommand : NavigationCmdletBase
    {
        public InvokeSePageRefreshCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            //SeHelper.RefreshPage(this, ((IWebDriver[])this.InputObject));
            SeHelper.RefreshPage(this, this.InputObject);
        }
    }
}
