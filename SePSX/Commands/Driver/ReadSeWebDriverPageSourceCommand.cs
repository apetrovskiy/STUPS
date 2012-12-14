/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebDriverPageSourceCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebDriverPageSource")]
    [OutputType(typeof(string))]
    public class ReadSeWebDriverPageSourceCommand : HasWebDriverInputCmdletBase
    {
        public ReadSeWebDriverPageSourceCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeReadWebDriverPageSourceCommand command =
                new SeReadWebDriverPageSourceCommand(this);
            command.Execute();
            //SeHelper.GetPageSource(this, this.InputObject);
        }
    }
}
