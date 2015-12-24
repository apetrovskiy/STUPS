/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/28/2012
 * Time: 9:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of AddSeChromeArgumentCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "SeChromeArgument")]
    [OutputType(typeof(OpenQA.Selenium.Chrome.ChromeOptions))]
    public class AddSeChromeArgumentCommand : EditChromeOptionsCmdletBase
    {
        public AddSeChromeArgumentCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public string[] ArgumentList { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            // check input options
            CheckInputChromeOptions(true);
            
            // add an option
            var command =
                new SeAddChromeArgumentCommand(this);
            command.Execute();
        }
    }
}
