/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ESXiMgmt
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ConnectCmdletBase.
    /// </summary>
    public class ConnectCmdletBase : CommonCmdletBase
    {
        public ConnectCmdletBase()
        {
            this.Port = 22; //443;
            this.Protocol = "HTTPS";
            this.Password = string.Empty; // ?
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "UserInput")]
        [ValidateNotNullOrEmpty()]
        public string Server { get; set; }
        [Parameter(Mandatory = false,
                   ParameterSetName = "UserInput")]
        public int Port { get; set; }
        [Parameter(Mandatory = false,
                   ParameterSetName = "UserInput")]
        public string Protocol { get; set; }
        [Parameter(Mandatory = false,
                   ParameterSetName = "UserInput")]
        [ValidateNotNullOrEmpty()]
        public string Username { get; set; }
        [Parameter(Mandatory = false,
                   ParameterSetName = "UserInput")]
        [AllowEmptyString()]
        public string Password { get; set; }
        [Parameter(Mandatory = false,
                   ParameterSetName = "UserInput")]
        //[ValidateNotNullOrEmpty()]
        public string DatastoreName { get; set; }
//        [Parameter(Mandatory=$true)]
//        [ValidateNotNullOrEmpty()]
//        public string Drive { get; set; }
        [Parameter(Mandatory = true,
                   ParameterSetName = "PipelineInput")]
        public ESXiConnection InputObject { get; set; }
        #endregion Parameters
    }
}
