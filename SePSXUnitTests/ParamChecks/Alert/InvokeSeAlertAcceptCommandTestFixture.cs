/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeAlertAcceptCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeAlertAccept")]
    [OutputType(typeof(bool))]
    public class InvokeSeAlertAcceptCommandTestFixture // AlertCmdletBase
    {
        public InvokeSeAlertAcceptCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputAlert(true);
            
            SeHelper.AlertAcceptButtonClick(this, this.InputObject);
        }
    }
}
