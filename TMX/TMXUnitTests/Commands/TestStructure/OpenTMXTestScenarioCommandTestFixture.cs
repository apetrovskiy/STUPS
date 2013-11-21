/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 11:47 PM
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
    /// Description of OpenTmxTestScenarioCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class OpenTmxTestScenarioCommandTestFixture
    {
        public OpenTmxTestScenarioCommandTestFixture()
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
        [Description("Open-TmxTestScenario")]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
