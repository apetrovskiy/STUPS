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
    /// Description of ReadSeWebElementLocationCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementLocation")]
    [OutputType(typeof(object))]
    public class ReadSeWebElementLocationCommandTestFixture // WebElementCmdletBase
    {
        public ReadSeWebElementLocationCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementLocationCommand command =
                new SeReadWebElementLocationCommand(this);
            command.Execute();
            //SeHelper.GetWebElementLocation(this, ((IWebElement[])this.InputObject));
        }
    }
}
