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
    /// Description of GetSeWebDriverWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeWebDriverWindow")]
    [OutputType(typeof(IWindow))]
    public class GetSeWebDriverWindowCommand : HasWebDriverInputCmdletBase
    {
        public GetSeWebDriverWindowCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeGetWebDriverWindowCommand command =
                new SeGetWebDriverWindowCommand(this);
            command.Execute();
            //SeHelper.GetWindow(this, this.InputObject);
        }
    }
}
