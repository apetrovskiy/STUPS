/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using Tmx.Interfaces;

    /// <summary>
    /// Description of XMLElementsJUnitStruct.
    /// </summary>
    public struct XMLElementsJUnitStruct : IXMLElementsStruct //IEquatable<XMLElementsJUnitStruct>
    {
		const string suitesNode = "testsuites";
		const string suiteNode = "testsuite";
		const string scenariosNode = "testsuites";
		const string scenarioNode = "testsuite";
		const string testResultsNode = "testcases";
		const string testResultNode = "testcase";
		const string failedAttribute = "errors";

		const string timeSpentAttribute = "time";
		const string timeStampAttribute = "timestamp";
		
		public string SuitesNode { get { return suitesNode; } }
		public string SuiteNode { get { return suiteNode; } }
		public string ScenariosNode { get { return scenariosNode; } }
		public string ScenarioNode { get { return scenarioNode; } }
		public string TestResultsNode { get { return testResultsNode; } }
		public string TestResultNode { get { return testResultNode; } }
		public string FailedAttribute { get { return failedAttribute; } }

		public string TimeSpentAttribute { get { return timeSpentAttribute; } }
		public string TimeStampAttribute { get { return timeStampAttribute; } }
    }
}
