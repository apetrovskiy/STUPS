using System.Windows.Automation;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/17/2013
 * Time: 10:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using System;
    //using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    using NSubstitute;
    
    /// <summary>
    /// Description of SearchByWildcardViaUIATestFixtrure.
    /// </summary>
    [TestFixture]
    public class SearchByWildcardViaUIATestFixtrure
    {
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
//        private IMySuperWrapper getPreparedElement(int childrenCount)
//        {
//            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
//            //element.FindAll(TreeScope.Descendants, any
//        }
        
        [Test]
        public void InputIsNull()
        {
            
        }
    }
}
