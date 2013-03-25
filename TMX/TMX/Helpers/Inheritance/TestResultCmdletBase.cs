/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 08:55 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestResultCmdletBase.
    /// </summary>
    public class TestResultCmdletBase : CommonCmdletBase
    {
        public TestResultCmdletBase()
        {
        }
        
        #region Parameters
        // 20130325
        //[Parameter(Mandatory = false)]
        [Parameter(Mandatory = false,
                   Position = 0)]
        public new SwitchParameter TestPassed { get; set; }
        
        [Parameter(Mandatory = false)]
        public new SwitchParameter KnownIssue { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Echo { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public new SwitchParameter TestLog { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        // 20130325
        //[Parameter(Mandatory = true,
        //           Position = 0)]
        [Parameter(Mandatory = false)]
        // 20130325
        //[ValidateNotNullOrEmpty]
        [Alias("Name")]
        // 20130325
        //public override string TestResultName { get; set; }
        public new string TestResultName { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public new string TestResultId { get; set; }
        #endregion Parameters
    }
}
