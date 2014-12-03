/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:02 p.m.
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
    /// Description of ITestScenario.
    /// </summary>
    public interface ITestScenario
    {
        [XmlAttribute]
        Guid UniqueId { get; set; }
//        [XmlIgnore]
//        int DbId { get; set; }
        // 20140725
        // string Name { get; }
        // string Id { get; }
        [XmlAttribute]
        string Name { get; set; }
        [XmlAttribute]
        string Id { get; set; }
        // [XmlInclude(typeof(List<ITestResult>))]
        [XmlElement("TestResults", typeof(ITestResult))]
        List<ITestResult> TestResults { get; }
        [XmlAttribute]
        string Description { get; set; }
        [XmlAttribute]
        string Status { get; }
        
        // 20141102
        // string SuiteId { get; }
        [XmlIgnore]
        string SuiteId { get; set; }
        // 20141122
        [XmlIgnore]
        Guid SuiteUniqueId { get; set; }
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
        // 20141119
        string PlatformId { get; set; }
        [XmlAttribute]
        Guid PlatformUniqueId { get; set; }
        
        // 20130615
        [XmlIgnore]
        ScriptBlock[] BeforeTest { get; set; }
        [XmlIgnore]
        ScriptBlock[] AfterTest { get; set; }
        //ScriptBlock[] AlternateBeforeScenario { get; set; }
        //ScriptBlock[] AlternateAfterScenario { get; set; }
        [XmlIgnore]
        object[] BeforeTestParameters { get; set; }
        [XmlIgnore]
        object[] AfterTestParameters { get; set; }
        [XmlIgnore]
        List<ITestCase> TestCases { get; set; }
        
        // 20140720
        [XmlAttribute]
        double TimeSpent { get; set; }
        void SetTimeSpent(double timeSpent);
        [XmlIgnore]
        TestStat Statistics { get; set; }
        [XmlAttribute]
        TestScenarioStatuses enStatus { get; set; }
        
        // 20141203
        int GetAll();
        int GetPassed();
        int GetFailed();
        int GetPassedButWithBadSmell();
        int GetNotTested();
    }
}
