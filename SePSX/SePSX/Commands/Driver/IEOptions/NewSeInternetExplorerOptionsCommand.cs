/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of NewSeInternetExplorerOptionsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SeInternetExplorerOptions")]
    [OutputType(typeof(OpenQA.Selenium.IE.InternetExplorerOptions))]
    public class NewSeInternetExplorerOptionsCommand : IeOptionsCmdletBase
    {
        public NewSeInternetExplorerOptionsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            var command =
                new SeNewIeOptionsCommand(this);
            command.Execute();
        }
    }
}
