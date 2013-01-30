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
    /// Description of TLTestPlanCmdletBase.
    /// </summary>
    public class TLTestPlanCmdletBase : TLSCmdletBase
    {
        public TLTestPlanCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "FromStore")]
        internal SwitchParameter FromStore { get; set; }
        
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "PipelineInput")]
        public Meyn.TestLink.TestProject[] InputObject { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "StringInput")]
        public string[] TestProjectName { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal SwitchParameter Fake { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal new string[] Name { get; set; }
        #endregion Parameters
    }
}
