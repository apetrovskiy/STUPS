/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    
    /// <summary>
    ///  /// </summary>
    public enum TestResultDetailTypes
    {
        /// <summary>
        ///  
        /// </summary>
        Screenshot = 0,
        /// <summary>
        ///  
        /// </summary>
        ErrorRecord = 1,
        /// <summary>
        ///   
        /// </summary>
        Comment = 2
    }
    
    /// <summary>
    ///  /// </summary>
    public enum TestResultStatuses
    {
        /// <summary>
        ///  
        /// </summary>
        Passed = 1,
        /// <summary>
        ///  
        /// </summary>
        Failed = 2,
        /// <summary>
        ///  
        /// </summary>
        NotTested = 3,
        /// <summary>
        /// 
        /// </summary>
        KnownIssue = 4
    }
    
    /// <summary>
    ///  /// </summary>
    public enum TestScenarioStatuses
    {
        /// <summary>
        ///  
        /// </summary>
        Passed = 1,
        /// <summary>
        ///  
        /// </summary>
        Failed = 2,
        /// <summary>
        ///  
        /// </summary>
        NotTested = 3, //,
        //Blocked = 4
        KnownIssue = 4
    }
    
    /// <summary>
    ///  /// </summary>
    public enum TestSuiteStatuses
    {
        /// <summary>
        ///  
        /// </summary>
        Passed = 1,
        /// <summary>
        ///  
        /// </summary>
        Failed = 2,
        /// <summary>
        ///  
        /// </summary>
        NotTested = 3, //,
        //Blocked = 4
        KnownIssue = 4
    }
}
