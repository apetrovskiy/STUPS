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
    using System;
    
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
    
    /// <summary>
    ///  /// </summary>
    public enum TestResultStatuses
    {
        /// <summary>
        ///  Passed
        /// </summary>
        Passed = 1,
        /// <summary>
        ///  Failed
        /// </summary>
        Failed = 2,
        /// <summary>
        ///  NotTested
        /// </summary>
        NotTested = 3,
        /// <summary>
        /// KnownIssue
        /// </summary>
        KnownIssue = 4
    }
    
    /// <summary>
    ///  /// </summary>
    public enum TestScenarioStatuses
    {
        /// <summary>
        ///  Passed
        /// </summary>
        Passed = 1,
        /// <summary>
        ///  Failed
        /// </summary>
        Failed = 2,
        /// <summary>
        ///  NotTested
        /// </summary>
        NotTested = 3, //,
        //Blocked = 4
        /// <summary>
        /// KnownIssue
        /// </summary>
        KnownIssue = 4
    }
    
    /// <summary>
    ///  /// </summary>
    public enum TestSuiteStatuses
    {
        /// <summary>
        ///  Passed
        /// </summary>
        Passed = 1,
        /// <summary>
        ///  Failed
        /// </summary>
        Failed = 2,
        /// <summary>
        ///  NotTested
        /// </summary>
        NotTested = 3, //,
        //Blocked = 4
        /// <summary>
        /// KnownIssue
        /// </summary>
        KnownIssue = 4
    }
    
    public enum TestResultOrigins
    {
        Automatic,
        Logical,
        Technical
    }
}
