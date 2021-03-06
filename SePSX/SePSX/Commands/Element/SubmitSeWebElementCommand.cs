﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SubmitSeWebElementCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Submit, "SeWebElement")]
    [OutputType(typeof(IWebElement))]
    public class SubmitSeWebElementCommand : WebElementCmdletBase
    {
        public SubmitSeWebElementCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
//Console.WriteLine("input checked!!!!!!!!!!!!!!!!!!!");
            var command =
                new SeSubmitWebElementCommand(this);
            command.Execute();
            //SeHelper.SubmitWebElement(this, ((IWebElement[])this.InputObject));
        }
    }
}
