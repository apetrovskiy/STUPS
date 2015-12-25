/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 7:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLTestCaseCmdletBase.
    /// </summary>
    public class TLTestCaseCmdletBase : TLSCmdletBase
    {
        public TLTestCaseCmdletBase()
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
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "TestSuiteInput")]
        public SwitchParameter Recurse { get; set; }

        [Parameter(Mandatory = false,
                   Position = 0)] //,
                   //ParameterSetName = "StringInput")]
        public string[] TestCaseName { get; set; }
        
//        [Parameter(Mandatory = false,
//                   Position = 0,
//                   ParameterSetName = "ByName")]
//        public new string[] Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string[] Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ById")]
        public new string[] Id { get; set; }
        #endregion Parameters
    }
}
