/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 08:38 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ScenarioCmdletBase.
    /// </summary>
    public class ScenarioCmdletBase : CommonCmdletBase
    {
        public ScenarioCmdletBase()
        {
            this.TestSuiteName = string.Empty;
            this.TestSuiteId = string.Empty;
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true)]
        public TestSuite InputObject { get; set; }
        [Parameter(Mandatory = false)]
        public string TestSuiteName { get; set; }
        [Parameter(Mandatory = false)]
        public string TestSuiteId { get; set; }
        #endregion Parameters
    }
}
