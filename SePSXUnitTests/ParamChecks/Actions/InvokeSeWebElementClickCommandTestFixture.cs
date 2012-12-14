/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 3:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework; //using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeWebElementClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeWebElementClick", DefaultParameterSetName = "Method")]
    [OutputType(typeof(IWebElement))]
    public class InvokeSeWebElementClickCommandTestFixture // ActionsCmdletBase
    {
        public InvokeSeWebElementClickCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "Single")]
        public SwitchParameter Single { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Right")]
        public SwitchParameter Right { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Double")]
        public SwitchParameter DoubleClick { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Hold")]
        public SwitchParameter Hold { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Here")]
        public SwitchParameter Here { get; set; }
        
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "Method")]
        public SwitchParameter WebElementMethod { get; set; }
        #endregion Parameters
        
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.ClickOnElement(
                this, 
                this.InputObject,
                this.WebElementMethod,
                this.Single,
                this.DoubleClick,
                this.Right,
                this.Hold,
                this.Here);
        }
    }
}
