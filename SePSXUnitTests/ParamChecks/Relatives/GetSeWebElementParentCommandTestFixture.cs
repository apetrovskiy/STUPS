/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 16:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
	/// <summary>
	/// Description of GetSeWebElementParentCommand.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "SeWebElementParent")]
	public class GetSeWebElementParentCommandTestFixture //  WebElementCmdletBase
	{
		public GetSeWebElementParentCommandTestFixture()
		{
		}
		
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.GetElementParent(this, ((IWebElement[])this.InputObject));
        }
	}
}
