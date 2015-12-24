/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 11:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    //using OpenQA.Selenium.Interactions;
    
    /// <summary>
    /// Description of InvokeSeJSExecutorCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeJSExecutor")]
    [OutputType(typeof(bool))]
    public class InvokeSeJsExecutorCommand : JsExecutorCmdletBase
    {
        public InvokeSeJsExecutorCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            SeHelper.ExecuteJavaScript(
                this,
                InputObject,
                ScriptCode,
                ArgumentList,
                true);
        }
    }
}
