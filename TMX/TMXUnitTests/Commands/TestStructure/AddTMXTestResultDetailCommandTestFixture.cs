/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 1:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of AddTMXTestResultDetailCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class AddTMXTestResultDetailCommandTestFixture
    {
        public AddTMXTestResultDetailCommandTestFixture()
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
        [Description("Add-TMXTestResultDetail")]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
