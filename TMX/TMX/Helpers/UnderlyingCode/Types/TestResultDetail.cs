/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.ComponentModel;
    //using System.Linq;
    
    /// <summary>
    /// Description of TestResultDetail.
    /// </summary>
    [DefaultProperty("Name")]
    public class TestResultDetail : ITestResultDetail
    {
        public TestResultDetail()
        {
            this.Timestamp = System.DateTime.Now;
            this.DetailType = TestResultDetailTypes.Comment;
            // 20121218
            this.ExternalData =
                new List<string>();
        }
        
        public System.DateTime Timestamp { get; internal set; }
        internal TestResultDetailTypes DetailType { get; set; }
        internal string TextDetail { get; set; }
        internal ErrorRecord ErrorDetail { get; set; }
        internal string ScreenshotDetail { get; set; }
        // 20121218
        internal string LogDetail { get; set; }
        // 20121218
        internal List<string> ExternalData { get; set; }
        
        public string Name
        {
            get {
                if (this.TextDetail != null && this.TextDetail.Length > 0) {
                    return this.TextDetail;
                } else if (this.ErrorDetail != null) {
                    return this.ErrorDetail.Exception.Message;
                } else if (this.ScreenshotDetail != null && this.ScreenshotDetail.Length > 0) {
                    return this.ScreenshotDetail;
                } else {
                    return string.Empty;
                }
            }
        }
        public void AddTestResultDetail(
           TestResultDetailTypes detailType,
           string detail)
        {
            if (TMXHelper.TestCaseStarted == System.DateTime.MinValue) {
                TMXHelper.TestCaseStarted = System.DateTime.Now;
            }
            this.DetailType = detailType;

            switch (detailType) {
                case TestResultDetailTypes.Screenshot:
                    this.ScreenshotDetail = detail;
                    break;
//                case TestResultDetailTypes.ErrorRecord:
//                    
//                    break;
                case TestResultDetailTypes.Comment:
                    this.TextDetail = detail;
                    break;
                case TestResultDetailTypes.Log:
                    this.LogDetail = detail;
                    break;
                case TestResultDetailTypes.ExternalData:
                    this.ExternalData.Add(detail);
                    break;
                default:
                    throw new Exception("Invalid value for TestResultDetailTypes");
            }
        }
        public void AddTestResultDetail(
           TestResultDetailTypes detailType,
           ErrorRecord detail)
        {
            if (TMXHelper.TestCaseStarted == System.DateTime.MinValue) {
                TMXHelper.TestCaseStarted = System.DateTime.Now;
            }
            this.DetailType = detailType;
            if (detailType == TestResultDetailTypes.ErrorRecord) {
                this.ErrorDetail = detail;
            }
        }
        public object GetDetail()
        {
            if (null != this.ErrorDetail) {
                return this.ErrorDetail;
            }
            if (null != this.ScreenshotDetail) {
                return this.ScreenshotDetail;
            }
            if (null != this.TextDetail) {
                return this.TextDetail;
            }
            return null;
        }
    }
}
