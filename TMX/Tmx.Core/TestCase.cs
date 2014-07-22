/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 1:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestCase.
    /// </summary>
    public class TestCase : ITestCase
    {
        public TestCase(string testCaseName, string testCaseId) //, string testCaseNumber)
        {
            this.TestCaseName = testCaseName;
            // 20130617
            //this.TestCaseNumber = testCaseNumber;
            this.TestCaseId = testCaseId;
        }
        
        public TestCase(
            string testCaseName,
            // 20130617
            //string testCaseNumber,
            string testCaseId,
            ScriptBlock[] beforeCode,
            ScriptBlock[] mainCode,
            ScriptBlock[] afterCode)
        {
            this.TestCaseName = testCaseName;
            // 20130617
            //this.TestCaseNumber = testCaseNumber;
            this.TestCaseId = testCaseId;
            //this.AlternateBeforeTest = beforeCode;
            this.TestCode = mainCode;
            //this.AlternateAfterTest = afterCode;
        }
        
        public virtual int DbId { get; set; }
        //public int TestCaseId { get; set; }
        public string TestCaseId { get; set; }
        public string TestCaseName { get; set; }
        // 20130617
        //public string TestCaseNumber { get; set; }
        //public ScriptBlock[] AlternateBeforeTest { get; set; }
        public ScriptBlock[] TestCode { get; set; }
        //public ScriptBlock[] AlternateAfterTest { get; set; }
        public string TestCaseTag { get; set; }
        public string Description { get; set; }
        public virtual object[] TestCodeParameters { get; set; }
    }
}
