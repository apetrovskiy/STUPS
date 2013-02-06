/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2013
 * Time: 10:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetAutomationElementsViaWildcards_FindAllTestFixture.
    /// </summary>
    [TestFixture]
    public class GetAutomationElementsViaWildcards_FindAllTestFixture
    {
        public GetAutomationElementsViaWildcards_FindAllTestFixture()
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
        
//        private GetControlCollectionCmdletBase getClass(
//            
//            string name, string automationId, string )
//        {
//            return new GetControlCollectionCmdletBase();
//        }
//        
//        [Test]
//        [Description("GetControlCollectionCmdletBase.GetAutomationElementsViaWildcards_FindAll(x6)")]
//        [Category("Fast")]
//        public void Nothing_to_compare()
//        {
//            Assert.AreEqual(
//                false,
//                getClass().elementOfPossibleControlType(
//                    null,
//                    null));
//        }
    }
}
