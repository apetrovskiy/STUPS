/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 5:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Helpers.UnderlyingCode.Commands.TestServer
{
    using Server.Logic.ObjectModel;
    using Tmx.Commands.TestServer;

    /// <summary>
    /// Description of ImportTestWorkflowCommand.
    /// </summary>
    class ImportTestWorkflowCommand : TmxCommand
    {
        internal ImportTestWorkflowCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ImportTmxTestWorkflowCommand)Cmdlet;
            var workflowLoader = new WorkflowLoader();
            cmdlet.WriteObject(workflowLoader.Load(cmdlet.Path));
        }
    }
}
