/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/14/2012
 * Time: 5:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using Meyn.TestLink;
    
    /// <summary>
    /// Description of TLBuildCmdletBase.
    /// </summary>
    public class TLBuildCmdletBase : TLSCmdletBase
    {
        public TLBuildCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "ByName")]
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "ById")]
        public Meyn.TestLink.TestPlan[] InputObject { get; set; }
        
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
