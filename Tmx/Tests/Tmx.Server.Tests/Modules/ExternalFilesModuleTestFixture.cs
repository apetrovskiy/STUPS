/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/12/2014
 * Time: 5:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    // using System.Management.Automation;

    /// <summary>
    /// Description of ExternalFilesModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ExternalFilesModuleTestFixture
    {
        public ExternalFilesModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            TestSettings.PrepareModuleTests();
        }
        
        
        // ============================================================================================================================
    }
}
