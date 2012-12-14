/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-02
 * Time: 00:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeSelectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSelection")]
    [OutputType(typeof(IWebElement))]
    public class GetSeSelectionCommandTestFixture // GetSelectionCmdletBase
    {
        public GetSeSelectionCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.GetSelect(
                this,
                this.InputObject,
                this.FirstSelected,
                this.Selected,
                this.All);
        }
    }
}
