/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 6:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using Tmx.Server;
	using Tmx.Server.Helpers;
	using Tmx.Commands;
	
    /// <summary>
    /// Description of WaitTestWorkflowCompletedCommand.
    /// </summary>
    class WaitTestWorkflowCompletedCommand : TmxCommand
    {
        internal WaitTestWorkflowCompletedCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var serverWatcher = new ServerWatcher();
            serverWatcher.IsWorkflowCompleted();
        }
    }
}
