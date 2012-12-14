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
    /// Description of ReadSeWebElementCssValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementCssValue")]
    [OutputType(typeof(string))]
    public class ReadSeWebElementCssValueCommandTestFixture // WebElementCmdletBase
    {
        public ReadSeWebElementCssValueCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string PropertyName { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeReadWebElementCssValueCommand command =
                new SeReadWebElementCssValueCommand(this);
            command.Execute();
//            SeHelper.GetWebElementCSSValue(
//                this,
//                ((IWebElement[])this.InputObject),
//                this.PropertyName);
        }
    }
}
