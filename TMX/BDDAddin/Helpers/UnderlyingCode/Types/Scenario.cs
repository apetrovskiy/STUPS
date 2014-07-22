/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 3:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Collections.Generic;
	using Tmx.Interfaces;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of Scenario.
    /// </summary>
    public class Scenario : TestScenario, IBDDScenario
    {
        public Scenario() : base()
        {
        }
        
        public Scenario(
            string testScenarioName, 
            string testScenarioId,
            string testSuiteId) : base(testScenarioName, testScenarioId, testSuiteId)
        {
        }
    }
}
