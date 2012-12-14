/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementAttributeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementAttribute")]
    [OutputType(typeof(string))]
    public class ReadSeWebElementAttributeCommand : WebElementCmdletBase
    {
        public ReadSeWebElementAttributeCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string AttributeName { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementAttributeCommand command =
                new SeReadWebElementAttributeCommand(this);
            command.Execute();
//            SeHelper.GetWebElementAttribute(
//                this,
//                ((IWebElement[])this.InputObject),
//                 this.AttributeName);
        }
    }
}
