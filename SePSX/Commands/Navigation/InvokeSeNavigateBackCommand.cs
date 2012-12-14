/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeNavigateBackCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeNavigateBack")]
    [OutputType(typeof(IWebDriver))]
    public class InvokeSeNavigateBackCommand : NavigationCmdletBase
    {
        public InvokeSeNavigateBackCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            //SeHelper.NavigateBack(this, ((IWebDriver[])this.InputObject));
            SeInvokeNavigateBackCommand command =
                new SeInvokeNavigateBackCommand(this);
            command.Execute();
            //SeHelper.NavigateBack(this, this.InputObject);
        }
    }
}
