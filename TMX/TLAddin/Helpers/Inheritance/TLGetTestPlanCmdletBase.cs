/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/14/2013
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLGetTestPlanCmdletBase.
    /// </summary>
    public class TLGetTestPlanCmdletBase : TLTestPlanCmdletBase
    {
        public TLGetTestPlanCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "PipelineInput")]
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "StringInput")]
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "FromStore")]
        [Alias("Name")]
        public string[] TestPlanName { get; set; }
        
        
        //internal new string[] Name { get; set; }
        internal new string Name { get; set; }
        #endregion Parameters
    }
}
