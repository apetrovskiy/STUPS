/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeWebDriverCookiesCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeWebDriverCookies")]
    [OutputType(typeof(ICookieJar))]
    public class GetSeWebDriverCookiesCommand : HasWebDriverInputCmdletBase
    {
        public GetSeWebDriverCookiesCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeGetWebDriverCookiesCommand command =
                new SeGetWebDriverCookiesCommand(this);
            command.Execute();
            //SeHelper.GetCookies(this, this.InputObject);
        }
    }
}
