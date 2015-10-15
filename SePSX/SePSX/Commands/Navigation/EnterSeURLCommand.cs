/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 11:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of EnterSeURLCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Enter, "SeURL")]
    [OutputType(typeof(IWebDriver))]
    public class EnterSeUrlCommand : NavigationCmdletBase
    {
        public EnterSeUrlCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        //[ValidatePattern(@"h[t]{2}p[Ss]{0,1}[\:][\/]{2}.*|about[\:].*|ms-its[\:].*|file[\:][\/]{3}.*")]
        public string Url { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            var command =
                new SeEnterUrlCommand(this);
            command.Execute();
            //SeHelper.NavigateTo(this, this.InputObject, this.URL);
        }
    }
}
