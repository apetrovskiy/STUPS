/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    
    /// <summary>
    /// Description of NewSeInternetExplorerOptionsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SeInternetExplorerOptions")]
    [OutputType(typeof(OpenQA.Selenium.IE.InternetExplorerOptions))]
    public class NewSeInternetExplorerOptionsCommandTestFixture // IEOptionsCmdletBase
    {
        public NewSeInternetExplorerOptionsCommandTestFixture()
        {
        }
        
        protected override void BeginProcessing()
        {
            SeNewChromeOptionsCommand command =
                new SeNewChromeOptionsCommand(this);
            command.Execute();
        }
    }
}
