/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:23 PM
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
    /// Description of AddSeChromeExtensionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "SeChromeExtension")]
    [OutputType(typeof(OpenQA.Selenium.Chrome.ChromeOptions))]
    public class AddSeChromeExtensionCommandTestFixture // EditChromeOptionsCmdletBase
    {
        public AddSeChromeExtensionCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public string[] ExtensionList { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            // check input options
            this.checkInputChromeOptions(true);
            
            // add an option
            SeAddChromeExtensionCommand command =
                new SeAddChromeExtensionCommand(this);
            command.Execute();
        }
    }
}
