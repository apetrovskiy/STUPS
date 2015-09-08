/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/12/2014
 * Time: 7:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands.TestClient
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxCurrentTestTaskCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxCurrentTestTask")]
    public class GetTmxCurrentTestTaskCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new GetCurrentTestTaskCommand(this);
            command.Execute();
        }
    }
}
