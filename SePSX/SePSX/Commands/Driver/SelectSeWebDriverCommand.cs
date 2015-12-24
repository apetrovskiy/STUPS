/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/29/2012
 * Time: 3:22 AM
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
    /// Description of SelectSeWebDriverCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Select, "SeWebDriver")]
    [OutputType(typeof(IWebDriver))]
    public class SelectSeWebDriverCommand : DriverCmdletBase
    {
        public SelectSeWebDriverCommand()
        {
        }
        
        protected override void ProcessRecord() // ??
        {
            if (null == InstanceName || 0 == InstanceName.Length) {
                WriteError(
                    this,
                    "You need to specify input parameter: InstanceName",
                    "NoInstanceNameSpecified",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            var command =
                new SeSelectWebDriverCommand(this);
            command.Execute();
            //SeHelper.GetWebDriver(this, this.InstanceName);
        }
    }
}
