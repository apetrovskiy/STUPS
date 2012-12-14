/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/28/2012
 * Time: 9:02 PM
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
    /// Description of AddSeChromeArgumentCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "SeChromeArgument")]
    [OutputType(typeof(OpenQA.Selenium.Chrome.ChromeOptions))]
    public class AddSeChromeArgumentCommandTestFixture // EditChromeOptionsCmdletBase
    {
        public AddSeChromeArgumentCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public string[] ArgumentList { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            // check input options
            this.checkInputChromeOptions(true);
            
            // add an option
            SeAddChromeArgumentCommand command =
                new SeAddChromeArgumentCommand(this);
            command.Execute();
            
            ChromeOptions c = new ChromeOptions();
        }
    }
}
