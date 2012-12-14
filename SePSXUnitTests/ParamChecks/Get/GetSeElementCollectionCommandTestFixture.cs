/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/19/2012
 * Time: 12:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of GetSeElementCollectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeElementCollection", DefaultParameterSetName = "Name")]
    [OutputType(typeof(IWebElement[]))]
    public class GetSeElementCollectionCommandTestFixture // GetCmdletBase
    {
        public GetSeElementCollectionCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputDriver();
            
            IList<IWebElement> result = null;
            string errorReport = string.Empty;
            try {
                if (this.Id != null && this.Id != string.Empty && this.Id.Length > 0) {
                    errorReport = "Id = \"" + this.Id + "\"";
                    result = this.InputObject.FindElements(By.Id(this.Id));
                }
                
                if (this.ClassName != null && this.ClassName != string.Empty && this.ClassName.Length > 0) {
                    errorReport = "ClassName = \"" + this.ClassName + "\"";
                    result = this.InputObject.FindElements(By.ClassName(this.ClassName));
                }
                
                if (this.TagName != null && this.TagName != string.Empty && this.TagName.Length > 0) {
                    errorReport = "TagName = \"" + this.TagName + "\"";
                    result = this.InputObject.FindElements(By.TagName(this.TagName));
                }
                
                if (this.Name != null && this.Name != string.Empty && this.Name.Length > 0) {
                    errorReport = "Name = \"" + this.Name + "\"";
                    result = this.InputObject.FindElements(By.Name(this.Name));
                }
                
                if (this.LinkText != null && this.LinkText != string.Empty && this.LinkText.Length > 0) {
                    errorReport = "LinkText = \"" + this.LinkText + "\"";
                    result = this.InputObject.FindElements(By.LinkText(this.LinkText));
                }
                
                if (this.PartialLinkText != null && this.PartialLinkText != string.Empty && this.PartialLinkText.Length > 0) {
                    errorReport = "PartialLinkText = \"" + this.PartialLinkText + "\"";
                    result = this.InputObject.FindElements(By.PartialLinkText(this.PartialLinkText));
                }
                
                if (this.CSS != null && this.CSS != string.Empty && this.CSS.Length > 0) {
                    errorReport = "CSS = \"" + this.CSS + "\"";
                    result = this.InputObject.FindElements(By.CssSelector(this.CSS));
                }
                
                if (this.XPath != null && this.XPath != string.Empty && this.XPath.Length > 0) {
                    errorReport = "XPath = \"" + this.XPath + "\"";
                    result = this.InputObject.FindElements(By.XPath(this.XPath));
                }
                
                WriteObject(result);
            }
            catch {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception(
                            "Could not find an element by its " +
                            errorReport),
                        "",
                        ErrorCategory.InvalidArgument,
                        null);
                err.ErrorDetails = 
                    new ErrorDetails(
                       "Could not find an element by its " +
                       errorReport);
                ThrowTerminatingError(err);
            }
        }
    }
}
