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
    /// Description of TFSConnectCmdletBase.
    /// </summary>
    public class TFSConnectCmdletBase : TFSCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string Url { get; set; }
        
        
        [Parameter(Mandatory = true)]
        public ICredentials Credentials { get; set; }
        
        
        [Parameter(Mandatory = false)]
        // 20131102
        // ReSharper warning
        internal new string Name { get; set; }
        [Parameter(Mandatory = false)]
        // 20131102
        // ReSharper warning
        internal new string Id { get; set; }
        #endregion Parameters
    }
}
