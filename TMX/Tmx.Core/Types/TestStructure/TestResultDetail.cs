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
            this.Timestamp = DateTime.Now;
            this.DetailType = TestResultDetailTypes.Comment;
            this.ExternalData = new List<string>();
        }
        
        public virtual int DbId { get; protected set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual TestResultDetailTypes DetailType { get; set; }
        public virtual string TextDetail { get; set; }
        public virtual ErrorRecord ErrorDetail { get; set; }
        public virtual string ScreenshotDetail { get; set; }
        public virtual string LogDetail { get; set; }
        public virtual List<string> ExternalData { get; set; }
        
        public virtual string Name
        {
            get {
				if (!string.IsNullOrEmpty(TextDetail))
					return TextDetail;
				if (ErrorDetail != null)
					return ErrorDetail.Exception.Message;
				return !string.IsNullOrEmpty(ScreenshotDetail) ? ScreenshotDetail : string.Empty;
			}
        }
        public virtual void AddTestResultDetail(
           TestResultDetailTypes detailType,
           string detail)
        {
            if (TmxHelper.TestCaseStarted == DateTime.MinValue) {
                TmxHelper.TestCaseStarted = DateTime.Now;
            }
			DetailType = detailType;

            switch (detailType) {
                case TestResultDetailTypes.Screenshot:
					ScreenshotDetail = detail;
                    break;
//                case TestResultDetailTypes.ErrorRecord:
//                    
//                    break;
                case TestResultDetailTypes.Comment:
					TextDetail = detail;
                    break;
                case TestResultDetailTypes.Log:
					LogDetail = detail;
                    break;
                case TestResultDetailTypes.ExternalData:
					ExternalData.Add(detail);
                    break;
                default:
                    throw new Exception("Invalid value for TestResultDetailTypes");
            }
        }
        public virtual void AddTestResultDetail(
           TestResultDetailTypes detailType,
           ErrorRecord detail)
        {
			if (TmxHelper.TestCaseStarted == DateTime.MinValue)
				TmxHelper.TestCaseStarted = DateTime.Now;
			DetailType = detailType;
			if (detailType == TestResultDetailTypes.ErrorRecord)
				ErrorDetail = detail;
        }
        public virtual object GetDetail()
        {
			return null != ErrorDetail ? ErrorDetail.Exception.Message : ScreenshotDetail ?? TextDetail ?? null;
        }
        
        public virtual TestResultStatuses DetailStatus { get; set; }
    }
}
