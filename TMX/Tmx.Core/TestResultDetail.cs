/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.ComponentModel;
	using Tmx.Interfaces.TestStructure;
    
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
            this.ExternalData = new List<string>();
        }
        
        public virtual int DbId { get; protected set; }
        public virtual DateTime Timestamp { get; protected internal set; }
        // 20140720
//        protected internal virtual TestResultDetailTypes DetailType { get; set; }
//        protected internal virtual string TextDetail { get; set; }
//        protected internal virtual ErrorRecord ErrorDetail { get; set; }
//        protected internal virtual string ScreenshotDetail { get; set; }
//        protected internal virtual string LogDetail { get; set; }
//        protected internal virtual List<string> ExternalData { get; set; }
        public virtual TestResultDetailTypes DetailType { get; set; }
        public virtual string TextDetail { get; set; }
        public virtual ErrorRecord ErrorDetail { get; set; }
        public virtual string ScreenshotDetail { get; set; }
        public virtual string LogDetail { get; set; }
        public virtual List<string> ExternalData { get; set; }
        
        public virtual string Name
        {
            get {
                if (!string.IsNullOrEmpty(this.TextDetail)) {
                // if (this.TextDetail != null && this.TextDetail.Length > 0) {
                    return this.TextDetail;
                } else if (this.ErrorDetail != null) {
                    return this.ErrorDetail.Exception.Message;
                } else if (!string.IsNullOrEmpty(this.ScreenshotDetail)) {
                // } else if (this.ScreenshotDetail != null && this.ScreenshotDetail.Length > 0) {
                    return this.ScreenshotDetail;
                } else {
                    return string.Empty;
                }
            }
        }
        public virtual void AddTestResultDetail(
           TestResultDetailTypes detailType,
           string detail)
        {
            if (TmxHelper.TestCaseStarted == DateTime.MinValue) {
                TmxHelper.TestCaseStarted = DateTime.Now;
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
        public virtual void AddTestResultDetail(
           TestResultDetailTypes detailType,
           ErrorRecord detail)
        {
            if (TmxHelper.TestCaseStarted == DateTime.MinValue) {
                TmxHelper.TestCaseStarted = DateTime.Now;
            }
            this.DetailType = detailType;
            if (detailType == TestResultDetailTypes.ErrorRecord) {
                this.ErrorDetail = detail;
            }
        }
        public virtual object GetDetail()
        {
            if (null != this.ErrorDetail) {
                return this.ErrorDetail;
            }
            if (null != this.ScreenshotDetail) {
                return this.ScreenshotDetail;
            }
            return this.TextDetail ?? null;

            /*
            if (null != this.TextDetail) {
                return this.TextDetail;
            }
            return null;
            */
        }
        
        public virtual TestResultStatuses DetailStatus { get; set; }
    }
}
