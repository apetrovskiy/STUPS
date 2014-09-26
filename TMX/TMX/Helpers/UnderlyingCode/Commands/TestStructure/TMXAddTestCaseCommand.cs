/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
	using Tmx.Interfaces;
	using Tmx;
    
    /// <summary>
    /// Description of TmxAddTestCaseCommand.
    /// </summary>
    class TmxAddTestCaseCommand : TmxCommand
    {
        internal TmxAddTestCaseCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (AddTestCaseCmdletBase)Cmdlet;
            
            // 20140721
            var dataObject = new AddTestCaseCmdletBaseDataObject {
                Id = cmdlet.Id,
                Name = cmdlet.Name,
                TestCode = cmdlet.TestCode,
                TestPlatformId = cmdlet.TestPlatformId
            };
            
            // bool result = TmxHelper.AddTestCase(cmdlet);
            bool result = TmxHelper.AddTestCase(dataObject);
            
            if (result)
                cmdlet.WriteObject(
                    cmdlet,
                    TestData.CurrentTestCase);
            else
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't add a test case",
                    "AddingTestCase",
                    ErrorCategory.InvalidArgument,
                    true);
        }
    }
}
