/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/26/2012
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of NewSeChromeOptionsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SeChromeOptions")]
    [OutputType(typeof(OpenQA.Selenium.Chrome.ChromeOptions))]
    public class NewSeChromeOptionsCommand : ChromeOptionsCmdletBase
    {
        public NewSeChromeOptionsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            var command =
                new SeNewChromeOptionsCommand(this);
            command.Execute();
        }
    }
}
