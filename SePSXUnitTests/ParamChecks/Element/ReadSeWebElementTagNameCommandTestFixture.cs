/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementTagNameCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementTagName")]
    [OutputType(typeof(string))]
    public class ReadSeWebElementTagNameCommandTestFixture // WebElementCmdletBase
    {
        public ReadSeWebElementTagNameCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementTagNameCommand command =
                new SeReadWebElementTagNameCommand(this);
            command.Execute();
            //SeHelper.GetWebElementTagName(this, ((IWebElement[])this.InputObject));
        }
    }
}
