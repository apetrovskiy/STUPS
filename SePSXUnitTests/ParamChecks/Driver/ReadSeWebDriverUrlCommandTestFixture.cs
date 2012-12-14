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
    /// Description of ReadSeWebDriverUrlCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebDriverUrl")]
    [OutputType(typeof(string))]
    public class ReadSeWebDriverUrlCommandTestFixture // HasWebDriverInputCmdletBase
    {
        public ReadSeWebDriverUrlCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeReadWebDriverUrlCommand command =
                new SeReadWebDriverUrlCommand(this);
            command.Execute();
            //SeHelper.GetUrl(this, this.InputObject);
        }
    }
}
