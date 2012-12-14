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
        [Parameter(Mandatory = true,
                   ParameterSetName = "FromStore")]
        internal SwitchParameter FromStore { get; set; }
        
        //[Parameter(Mandatory = false,
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true,
                   ParameterSetName = "PipelineInput")]
        public Meyn.TestLink.TestProject[] InputObject { get; set; }
        
        //[Parameter(Mandatory = false,
        [Parameter(Mandatory = true,
                   ParameterSetName = "StringInput")]
        public string[] TestProjectName { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "PipelineInput")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "StringInput")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "FromStore")]
        public string TestPlanName { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal SwitchParameter Fake { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal new string[] Name { get; set; }
        //private new string[] Name { get; set; }
        #endregion Parameters
    }
}
