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
    // using System.Management.Automation;
    using System.Xml.Serialization;

    /// <summary>
    /// Description of ITestSuite.
    /// </summary>
    public interface ITestSuite
    {
        [XmlAttribute]
        Guid UniqueId { get; set; }
        [XmlAttribute]
        string Name { get; set; }
        [XmlAttribute]
        string Id { get; set; }
        [XmlElement("TestScenarios", typeof(ITestScenario))]
        List<ITestScenario> TestScenarios { get; set; }
        [XmlAttribute]
        string Description { get; set; }
        [XmlAttribute]
        string Status { get; }
        [XmlAttribute]
        DateTime Timestamp { get; set; }
        void SetNow();
        
        [XmlIgnore]
        string Tags { get; set; }
        
        [XmlAttribute]
        string PlatformId { get; set; }
        [XmlAttribute]
        Guid PlatformUniqueId { get; set; }
        
        [XmlIgnore]
        // 20141211
        // ScriptBlock[] BeforeScenario { get; set; }
        ICodeBlock[] BeforeScenario { get; set; }
        [XmlIgnore]
        // 20141211
        // ScriptBlock[] AfterScenario { get; set; }
        ICodeBlock[] AfterScenario { get; set; }
        [XmlIgnore]
        object[] BeforeScenarioParameters { get; set; }
        [XmlIgnore]
        object[] AfterScenarioParameters { get; set; }
        
        [XmlAttribute]
        double TimeSpent { get; set; }
        void SetTimeSpent(double timeSpent);
        [XmlIgnore]
        TestStat Statistics { get; set; }
        [XmlAttribute]
        TestSuiteStatuses enStatus { get; set; }
        
        int GetAll();
        int GetPassed();
        int GetFailed();
        int GetPassedButWithBadSmell();
        int GetNotTested();
    }
}
