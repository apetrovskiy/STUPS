/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 1:39 PM
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
    /// Description of GetTmxTestCaseCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetTmxTestCaseCommandTestFixture
    {
        public GetTmxTestCaseCommandTestFixture()
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
        [Description("Get-TmxTestCase")]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
