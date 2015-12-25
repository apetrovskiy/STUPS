/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/19/2012
 * Time: 12:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.TestCases
{
    using MbUnit.Framework;
    //using Autofac;
    //using Autofac.Builder;

    /// <summary>
    /// Description of GetTestCaseTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class GetTestCaseTestFixture
    {
        public GetTestCaseTestFixture()
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
