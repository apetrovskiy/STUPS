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
    /// Description of ConnectTFServerCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "TFServer")]
    public class ConnectTFServerCommand : TFSConnectCmdletBase
    {
        public ConnectTFServerCommand()
        {
        }
        
//        #region Parameters
//        [Parameter(Mandatory = true,
//                   Position = 0)]
//        public string Server { get; set; }
//        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvConnectCommand command =
                new TFSrvConnectCommand(this);
            command.Execute();
        }
    }
}
