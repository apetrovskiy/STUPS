/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 1:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXUnitTests.Commands.Status
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    //using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using TMX;
    
    /// <summary>
    /// Description of RemoveTMXTestCaseCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class RemoveTMXTestCaseCommandTestFixture
    {
        public RemoveTMXTestCaseCommandTestFixture()
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
        [Description("Remove-TMXTestCase")]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
