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
    using System;
    using System.Collections;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    using NSubstitute;
    using System.Linq;
    using System.Linq.Expressions;
    
    /// <summary>
    /// Description of SearchByWildcardViaUIATestFixture.
    /// </summary>
    [TestFixture]
    public class SearchByWildcardViaUIATestFixture
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
