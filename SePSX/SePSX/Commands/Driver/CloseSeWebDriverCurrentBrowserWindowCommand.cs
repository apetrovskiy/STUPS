/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
//    using OpenQA.Selenium.Firefox;
//    using OpenQA.Selenium.Chrome;
//    using OpenQA.Selenium.IE;
//    using OpenQA.Selenium.Safari;
//    using OpenQA.Selenium.Android;
//    using OpenQA.Selenium.Remote;
    
    /// <summary>
    /// Description of CloseSeWebDriverCurrentBrowserWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Close, "SeWebDriverCurrentBrowserWindow")]
    [OutputType(typeof(IWebDriver))]
    public class CloseSeWebDriverCurrentBrowserWindowCommand : HasWebDriverInputCmdletBase
    {
        public CloseSeWebDriverCurrentBrowserWindowCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            //SeHelper.CloseCurrentBrowserWindow(this, this.InputObject);
            var command =
                new SeCloseWebDriverCurrentBrowserWindowCommand(this);
            command.Execute();
        }
    }
}
