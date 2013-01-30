/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using System.Net;
    
    /// <summary>
    /// Description of TLSConnectCmdletBase.
    /// </summary>
    public class TLSConnectCmdletBase : TLSCmdletBase
    {
        public TLSConnectCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = "ConnectTestLink")]
        public string Server { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "ConnectTestLink")]
        public string ApiKey { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal SwitchParameter Fake { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal new string Id { get; set; }
        #endregion Parameters
    }
}
