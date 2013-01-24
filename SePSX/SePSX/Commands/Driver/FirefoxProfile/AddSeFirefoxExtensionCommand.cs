/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2012
 * Time: 2:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    /// <summary>
    /// Description of AddSeFirefoxExtensionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "SeFirefoxExtension")]
    [OutputType(typeof(OpenQA.Selenium.Firefox.FirefoxProfile))]
    public class AddSeFirefoxExtensionCommand : EditFirefoxProfileCmdletBase
    {
        public AddSeFirefoxExtensionCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public string[] ExtensionList { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            // check input options
            this.checkInputFirefoxProfile(true);
            
            // add an extension
            SeAddFirefoxExtensionCommand command =
                new SeAddFirefoxExtensionCommand(this);
            command.Execute();
        }
    }
}
