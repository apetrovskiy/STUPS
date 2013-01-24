/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 6:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    
    /// <summary>
    /// Description of NewSePageObjectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SePageObject")]
    //public class NewSePageObjectCommand : HasWebDriverInputCmdletBase
    internal class NewSePageObjectCommand : HasWebDriverInputCmdletBase
    {
        public NewSePageObjectCommand()
        {
        }
        
        
        protected override void ProcessRecord()
        {
            this.checkInputWebDriver(true);
            
            SeHelper.CreatePageObject(this, ((IWebDriver[])this.InputObject));
        }
    }
}
