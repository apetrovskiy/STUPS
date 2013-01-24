/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 9:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Net;
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
        public static Meyn.TestLink.TestProject CurrentTestProject { get; set; }
        public static Meyn.TestLink.TestPlan CurrentTestPlan { get; set; }
        public static Meyn.TestLink.TestSuite CurrentTestSuite { get; set; }
    }
}
