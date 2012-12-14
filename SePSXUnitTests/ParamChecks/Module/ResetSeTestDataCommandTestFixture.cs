/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ResetSeTestDataCommand.
    /// </summary>
    public class ResetSeTestDataCommandTestFixture // CommonCmdletBase
    {
        public ResetSeTestDataCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            CurrentData.ResetData();
            WriteObject(this, true);
        }
    }
}
