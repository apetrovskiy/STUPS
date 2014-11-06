/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:05 p.m.
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
    /// Description of ITestResultDetail.
    /// </summary>
    public interface ITestResultDetail
    {
        [XmlAttribute]
        DateTime Timestamp { get; }
        [XmlAttribute]
        string Name { get; }
        void AddTestResultDetail(TestResultDetailTypes detailType, string detail);
        void AddTestResultDetail(TestResultDetailTypes detailType, ErrorRecord detail);
        object GetDetail();
        
        // 20130402
        [XmlAttribute]
        TestResultStatuses DetailStatus { get; set; }
        
        // 20140720
        [XmlAttribute]
        TestResultDetailTypes DetailType { get; set; }
        [XmlAttribute]
        string TextDetail { get; set; }
        [XmlIgnore]
        ErrorRecord ErrorDetail { get; set; }
        [XmlAttribute]
        string ScreenshotDetail { get; set; }
        [XmlAttribute]
        string LogDetail { get; set; }
        [XmlIgnore]
        List<string> ExternalData { get; set; }
    }
}
