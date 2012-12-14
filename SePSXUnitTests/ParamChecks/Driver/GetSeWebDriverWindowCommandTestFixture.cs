/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeWebDriverWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeWebDriverWindow")]
    [OutputType(typeof(IWindow))]
    public class GetSeWebDriverWindowCommandTestFixture // HasWebDriverInputCmdletBase
    {
        public GetSeWebDriverWindowCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeGetWebDriverWindowCommand command =
                new SeGetWebDriverWindowCommand(this);
            command.Execute();
            //SeHelper.GetWindow(this, this.InputObject);
        }
    }
}
