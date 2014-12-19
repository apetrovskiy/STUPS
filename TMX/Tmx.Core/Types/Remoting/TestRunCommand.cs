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
        // 20141219
        string _nameSuffix;
        string _testRunName;
        
        public TestRunCommand()
        {
            Status = TestRunStatuses.Pending; // ??
            _nameSuffix = " " + DateTime.Now;
        }
        
        
        public string TestRunName
        {
            get
            {
                return _testRunName == string.Empty ? WorkflowName + _nameSuffix : _testRunName;
            }
            set
            {
                _nameSuffix = string.Empty;
                _testRunName = value;
            }
        }
        public string WorkflowName { get; set; }
        public TestRunStatuses Status { get; set; }
    }
}
