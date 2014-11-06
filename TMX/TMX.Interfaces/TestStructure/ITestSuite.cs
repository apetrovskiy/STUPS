/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:03 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.TestStructure
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Xml.Serialization;

    /// <summary>
    /// Description of ITestSuite.
    /// </summary>
    public interface ITestSuite
    {
        [XmlIgnore]
        int DbId { get; set; }
        // 20140725
        // string Name { get; }
        // string Id { get; }
        [XmlAttribute]
        string Name { get; set; }
        [XmlAttribute]
        string Id { get; set; }
        // 20140720
        // List<ITestScenario> TestScenarios { get; }
        // [XmlInclude(typeof(List<ITestScenario>))]
        // 20141106 refactoring 01
        [XmlElement("TestScenarios", typeof(ITestScenario))]
        List<ITestScenario> TestScenarios { get; set; }
        [XmlAttribute]
        string Description { get; set; }
        [XmlAttribute]
        string Status { get; }
        // 20130301
        // 20140720
        // DateTime Timestamp { get; }
        [XmlAttribute]
        DateTime Timestamp { get; set; }
        void SetNow();
        
        //List<string> Tags { get; set; }
        [XmlIgnore]
        string Tags { get; set; }
        
        //List<string> PlatformIds { get; set; }
        [XmlAttribute]
        string PlatformId { get; set; }
        
        // 20130615
        //ScriptBlock[] BeforeTest { get; set; }
        //ScriptBlock[] AfterTest { get; set; }
        [XmlIgnore]
        ScriptBlock[] BeforeScenario { get; set; }
        [XmlIgnore]
        ScriptBlock[] AfterScenario { get; set; }
        [XmlIgnore]
        object[] BeforeScenarioParameters { get; set; }
        [XmlIgnore]
        object[] AfterScenarioParameters { get; set; }
        
        // 20140720
        [XmlAttribute]
        double TimeSpent { get; set; }
        void SetTimeSpent(double timeSpent);
        [XmlIgnore]
        TestStat Statistics { get; set; }
        [XmlAttribute]
        TestSuiteStatuses enStatus { get; set; }
    }
}
