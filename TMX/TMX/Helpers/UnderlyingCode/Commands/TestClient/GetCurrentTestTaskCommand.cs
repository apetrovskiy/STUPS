/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/12/2014
 * Time: 7:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Tmx.Client;
    using Tmx.Commands.TestClient;
    
    /// <summary>
    /// Description of GetCurrentTestTaskCommand.
    /// </summary>
    class GetCurrentTestTaskCommand : TmxCommand
    {
        internal GetCurrentTestTaskCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxCurrentTestTaskCommand)Cmdlet;
            try {
                cmdlet.WriteObject(ClientSettings.Instance.CurrentTask);
            }
            catch (Exception e) {
                throw new Exception("Failed to get the current task. " + e.Message);
            }
        }
    }
}
