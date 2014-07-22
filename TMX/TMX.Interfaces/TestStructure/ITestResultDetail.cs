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

    /// <summary>
    /// Description of ITestResultDetail.
    /// </summary>
    public interface ITestResultDetail
    {
        System.DateTime Timestamp { get; }
        string Name { get; }
        void AddTestResultDetail(TestResultDetailTypes detailType, string detail);
        void AddTestResultDetail(TestResultDetailTypes detailType, ErrorRecord detail);
        object GetDetail();
        
        // 20130402
        TestResultStatuses DetailStatus { get; set; }
        
        // 20140720
        TestResultDetailTypes DetailType { get; set; }
        string TextDetail { get; set; }
        ErrorRecord ErrorDetail { get; set; }
        string ScreenshotDetail { get; set; }
        string LogDetail { get; set; }
        List<string> ExternalData { get; set; }
    }
}
