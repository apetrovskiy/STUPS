/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:01 PM
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
    /// Description of SetSeInternetExplorerOptionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "SeInternetExplorerOption")]
    [OutputType(typeof(OpenQA.Selenium.IE.InternetExplorerOptions))]
    public class SetSeInternetExplorerOptionCommand : EditIEOptionsCmdletBase
    {
        public SetSeInternetExplorerOptionCommand()
        {
        }
        
        //protected override void BeginProcessing()
        protected override void ProcessRecord()
        {
            //this.CheckParameters();
            
            SeSetIEOptionCommand command =
                new SeSetIEOptionCommand(this);
            command.Execute();
        }
    }
}
