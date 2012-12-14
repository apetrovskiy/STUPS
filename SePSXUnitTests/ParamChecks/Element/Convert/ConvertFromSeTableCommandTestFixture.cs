/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 7:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ConvertFromSeTableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "SeTable")]
    [OutputType(typeof(string[]))]
    public class ConvertFromSeTableCommandTestFixture // WebElementCmdletBase
    {
        public ConvertFromSeTableCommandTestFixture()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeConvertFromTableCommand command =
                new SeConvertFromTableCommand(this);
            command.Execute();
        }
    }
}
