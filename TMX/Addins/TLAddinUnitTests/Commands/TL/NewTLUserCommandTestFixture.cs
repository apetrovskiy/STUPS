/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/9/2013
 * Time: 4:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.Commands.TL
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of NewTLUserCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewTLUserCommandTestFixture
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
    }
}
