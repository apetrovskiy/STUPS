/*
 * Created by SharpDevelop.
 * User: apetrov1
 * Date: 3/30/2012
 * Time: 5:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ESXiMgmt.Commands
{
    using System;
    using System.Management.Automation;
        
    /// <summary>
    /// Description of ConnectESXiServerCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "ESXiServer")]
    public class ConnectESXiServerCommand : ConnectCmdletBase
    {
        public ConnectESXiServerCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            bool result = 
                VMwareHelper.ConnectToServer(
                    this.Server,
                    this.Port,
                    this.Username,
                    this.Password,
                    this.DatastoreName);
            
            WriteObject(result);
            
        }
        
    }
}
