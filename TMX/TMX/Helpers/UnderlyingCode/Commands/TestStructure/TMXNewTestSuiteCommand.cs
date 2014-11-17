/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Linq;
    using System.Management.Automation;
	using Tmx;
    
    /// <summary>
    /// Description of TmxNewTestSuiteCommand.
    /// </summary>
    class TmxNewTestSuiteCommand : TmxCommand
    {
        internal TmxNewTestSuiteCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewSuiteCmdletBase)Cmdlet;
            
            var aaa = TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId);
            
            
            bool result = 
                TmxHelper.NewTestSuite(
                    cmdlet.Name,
                    cmdlet.Id,
                    // 20141114
                    // cmdlet.TestPlatformId,
                    TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId,
                    cmdlet.Description,
                    cmdlet.BeforeScenario,
                    cmdlet.AfterScenario);
            
            if (result)
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite);
            else
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't create a test suite",
                    "CreatingTestSuite",
                    ErrorCategory.InvalidArgument,
                    true);
        }
    }
}
