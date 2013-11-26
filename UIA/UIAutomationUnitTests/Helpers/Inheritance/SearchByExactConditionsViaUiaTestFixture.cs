/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2013
 * Time: 2:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of SearchByExactConditionsViaUiaTestFixture.
    /// </summary>
    public class SearchByExactConditionsViaUiaTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        #endregion helpers
        
        #region //
//        public void Get0_NoParam()
//        {
//            string name = string.Empty;
//            string automationId = string.Empty;
//            string className = string.Empty;
//            string txtValue = string.Empty;
//            ControlType controlType = null;
//            TestParametersAgainstCollection(
//                controlType,
//                name,
//                automationId,
//                className,
//                txtValue,
//                new MySuperWrapper[] {},
//                0);
//        }
        #endregion
    }
}
