/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of ResetSeTestDataCommand.
    /// </summary>
    public class ResetSeTestDataCommand : CommonCmdletBase
    {
        public ResetSeTestDataCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CurrentData.ResetData();
            WriteObject(this, true);
        }
    }
}
