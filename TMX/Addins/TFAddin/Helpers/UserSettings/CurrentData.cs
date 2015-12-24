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
    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using System.Net;
    
    /// <summary>
    /// Description of CurrentData.
    /// </summary>
    public static class CurrentData
    {
//        public CurrentData()
//        {
//        }

        public static TfsConfigurationServer CurrentServer { get; set; }
        public static TfsTeamProjectCollection CurrentCollection { get; set; }
        public static ITestManagementTeamProject CurrentProject { get; set; }
        public static ITestPlan CurrentTestPlan { get; set; }
    }
}
