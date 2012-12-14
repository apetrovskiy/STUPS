/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ReadSeWebElementEnabledCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementEnabled")]
    [OutputType(typeof(bool))]
    public class ReadSeWebElementEnabledCommandTestFixture // WebElementCmdletBase
    {
        public ReadSeWebElementEnabledCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementEnabledCommand command =
                new SeReadWebElementEnabledCommand(this);
            command.Execute();
            //SeHelper.GetWebElementIsEnabled(this, ((IWebElement[])this.InputObject));
        }
    }
}
