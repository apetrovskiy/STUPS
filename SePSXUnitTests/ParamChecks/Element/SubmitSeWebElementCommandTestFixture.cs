/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SubmitSeWebElementCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Submit, "SeWebElement")]
    [OutputType(typeof(IWebElement))]
    public class SubmitSeWebElementCommandTestFixture // WebElementCmdletBase
    {
        public SubmitSeWebElementCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
//Console.WriteLine("input checked!!!!!!!!!!!!!!!!!!!");
            SeSubmitWebElementCommand command =
                new SeSubmitWebElementCommand(this);
            command.Execute();
            //SeHelper.SubmitWebElement(this, ((IWebElement[])this.InputObject));
        }
    }
}
