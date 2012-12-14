/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10.08.2012
 * Time: 6:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeWebElementAncestorsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeWebElementAncestors")]
    public class GetSeWebElementAncestorsCommandTestFixture // WebElementCmdletBase
    {
        public GetSeWebElementAncestorsCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.GetElementAncestors(this, ((IWebElement[])this.InputObject));
        }
    }
}
