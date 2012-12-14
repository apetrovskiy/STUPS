/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:01 PM
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
    /// Description of SetSeInternetExplorerOptionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "SeInternetExplorerOption")]
    [OutputType(typeof(OpenQA.Selenium.IE.InternetExplorerOptions))]
    public class SetSeInternetExplorerOptionCommandTestFixture // EditIEOptionsCmdletBase
    {
        public SetSeInternetExplorerOptionCommandTestFixture()
        {
        }
        
        protected override void BeginProcessing()
        {
            SeSetIEOptionCommand command =
                new SeSetIEOptionCommand(this);
            command.Execute();
        }
    }
}
