/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 11:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    //using OpenQA.Selenium.Interactions;
    
    /// <summary>
    /// Description of InvokeSeJSExecutorCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeJSExecutor")]
    [OutputType(typeof(bool))]
    public class InvokeSeJSExecutorCommandTestFixture // JSExecutorCmdletBase
    {
        public InvokeSeJSExecutorCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeHelper.ExecuteJavaScript(
                this,
                this.InputObject,
                this.ScriptCode,
                this.ArgumentList,
                true);
        }
    }
}
