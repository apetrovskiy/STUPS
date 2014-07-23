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
	/// Description of XMLElementsNativeStruct.
	/// </summary>
	public struct XMLElementsNativeStruct : IXMLElementsStruct
	{
		const string suitesNode = "suites";
		const string suiteNode = "suite";
		const string scenariosNode = "scenarios";
		const string scenarioNode = "scenario";
		const string testResultsNode = "testResults";
		const string testResultNode = "testResult";
		const string failedAttribute = "failed";

		const string timeSpentAttribute = "timeSpent";
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
