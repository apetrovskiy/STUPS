/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebDriverTitleCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebDriverTitle")]
    [OutputType(typeof(string))]
    public class ReadSeWebDriverTitleCommandTestFixture // HasWebDriverInputCmdletBase
    {
        public ReadSeWebDriverTitleCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeReadWebDriverTitleCommand command =
                new SeReadWebDriverTitleCommand(this);
            command.Execute();
            //SeHelper.GetTitle(this, this.InputObject);
        }
    }
}
