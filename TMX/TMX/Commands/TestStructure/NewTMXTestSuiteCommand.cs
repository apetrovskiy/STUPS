/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTmxTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TmxTestSuite")]
    public class NewTmxTestSuiteCommand : NewSuiteCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            var command = new TmxNewTestSuiteCommand(this);
            command.Execute();
        }
    }
}
