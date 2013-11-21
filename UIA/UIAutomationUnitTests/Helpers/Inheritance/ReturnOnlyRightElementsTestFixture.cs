/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/18/2013
 * Time: 1:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of ReturnOnlyRightElementsTestFixture.
    /// </summary>
    public class ReturnOnlyRightElementsTestFixture
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
        
//        [Test]
//        public void Probe()
//        {
//            
//            
//            ReturnOnlyRightElements(
//            HasTimeoutCmdletBase cmdlet,
//            IEnumerable inputCollection,
//            string name,
//            string automationId,
//            string className,
//            string textValue,
//            string[] controlType,
//            bool caseSensitive)
//        }
    }
}
