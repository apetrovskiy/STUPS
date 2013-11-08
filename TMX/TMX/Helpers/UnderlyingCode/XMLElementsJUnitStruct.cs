/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
	using System;

    /// <summary>
    /// Description of XMLElementsJUnitStruct.
    /// </summary>
    public struct XMLElementsJUnitStruct : IXMLElementsStruct //IEquatable<XMLElementsJUnitStruct>
    {
        public XMLElementsJUnitStruct(SearchCmdletBase cmdlet)
        {
	        this.suitesNode = "testsuites";
	        this.suiteNode = "testsuite";
	        this.scenariosNode = "testsuites";
	        this.scenarioNode = "testsuite";
	        this.testResultsNode = "testcases";
	        this.testResultNode = "testcase";
	        
	        this.failedAttribute = "errors";
	        
	        
	        this.timeSpentAttribute = "time";
	        this.timeStampAttribute = "timestamp";
        }
        
		private string suitesNode;
		private string suiteNode;
		private string scenariosNode;
		private string scenarioNode;
		private string testResultsNode;
		private string testResultNode;
		private string failedAttribute;

		private string timeSpentAttribute;
		private string timeStampAttribute;
        
//        int member; // this is just an example member, replace it with your own struct members!
//        
//        #region Equals and GetHashCode implementation
//        // The code in this region is useful if you want to use this structure in collections.
//        // If you don't need it, you can just remove the region and the ": IEquatable<XMLElementsJUnitStruct>" declaration.
//        
//        public override bool Equals(object obj)
//        {
//            if (obj is XMLElementsJUnitStruct)
//                return Equals((XMLElementsJUnitStruct)obj); // use Equals method below
//            else
//                return false;
//        }
//        
//        public bool Equals(XMLElementsJUnitStruct other)
//        {
//            // add comparisions for all members here
//            return this.member == other.member;
//        }
//        
//        public override int GetHashCode()
//        {
//            // combine the hash codes of all members here (e.g. with XOR operator ^)
//            return member.GetHashCode();
//        }
//        
//        public static bool operator ==(XMLElementsJUnitStruct left, XMLElementsJUnitStruct right)
//        {
//            return left.Equals(right);
//        }
//        
//        public static bool operator !=(XMLElementsJUnitStruct left, XMLElementsJUnitStruct right)
//        {
//            return !left.Equals(right);
//        }
//        #endregion

//		public string SuitesNode { get; internal set; }
//		public string SuiteNode { get; internal set; }
//		public string ScenariosNode { get; internal set; }
//		public string ScenarioNode { get; internal set; }
//		public string TestResultsNode { get; internal set; }
//		public string TestResultNode { get; internal set; }
//		public string FailedAttribute { get; internal set; }
//
//		public string TimeSpentAttribute { get; internal set; }
//		public string TimeStampAttribute { get; internal set; }

		public string SuitesNode { get { return this.suitesNode; } }
		public string SuiteNode { get { return this.suiteNode; } }
		public string ScenariosNode { get { return this.scenariosNode; } }
		public string ScenarioNode { get { return this.scenarioNode; } }
		public string TestResultsNode { get { return this.testResultsNode; } }
		public string TestResultNode { get { return this.testResultNode; } }
		public string FailedAttribute { get { return this.failedAttribute; } }

		public string TimeSpentAttribute { get { return this.timeSpentAttribute; } }
		public string TimeStampAttribute { get { return this.timeStampAttribute; } }
    }
}
