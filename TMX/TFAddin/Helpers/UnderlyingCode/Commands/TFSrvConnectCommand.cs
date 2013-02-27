﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvConnectCommand.
    /// </summary>
    internal class TFSrvConnectCommand : TFSrvCommand
    {
        internal TFSrvConnectCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.ConnectTFServer(
                this.Cmdlet,
                ((TFSConnectCmdletBase)this.Cmdlet).Url,
                ((TFSConnectCmdletBase)this.Cmdlet).Credentials);
        }
    }
}