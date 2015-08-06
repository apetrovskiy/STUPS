/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/29/2014
 * Time: 8:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    /// <summary>
    /// Description of ITestRunCommand.
    /// </summary>
    public interface ITestRunCommand
    {
        string TestRunName { get; set; }
        string WorkflowName { get; set; }
        TestRunStatuses Status { get; set; }
    }
}
