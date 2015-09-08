/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.TestStructure
{
    /// <summary>
    ///  /// </summary>
    public enum TestResultDetailTypes
    {
        /// <summary>
        ///  Contains path to a screenshot
        /// </summary>
        Screenshot = 0,
        /// <summary>
        ///  Contains error object
        /// </summary>
        ErrorRecord = 1,
        /// <summary>
        ///   Contains user's comment
        /// </summary>
        Comment = 2,
        /// <summary>
        /// Contains path to the log file
        /// </summary>
        Log = 3,
        /// <summary>
        /// Contains some external link
        /// </summary>
        ExternalData = 4
    }
    
    public enum TestResultOrigins
    {
        Automatic,
        Logical,
        Technical
    }

    public enum TestStatuses
    {
        Passed = 1,
        Failed = 2,
        NotRun = 3,
        KnownIssue = 4,
        Blocked = 5,
        WorkInProgress = 6
    }

    public enum TestTagRuleScopes
    {
        Include = 1,
        Exclude = 2
    }

    public enum TestTagRuleActions
    {
        RaiseSeverity = 1,
        DecreaseSeverity = 2
    }
}
