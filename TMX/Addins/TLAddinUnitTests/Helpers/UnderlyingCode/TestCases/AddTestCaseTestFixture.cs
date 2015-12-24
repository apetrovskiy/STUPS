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
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using Tmx;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;
    
    /// <summary>
    /// Description of AddTestCaseTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class AddTestCaseTestFixture
    {
        public AddTestCaseTestFixture()
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
