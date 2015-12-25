/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 9:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using Meyn.TestLink;
    
    /// <summary>
    /// Description of CurrentData.
    /// </summary>
    public static class TLAddinData
    {
//        public CurrentData()
//        {
//        }

        public static ITestLinkExtra CurrentTestLinkConnection { get; set; }
        public static TestProject CurrentTestProject { get; set; }
        public static TestPlan CurrentTestPlan { get; set; }
        public static TestSuite CurrentTestSuite { get; set; }
    }
}
