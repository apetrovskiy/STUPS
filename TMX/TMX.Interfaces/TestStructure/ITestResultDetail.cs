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
        // 20160116
        // void AddTestResultDetail(TestResultDetailTypes detailType, ErrorRecord detail);
        void AddTestResultDetail(TestResultDetailTypes detailType, Exception detail);
        object GetDetail();
        
        [XmlAttribute]
        TestStatuses DetailStatus { get; set; }
        
        [XmlAttribute]
        TestResultDetailTypes DetailType { get; set; }
        [XmlAttribute]
        string TextDetail { get; set; }
        [XmlIgnore]
        // 20160116
        // ErrorRecord ErrorDetail { get; set; }
        Exception ErrorDetail { get; set; }
        [XmlAttribute]
        string ScreenshotDetail { get; set; }
        [XmlAttribute]
        string LogDetail { get; set; }
        [XmlIgnore]
        List<string> ExternalData { get; set; }
    }
}
