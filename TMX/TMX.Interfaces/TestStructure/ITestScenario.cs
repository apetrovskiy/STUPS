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
    using System.Xml.Serialization;
    using Remoting;
// using System.Management.Automation;

    /// <summary>
    /// Description of ITestScenario.
    /// </summary>
    public interface ITestScenario
    {
        [XmlAttribute]
        Guid UniqueId { get; set; }
        [XmlAttribute]
        string Name { get; set; }
        [XmlAttribute]
        string Id { get; set; }
        [XmlElement("TestResults", typeof(ITestResult))]
        List<ITestResult> TestResults { get; }
        [XmlAttribute]
        string Description { get; set; }
        [XmlAttribute]
        string Status { get; }
        
        [XmlIgnore]
        string SuiteId { get; set; }
        [XmlIgnore]
        Guid SuiteUniqueId { get; set; }
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
        // ScriptBlock[] BeforeTest { get; set; }
        ICodeBlock[] BeforeTest { get; set; }
        [XmlIgnore]
        // 20141211
        // ScriptBlock[] AfterTest { get; set; }
        ICodeBlock[] AfterTest { get; set; }
        //ScriptBlock[] AlternateBeforeScenario { get; set; }
        //ScriptBlock[] AlternateAfterScenario { get; set; }
        [XmlIgnore]
        object[] BeforeTestParameters { get; set; }
        [XmlIgnore]
        object[] AfterTestParameters { get; set; }
        [XmlIgnore]
        List<ITestCase> TestCases { get; set; }
        
        [XmlAttribute]
        double TimeSpent { get; set; }
        void SetTimeSpent(double timeSpent);
        [XmlIgnore]
        TestStat Statistics { get; set; }
        [XmlAttribute]
        // 20150805
        // TestScenarioStatuses enStatus { get; set; }
        TestStatuses enStatus { get; set; }
        
        int GetAll();
        int GetPassed();
        int GetFailed();
        int GetPassedButWithBadSmell();
        int GetNotTested();
    }
}
