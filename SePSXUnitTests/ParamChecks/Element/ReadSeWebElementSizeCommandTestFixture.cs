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
    /// Description of ReadSeWebElementSizeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementSize")]
    [OutputType(typeof(object))]
    public class ReadSeWebElementSizeCommandTestFixture // WebElementCmdletBase
    {
        public ReadSeWebElementSizeCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementSizeCommand command =
                new SeReadWebElementSizeCommand(this);
            command.Execute();
            //SeHelper.GetWebElementSize(this, ((IWebElement[])this.InputObject));
         }
    }
}
