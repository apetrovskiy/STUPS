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
    using System.Management.Automation;

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
            CheckInputFirefoxProfile(true);
            
            // add an extension
            var command =
                new SeAddFirefoxExtensionCommand(this);
            command.Execute();
        }
    }
}
