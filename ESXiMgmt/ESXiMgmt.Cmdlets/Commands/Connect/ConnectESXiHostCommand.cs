/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands
{
    using System;
    using System.Management.Automation;
        
    /// <summary>
    /// Description of ConnectESXiHostCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "ESXiHost")]
    public class ConnectESXiHostCommand : ConnectCmdletBase
    {
        public ConnectESXiHostCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            ESXiConnection result = 
                VMwareHelper.ConnectToServer(
                    null,
                    this.Server,
                    this.Port,
                    this.Username,
                    this.Password,
                    this.DatastoreName);
            WriteObject(result);
        }
        
    }
}
