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
    using System.Management.Automation;
    using System.Xml.Serialization;
    
    /// <summary>
    /// Description of ITestResult.
    /// </summary>
    public interface ITestResult
    {
        [XmlAttribute]
        Guid UniqueId { get; set; }
        [XmlIgnore]
        int DbId { get; set; }
        [XmlAttribute]
        string Name { get; set; }
        [XmlAttribute]
        string Id { get; set; }
        // [XmlInclude(typeof(List<ITestResultDetail>))]
        [XmlElement("TestResultDetails", typeof(ITestResultDetail))]
        List<ITestResultDetail> Details { get; }
        // List<ITestResultDetail> Details { get; set; }
        [XmlAttribute]
        string Status { get; }
        [XmlAttribute]
        TestResultStatuses enStatus { get; set; }
        
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
        ErrorRecord Error { get; }
        void SetError(ErrorRecord error);
        [XmlAttribute]
        string Code { get; set; }
        
        [XmlAttribute]
        string Description { get; set; }
        [XmlIgnore]
        List<object> Parameters { get; }
        
        // 20141102
        // string ScenarioId { get; }
        [XmlIgnore]
        string ScenarioId { get; set; }
        // string SuiteId { get; }
        [XmlIgnore]
        string SuiteId { get; set; }
        
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
        
        // 20141022
        [XmlAttribute]
        TestResultOrigins Origin { get; }
        void SetOrigin(TestResultOrigins origin);
        // TestResultOrigins Origin { get; set; }
        
        object[] ListDetailNames(TestResultStatuses status);
        
        //List<string> PlatformIds { get; set; }
        [XmlAttribute]
        // 20141119
        string PlatformId { get; set; }
        [XmlAttribute]
        Guid PlatformUniqueId { get; set; }
    }
}
