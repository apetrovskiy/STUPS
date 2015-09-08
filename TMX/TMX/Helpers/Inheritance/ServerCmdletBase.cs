/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 5:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ServerCmdletBase.
    /// </summary>
    public class ServerCmdletBase : CommonCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        // [ValidateNotNullOrEmpty()]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Id { get; set; }
        
        [Parameter(Mandatory = false)]
        // [AllowNull]
        // [AllowEmptyString]
        internal new string TestPlatformId { get; set; }
        
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter TestPassed { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter KnownIssue { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter TestLog { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new string TestResultName { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new string TestResultId { get; set; }
        #endregion Parameters
    }
}
