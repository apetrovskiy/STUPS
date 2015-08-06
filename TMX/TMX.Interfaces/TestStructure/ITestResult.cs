/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:01 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.TestStructure
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Description of ITestResult.
    /// </summary>
    public interface ITestResult
    {
        [XmlAttribute]
        Guid UniqueId { get; set; }
        [XmlAttribute]
        string Name { get; set; }
        // 20150521
        string MessageOnSuccess { get; set; }
        string MessageOnFail { get; set; }
        [XmlAttribute]
        string Id { get; set; }
        [XmlElement("TestResultDetails", typeof(ITestResultDetail))]
        List<ITestResultDetail> Details { get; }
        [XmlAttribute]
        string Status { get; }
        [XmlAttribute]
        // 20150805
        // TestResultStatuses enStatus { get; set; }
        TestStatuses enStatus { get; set; }
        
        [XmlAttribute]
        string ScriptName { get; }
        void SetScriptName(string scriptName);
        [XmlAttribute]
        int LineNumber { get; }
        void SetLineNumber(int lineNumber);
        [XmlAttribute]
        int Position { get; }
        void SetPosition(int position);
        [XmlIgnore]
        // 20150116
        // ErrorRecord Error { get; }
        // void SetError(ErrorRecord error);
        Exception Error { get; }
        void SetError(Exception error);
        [XmlAttribute]
        string Code { get; set; }
        
        [XmlAttribute]
        string Description { get; set; }
        [XmlIgnore]
        List<object> Parameters { get; }
        
        [XmlIgnore]
        string ScenarioId { get; set; }
        [XmlIgnore]
        string SuiteId { get; set; }
        [XmlIgnore]
        Guid SuiteUniqueId { get; set; }
        [XmlIgnore]
        Guid ScenarioUniqueId { get; set; }
        
        [XmlAttribute]
        double TimeSpent { get; }
        void SetTimeSpent(double timeSpent);
        
        [XmlAttribute]
        DateTime Timestamp { get; }
        void SetNow();
        
        [XmlAttribute]
        bool Generated { get; }
        void SetGenerated();
        
        [XmlAttribute]
        string Screenshot { get; }
        void SetScreenshot(string path);
        
        [XmlAttribute]
        TestResultOrigins Origin { get; }
        void SetOrigin(TestResultOrigins origin);
        
        // 20150805
        // object[] ListDetailNames(TestResultStatuses status);
        object[] ListDetailNames(TestStatuses status);
        
        [XmlAttribute]
        string PlatformId { get; set; }
        [XmlAttribute]
        Guid PlatformUniqueId { get; set; }
    }
}
