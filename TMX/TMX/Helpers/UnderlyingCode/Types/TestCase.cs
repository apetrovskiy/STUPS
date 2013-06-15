/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 1:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of TestCase.
    /// </summary>
    public class TestCase : ITestCase
    {
        public TestCase(string testCaseName, string testCaseNumber)
        {
            this.TestCaseName = testCaseName;
            this.TestCaseNumber = testCaseNumber;
        }
        
        public TestCase(
            string testCaseName, 
            string testCaseNumber,
            ScriptBlock beforeCode,
            ScriptBlock mainCode,
            ScriptBlock afterCode)
        {
            this.TestCaseName = testCaseName;
            this.TestCaseNumber = testCaseNumber;
            this.AlternateBeforeTest = beforeCode;
            this.TestCode = mainCode;
            this.AlternateAfterTest = afterCode;
        }
        
        public int TestCaseId { get; set; }
        public string TestCaseName { get; set; }
        public string TestCaseNumber { get; set; }
        //public ScriptBlock AlternateBeforeTest { get; set; }
        public ScriptBlock TestCode { get; set; }
        //public ScriptBlock AlternateAfterTest { get; set; }
        public string TestCaseTag { get; set; }
        public string Description { get; set; }
    }
}
