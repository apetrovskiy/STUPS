/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/26/2014
 * Time: 6:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System.Collections.Generic;
    using Tmx.Interfaces.Remoting;

    /// <summary>
    /// Description of TestRunQueue.
    /// </summary>
    public class TestRunQueue
    {
        public static List<ITestRun> TestRuns = new List<ITestRun>();
    }
}
