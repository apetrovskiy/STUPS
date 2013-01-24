/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SetSeWebDriverTimeoutCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "SeWebDriverTimeout")]
    [OutputType(typeof(IWebDriver))]
    public class SetSeWebDriverTimeoutCommand : HasWebDriverInputCmdletBase
    {
        public SetSeWebDriverTimeoutCommand()
        {
            this.ImplicitlyWaitTimeout = 0;
            this.PageLoadTimeout = 0;
            this.ScriptTimeout = 0;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        [Alias("ImplicitlyWaitMilliseconds")]
        public double ImplicitlyWaitTimeout { get; set; }
        
        [Parameter(Mandatory = false)]
        [Alias("PageLoadMilliseconds")]
        public double PageLoadTimeout { get; set; }
        
        [Parameter(Mandatory = false)]
        [Alias("ScriptMilliseconds")]
        public double ScriptTimeout { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeSetWebDriverTimeoutCommand command =
                new SeSetWebDriverTimeoutCommand(this);
            command.Execute();
//            if (0 != this.ImplicitlyWaitTimeout) {
//                SeHelper.SetDriverTimeout(this, this.InputObject, DriverTimeoutTypes.ImplicitlyWait, this.ImplicitlyWaitTimeout);
//            }
//            
//            if (0 != this.PageLoadTimeout) {
//                SeHelper.SetDriverTimeout(this, this.InputObject, DriverTimeoutTypes.PageLoad, this.PageLoadTimeout);
//            }
//            
//            if (0 != this.ScriptTimeout) {
//                SeHelper.SetDriverTimeout(this, this.InputObject, DriverTimeoutTypes.Script, this.ScriptTimeout);
//            }
        }
    }
}
