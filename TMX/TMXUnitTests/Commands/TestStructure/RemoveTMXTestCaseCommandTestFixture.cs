/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 1:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of RemoveTmxTestCaseCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class RemoveTmxTestCaseCommandTestFixture
    {
        public RemoveTmxTestCaseCommandTestFixture()
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
        
        [Test]
        [Description("Remove-TmxTestCase")]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
