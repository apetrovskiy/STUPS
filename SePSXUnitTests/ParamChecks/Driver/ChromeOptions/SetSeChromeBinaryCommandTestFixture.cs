/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/28/2012
 * Time: 9:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    /// <summary>
    /// Description of SetSeChromeBinaryCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "SeChromeBinary")]
    [OutputType(typeof(OpenQA.Selenium.Chrome.ChromeOptions))]
    public class SetSeChromeBinaryCommandTestFixture // EditChromeOptionsCmdletBase
    {
        public SetSeChromeBinaryCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public string BinaryPath { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            
            throw new NotImplementedException();
            
            
            // check input options
            
            // set the binary path
            
            // output the options
            
        }
    }
}
