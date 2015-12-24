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
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeNavigateForwardCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeNavigateForward")]
    [OutputType(typeof(IWebDriver))]
    public class InvokeSeNavigateForwardCommand : NavigationCmdletBase
    {
        public InvokeSeNavigateForwardCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            //SeHelper.NavigateForward(this, ((IWebDriver[])this.InputObject));
            var command =
                new SeInvokeNavigateForwardCommand(this);
            command.Execute();
            //SeHelper.NavigateForward(this, this.InputObject);
        }
    }
}
