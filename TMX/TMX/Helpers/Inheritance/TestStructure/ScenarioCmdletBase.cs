/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 08:38 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    using Interfaces.TestStructure;
    
    /// <summary>
    /// Description of ScenarioCmdletBase.
    /// </summary>
    public class ScenarioCmdletBase : CommonCmdletBase
    {
        public ScenarioCmdletBase()
        {
            TestSuiteName = string.Empty;
            TestSuiteId = string.Empty;
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true)]
        // 20140720
        // public TestSuite InputObject { get; set; }
        public ITestSuite InputObject { get; set; }
        [Parameter(Mandatory = false)]
        public string TestSuiteName { get; set; }
        [Parameter(Mandatory = false)]
        public string TestSuiteId { get; set; }
        #endregion Parameters
    }
}
