/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 9:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    //using Autofac;
    //using Autofac.Builder;

    /// <summary>
    /// Description of GetBuildTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class GetBuildTestFixture
    {
        public GetBuildTestFixture()
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
