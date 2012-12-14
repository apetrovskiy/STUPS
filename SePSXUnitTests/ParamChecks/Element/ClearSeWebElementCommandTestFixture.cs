/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ClearSeWebElementCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Clear, "SeWebElement")]
    [OutputType(typeof(IWebElement))]
    public class ClearSeWebElementCommandTestFixture // WebElementCmdletBase
    {
        public ClearSeWebElementCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeClearWebElementCommand command =
                new SeClearWebElementCommand(this);
            command.Execute();
            //SeHelper.ClearWebElement(this, ((IWebElement[])this.InputObject));
        }
    }
}
