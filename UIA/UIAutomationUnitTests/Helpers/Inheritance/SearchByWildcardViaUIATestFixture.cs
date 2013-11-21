/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2013
 * Time: 12:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of SearchByWildcardViaUiaTestFixture.
    /// </summary>
    [TestFixture]
    public class SearchByWildcardViaUiaTestFixture
    {
        [SetUp]
        public void SetUp()
        {
//            UnitTestingHelper.PrepareUnitTestDataStore();
//            ObjectsFactory.InitUnitTests();
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        
    }
}
