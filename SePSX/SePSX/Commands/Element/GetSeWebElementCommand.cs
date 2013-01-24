/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 10:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    
    using OpenQA.Selenium.Remote;
    
    /// <summary>
    /// Description of GetSeWebElementCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeWebElement", DefaultParameterSetName = "Name")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeWebElementCommand : GetCmdletBase
    {
        public GetSeWebElementCommand()
        {
        }
        
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriverOrWebElement();
            
            SeGetWebElementCommand command =
                new SeGetWebElementCommand(this);
            command.Execute();
        }
        
        protected override void StopProcessing()
        {
            SeHelper.waitForElement = false;
        }
    }
}
