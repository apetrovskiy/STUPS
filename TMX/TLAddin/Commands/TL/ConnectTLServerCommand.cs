/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 5:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ConnectTLServerCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "TLServer", DefaultParameterSetName = "ConnectTestLink")]
    public class ConnectTLServerCommand : TLSConnectCmdletBase
    {
        public ConnectTLServerCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            TLSrvConnectCommand command =
                new TLSrvConnectCommand(this);
            command.Execute();
        }
    }
}
