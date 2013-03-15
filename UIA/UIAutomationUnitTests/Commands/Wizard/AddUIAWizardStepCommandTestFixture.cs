/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/15/2013
 * Time: 8:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Wizard
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using UIAutomation;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of AddUIAWizardStepCommandTestFixture.
	/// </summary>
	[TestFixture]
	public class AddUIAWizardStepCommandTestFixture
	{
		public AddUIAWizardStepCommandTestFixture()
		{
		}
		
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
            WizardCollection.ResetData();
        }
	}
}
