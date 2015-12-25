/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/13/2014
 * Time: 11:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Wait
{
    /// <summary>
    /// Description of WaitUIAControlIsVisibleCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class WaitUIAControlIsVisibleCommandTestFixture
    {
        public WaitUIAControlIsVisibleCommandTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
//        private void TestParametersAgainstCollection(
//            Hashtable[] inputData,
//            IEnumerable<IUiElement> collection,
//            bool expectedResult)
//        {
//            // Arrange
//            var data =
//                new ControlSearcherData {
//                SearchCriteria = inputData
//            };
//            
//            Condition condition =
//                ControlSearcher.GetWildcardSearchCondition(data);
//            
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    collection,
//                    condition);
//            
//            var cmdlet =
//                new WaitUiaControlStateCommand {
//                SearchCriteria = inputData,
//                InputObject = new[] { element }
//            };
//            
//            // Act
//            var command = new WaitControlStateCommand(cmdlet);
//            command.Execute();
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual<bool>(
//                expectedResult,
//                (bool)PSTestLib.UnitTestOutput.LastOutput[0]);
//            Xunit.Assert.Equal<bool>(
//                expectedResult,
//                (bool)PSTestLib.UnitTestOutput.LastOutput[0]);
//        }
        #endregion helpers
    }
}
