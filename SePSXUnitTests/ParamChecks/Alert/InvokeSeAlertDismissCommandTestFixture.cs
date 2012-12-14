/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeAlertDismissCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeAlertDismiss")]
    [OutputType(typeof(bool))]
    public class InvokeSeAlertDismissCommandTestFixture // AlertCmdletBase
    {
        public InvokeSeAlertDismissCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputAlert(true);
            
            SeHelper.AlertDismissButtonClick(this, this.InputObject);
        }
    }
}
