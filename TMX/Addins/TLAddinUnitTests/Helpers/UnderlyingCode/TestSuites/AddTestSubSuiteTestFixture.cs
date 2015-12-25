/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/19/2012
 * Time: 12:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.TestSuites
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of AddTestSubSuiteTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class AddTestSubSuiteTestFixture
    {
        public AddTestSubSuiteTestFixture()
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
