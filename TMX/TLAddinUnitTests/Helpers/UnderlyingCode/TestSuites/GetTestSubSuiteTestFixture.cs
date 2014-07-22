/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/19/2012
 * Time: 12:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.TestSuites
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    using Tmx;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;
    
    /// <summary>
    /// Description of GetTestSubSuiteTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class GetTestSubSuiteTestFixture
    {
        public GetTestSubSuiteTestFixture()
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
