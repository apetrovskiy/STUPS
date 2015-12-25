/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/19/2012
 * Time: 12:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.TestSuites
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of GetTestSuiteTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class GetTestSuiteTestFixture
    {
        public GetTestSuiteTestFixture()
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
        }
    }
}
