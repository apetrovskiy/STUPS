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
    /// Description of ReadSeWebElementSelectedCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementSelected")]
    [OutputType(typeof(bool))]
    public class ReadSeWebElementSelectedCommand : WebElementCmdletBase
    {
        public ReadSeWebElementSelectedCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementSelectedCommand command =
                new SeReadWebElementSelectedCommand(this);
            command.Execute();
            //SeHelper.GetWebElementIsSelected(this, ((IWebElement[])this.InputObject));
         }
    }
}
