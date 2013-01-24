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
    /// Description of TLTestSuiteCmdletBase.
    /// </summary>
    public class TLTestSuiteCmdletBase : TLSCmdletBase
    {
        public TLTestSuiteCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "TestProjectInput")]
        public Meyn.TestLink.TestProject[] InputObjectTestProject { get; set; }
        
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "TestPlanInput")]
        public Meyn.TestLink.TestPlan[] InputObjectTestPlan { get; set; }
        
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "TestSuiteInput")]
        public Meyn.TestLink.TestSuite[] InputObjectTestSuite { get; set; }
        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "StringInput")]
//        public string[] TestProjectName { get; set; }

        [Parameter(Mandatory = false,
                   ParameterSetName = "StringInput")]
        public string[] TestSuiteName { get; set; }
        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "TestProjectInput")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "TestPlanInput")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "TestSuiteInput")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "StringInput")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "WrongParameter")]
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "fake")]
        internal new string[] Name { get; set; }
        //private new string Name { get; set; }
        #endregion Parameters
    }
}
