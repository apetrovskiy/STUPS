/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/18/2012
 * Time: 10:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeElementCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeElement", DefaultParameterSetName = "Name")]
    [OutputType(typeof(IWebElement))]
    public class GetSeElementCommand : GetCmdletBase
    {
        public GetSeElementCommand()
        {
        }
        
        
        protected override void ProcessRecord()
        {
            this.checkInputDriver();
            
            IWebElement result = null;
            string errorReport = string.Empty;
            try {
                if (this.Id != null && this.Id != string.Empty && this.Id.Length > 0) {
                    errorReport = "Id = \"" + this.Id + "\"";
                    result = this.InputObject.FindElement(By.Id(this.Id));
                }
                
                if (this.ClassName != null && this.ClassName != string.Empty && this.ClassName.Length > 0) {
                    errorReport = "ClassName = \"" + this.ClassName + "\"";
                    result = this.InputObject.FindElement(By.ClassName(this.ClassName));
                }
                
                if (this.TagName != null && this.TagName != string.Empty && this.TagName.Length > 0) {
                    errorReport = "TagName = \"" + this.TagName + "\"";
                    result = this.InputObject.FindElement(By.TagName(this.TagName));
                }
                
                if (this.Name != null && this.Name != string.Empty && this.Name.Length > 0) {
                    errorReport = "Name = \"" + this.Name + "\"";
                    result = this.InputObject.FindElement(By.Name(this.Name));
                }
                
                if (this.LinkText != null && this.LinkText != string.Empty && this.LinkText.Length > 0) {
                    errorReport = "LinkText = \"" + this.LinkText + "\"";
                    result = this.InputObject.FindElement(By.LinkText(this.LinkText));
                }
                
                if (this.PartialLinkText != null && this.PartialLinkText != string.Empty && this.PartialLinkText.Length > 0) {
                    errorReport = "PartialLinkText = \"" + this.PartialLinkText + "\"";
                    result = this.InputObject.FindElement(By.PartialLinkText(this.PartialLinkText));
                }
                
                if (this.CSS != null && this.CSS != string.Empty && this.CSS.Length > 0) {
                    errorReport = "CSS = \"" + this.CSS + "\"";
                    result = this.InputObject.FindElement(By.CssSelector(this.CSS));
                }
                
                if (this.XPath != null && this.XPath != string.Empty && this.XPath.Length > 0) {
                    errorReport = "XPath = \"" + this.XPath + "\"";
                    result = this.InputObject.FindElement(By.XPath(this.XPath));
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
