/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 7:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLProjectCmdletBase.
    /// </summary>
    public class TLProjectCmdletBase : TLSCmdletBase
    {
        public TLProjectCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "ByName")]
        public new string[] Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ById")]
        public new string[] Id { get; set; }
        #endregion Parameters
    }
}
