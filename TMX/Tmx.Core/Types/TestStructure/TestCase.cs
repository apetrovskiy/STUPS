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
    using System.Xml.Serialization;
    using Interfaces.Remoting;
    using Interfaces.TestStructure;

    /// <summary>
    /// Description of TestCase.
    /// </summary>
    public class TestCase : ITestCase
    {
        public TestCase(string testCaseName, string testCaseId) //, string testCaseNumber)
        {
            TestCaseName = testCaseName;
            // 20130617
            //this.TestCaseNumber = testCaseNumber;
            TestCaseId = testCaseId;
        }
        
        public TestCase(
            string testCaseName,
            // 20130617
            //string testCaseNumber,
            string testCaseId,
            // 20141211
//            ScriptBlock[] beforeCode,
//            ScriptBlock[] mainCode,
//            ScriptBlock[] afterCode)
            ICodeBlock[] beforeCode,
            ICodeBlock[] mainCode,
            ICodeBlock[] afterCode)
        {
            TestCaseName = testCaseName;
            // 20130617
            //this.TestCaseNumber = testCaseNumber;
            TestCaseId = testCaseId;
            //this.AlternateBeforeTest = beforeCode;
            TestCode = mainCode;
            //this.AlternateAfterTest = afterCode;
        }
        
        public virtual int UniqueId { get; set; }
        //public int TestCaseId { get; set; }
        public string TestCaseId { get; set; }
        public string TestCaseName { get; set; }
        // 20130617
        //public string TestCaseNumber { get; set; }
        //public ScriptBlock[] AlternateBeforeTest { get; set; }
        // 20141211
        // public ScriptBlock[] TestCode { get; set; }
        public ICodeBlock[] TestCode { get; set; }
        //public ScriptBlock[] AlternateAfterTest { get; set; }
        public string TestCaseTag { get; set; }
        public string Description { get; set; }
        public virtual object[] TestCodeParameters { get; set; }
        [XmlAttribute]
        public string Tag { get; set; }
    }
}
