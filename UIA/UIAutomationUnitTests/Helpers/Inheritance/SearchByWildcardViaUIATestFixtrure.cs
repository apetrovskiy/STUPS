/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/17/2013
 * Time: 10:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    //using System.Windows.Automation;
    using MbUnit.Framework;

    /// <summary>
    /// Description of SearchByWildcardViaUiaTestFixtrure.
    /// </summary>
    [TestFixture]
    public class SearchByWildcardViaUiaTestFixtrure
    {
        [SetUp]
        public void SetUp()
        {
//            UnitTestingHelper.PrepareUnitTestDataStore();
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
//        private IMySuperWrapper getPreparedElement(int childrenCount)
//        {
//            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
//            //element.FindAll(TreeScope.Descendants, any
//        }
        
        [Test]
        public void InputIsNull()
        {
            
        }
    }
}
