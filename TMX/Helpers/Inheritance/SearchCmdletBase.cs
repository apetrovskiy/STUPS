/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/29/2012
 * Time: 11:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SearchCmdletBase.
    /// </summary>
    public class SearchCmdletBase : CommonCmdletBase
    {
        public SearchCmdletBase()
        {
            this.Descending = false;
            this.FilterAll = true;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Id { get; set; }
        
        // Filter by parameters
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "All")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common",
                   Position = 0)]
        public SwitchParameter FilterAll { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "NameContains",
                   Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public string FilterNameContains { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "IdContains",
                   Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public string FilterIdContains { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "DescriptionContains",
                   Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public string FilterDescriptionContains { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "Passed",
                   Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter FilterPassed { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "Failed",
                   Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter FilterFailed { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "NotTested",
                   Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter FilterNotTested { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "PassedWithBadSmell",
                   Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter FilterPassedWithBadSmell { get; set; }
        
        // Order By parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter OrderByTimeSpent { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter OrderByDateTime { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter OrderByName { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter OrderById { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter OrderByPassRate { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter OrderByFailRate { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public SwitchParameter Descending { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public int Count { get; set; }
        #endregion Parameters
        
        internal SwitchParameter FilterNone { get; set; }
    }
}
