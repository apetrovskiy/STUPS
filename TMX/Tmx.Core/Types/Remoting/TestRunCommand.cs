/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/29/2014
 * Time: 8:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestRunCommand.
    /// </summary>
    public class TestRunCommand : ITestRunCommand
    {
        public string Name { get; set; }
        public string WorkflowName { get; set; }
        public TestRunStatuses Status { get; set; }
    }
}
