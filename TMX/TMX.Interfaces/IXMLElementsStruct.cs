/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
	using System;
	
	public interface IXMLElementsStruct
	{
		string SuitesNode { get; }
		string SuiteNode { get; }
		string ScenariosNode { get; }
		string ScenarioNode { get; }
		string TestResultsNode { get; }
		string TestResultNode { get; }
		
		string FailedAttribute { get; }
		
		string TimeSpentAttribute { get; }
		string TimeStampAttribute { get; }
	}
}
