/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/1/2013
 * Time: 1:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RMConnectCmdletBase.
    /// </summary>
    public class RMConnectCmdletBase : RMCmdletBase
    {
        public RMConnectCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = "ConnectRedMine")]
        public string Server { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "ConnectRedMine")]
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
