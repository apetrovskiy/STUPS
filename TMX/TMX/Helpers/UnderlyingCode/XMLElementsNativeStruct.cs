/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace Tmx
//{
//	using System;
//	using Tmx.Interfaces;
//
//	/// <summary>
//	/// Description of XMLElementsNativeStruct.
//	/// </summary>
//	public struct XMLElementsNativeStruct : IXMLElementsStruct
//	{
//	    public XMLElementsNativeStruct(SearchCmdletBase cmdlet)
//	    {
//	        this.suitesNode = "suites";
//	        this.suiteNode = "suite";
//	        this.scenariosNode = "scenarios";
//	        this.scenarioNode = "scenario";
//	        this.testResultsNode = "testResults";
//	        this.testResultNode = "testResult";
//	        
//	        this.failedAttribute = "failed";
//	        
//	        
//	        this.timeSpentAttribute = "timeSpent";
//	        this.timeStampAttribute = "timestamp";
//	    }
//	    
//		string suitesNode;
//		string suiteNode;
//		string scenariosNode;
//		string scenarioNode;
//		string testResultsNode;
//		string testResultNode;
//		string failedAttribute;
//
//		string timeSpentAttribute;
//		string timeStampAttribute;
//	    
//		//: IEquatable<XMLElementsNativeStruct>
////        int member; // this is just an example member, replace it with your own struct members!
////        
////        #region Equals and GetHashCode implementation
////        // The code in this region is useful if you want to use this structure in collections.
////        // If you don't need it, you can just remove the region and the ": IEquatable<XMLElementsNativeStruct>" declaration.
////        
////        public override bool Equals(object obj)
////        {
////            if (obj is XMLElementsNativeStruct)
////                return Equals((XMLElementsNativeStruct)obj); // use Equals method below
////            else
////                return false;
////        }
////        
////        public bool Equals(XMLElementsNativeStruct other)
////        {
////            // add comparisions for all members here
////            return this.member == other.member;
////        }
////        
////        public override int GetHashCode()
////        {
////            // combine the hash codes of all members here (e.g. with XOR operator ^)
////            return member.GetHashCode();
////        }
////        
////        public static bool operator ==(XMLElementsNativeStruct left, XMLElementsNativeStruct right)
////        {
////            return left.Equals(right);
////        }
////        
////        public static bool operator !=(XMLElementsNativeStruct left, XMLElementsNativeStruct right)
////        {
////            return !left.Equals(right);
////        }
////        #endregion
//
//		public string SuitesNode { get { return this.suitesNode; } }
//		public string SuiteNode { get { return this.suiteNode; } }
//		public string ScenariosNode { get { return this.scenariosNode; } }
//		public string ScenarioNode { get { return this.scenarioNode; } }
//		public string TestResultsNode { get { return this.testResultsNode; } }
//		public string TestResultNode { get { return this.testResultNode; } }
//		public string FailedAttribute { get { return this.failedAttribute; } }
//
//		public string TimeSpentAttribute { get { return this.timeSpentAttribute; } }
//		public string TimeStampAttribute { get { return this.timeStampAttribute; } }
//	}
//}
