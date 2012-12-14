/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementText")]
    [OutputType(typeof(string))]
    public class ReadSeWebElementTextCommand : WebElementCmdletBase
    {
        public ReadSeWebElementTextCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementTextCommand command =
                new SeReadWebElementTextCommand(this);
            command.Execute();
            //SeHelper.GetWebElementText(this, ((IWebElement[])this.InputObject));
        }
    }
}
