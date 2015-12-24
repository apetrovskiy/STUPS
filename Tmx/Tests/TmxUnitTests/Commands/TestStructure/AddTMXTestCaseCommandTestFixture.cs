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
    /// <summary>
    /// Description of AddTmxTestCaseCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class AddTmxTestCaseCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("Add-TmxTestCase")]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore("")]
        public void Need_Code()
        {
            
        }
    }
}
