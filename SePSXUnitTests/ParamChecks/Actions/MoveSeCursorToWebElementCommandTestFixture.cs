using OpenQA.Selenium.Remote;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 3:15 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    
    /// <summary>
    /// Description of MoveSeCursorToWebElementCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "SeCursorToWebElement")]
    [OutputType(typeof(IWebElement))]
    public class MoveSeCursorToWebElementCommandTestFixture // ActionsCmdletBase
    {
        public MoveSeCursorToWebElementCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public int X { get; set; }
        
        [Parameter(Mandatory = false)]
        public int Y { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.MoveCursorToElement(this, this.InputObject, this.X, this.Y);
        }
    }
}
