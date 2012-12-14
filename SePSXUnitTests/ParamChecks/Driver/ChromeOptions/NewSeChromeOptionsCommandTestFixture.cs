/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/26/2012
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    /// <summary>
    /// Description of NewSeChromeOptionsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SeChromeOptions")]
    [OutputType(typeof(OpenQA.Selenium.Chrome.ChromeOptions))]
    public class NewSeChromeOptionsCommandTestFixture // ChromeOptionsCmdletBase
    {
        public NewSeChromeOptionsCommandTestFixture()
        {
        }
        
        protected override void BeginProcessing()
        {
            SeNewChromeOptionsCommand command =
                new SeNewChromeOptionsCommand(this);
            command.Execute();
        }
    }
}
