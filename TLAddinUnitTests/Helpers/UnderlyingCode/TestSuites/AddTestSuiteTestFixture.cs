/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/19/2012
 * Time: 12:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.TestSuites
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using TMX;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;
    
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of AddTestSuiteTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class AddTestSuiteTestFixture
    {
        public AddTestSuiteTestFixture()
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
