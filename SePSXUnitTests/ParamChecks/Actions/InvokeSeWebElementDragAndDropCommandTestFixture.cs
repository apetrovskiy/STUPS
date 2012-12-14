/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 3:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeWebElementDragAndDropCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeWebElementDragAndDrop")] //, DefaultParameterSetName = "Method")]
    [OutputType(typeof(IWebElement))]
    public class InvokeSeWebElementDragAndDropCommandTestFixture // ActionsCmdletBase
    {
        public InvokeSeWebElementDragAndDropCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public IWebElement TargetElement { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.DragAndDropOnElement(
                this, 
                ((IWebElement[])this.InputObject),
                ((IWebElement)this.TargetElement));
        }
    }
}
