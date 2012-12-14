/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-03
 * Time: 05:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    //using OpenQA.Selenium.Support.UI;
    
    /// <summary>
    /// Description of SetSeSelectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "SeSelection")]
    [OutputType(typeof(bool))]
    public class SetSeSelectionCommandTestFixture // SetSelectionCmdletBase
    {
        public SetSeSelectionCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.SetSelect(
                this,
                this.InputObject,
                this.Index,
                this.Value,
                this.VisibleText,
                this.All,
                this.Deselect);
        }
    }
}
