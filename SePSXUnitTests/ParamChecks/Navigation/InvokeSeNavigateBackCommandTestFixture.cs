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
    /// Description of InvokeSeNavigateBackCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeNavigateBack")]
    [OutputType(typeof(IWebDriver))]
    public class InvokeSeNavigateBackCommandTestFixture // NavigationCmdletBase
    {
        public InvokeSeNavigateBackCommandTestFixture()
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
