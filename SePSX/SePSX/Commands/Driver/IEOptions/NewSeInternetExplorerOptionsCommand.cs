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
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    
    /// <summary>
    /// Description of NewSeInternetExplorerOptionsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SeInternetExplorerOptions")]
    [OutputType(typeof(OpenQA.Selenium.IE.InternetExplorerOptions))]
    public class NewSeInternetExplorerOptionsCommand : IEOptionsCmdletBase
    {
        public NewSeInternetExplorerOptionsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            SeNewIEOptionsCommand command =
                new SeNewIEOptionsCommand(this);
            command.Execute();
        }
    }
}
