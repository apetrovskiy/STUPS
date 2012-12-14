/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeNavigateForwardCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeNavigateForward")]
    [OutputType(typeof(IWebDriver))]
    public class InvokeSeNavigateForwardCommandTestFixture // NavigationCmdletBase
    {
        public InvokeSeNavigateForwardCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            //SeHelper.NavigateForward(this, ((IWebDriver[])this.InputObject));
            SeInvokeNavigateForwardCommand command =
                new SeInvokeNavigateForwardCommand(this);
            command.Execute();
            //SeHelper.NavigateForward(this, this.InputObject);
        }
    }
}
