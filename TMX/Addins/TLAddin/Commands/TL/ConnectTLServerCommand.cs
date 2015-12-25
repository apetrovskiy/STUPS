/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 5:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ConnectTLServerCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "TLServer", DefaultParameterSetName = "ConnectTestLink")]
    public class ConnectTLServerCommand : TLSConnectCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            var command = new TLSrvConnectCommand(this);
            command.Execute();
        }
    }
}
