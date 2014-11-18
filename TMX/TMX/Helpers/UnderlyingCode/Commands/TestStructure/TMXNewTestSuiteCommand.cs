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
            
            // var aaa = TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId);
            // var aaa = TestData.TestPlatforms.First(tp => tp.Id == cmdlet.TestPlatformId);
            
//            if (null == aaa)
//                Console.WriteLine("null == TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId)");
//            else
//                Console.WriteLine("null != TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId)");
//            if (null == aaa)
//                Console.WriteLine("null == TestData.TestPlatforms.First(tp => tp.Id == cmdlet.TestPlatformId)");
//            else
//                Console.WriteLine("null != TestData.TestPlatforms.First(tp => tp.Id == cmdlet.TestPlatformId)");
//            if (null == TestData.CurrentTestPlatform)
//                Console.WriteLine("null == TestData.CurrentTestPlatform");
//            else
//                Console.WriteLine("null != TestData.CurrentTestPlatform");
//            if (null == cmdlet.TestPlatformId)
//                Console.WriteLine("null == cmdlet.TestPlatformId");
//            else
//                Console.WriteLine("null != cmdlet.TestPlatformId");
//            if (string.IsNullOrEmpty(cmdlet.TestPlatformId))
//                Console.WriteLine("string.IsNullOrEmpty(cmdlet.TestPlatformId)");
//            else
//                Console.WriteLine("! string.IsNullOrEmpty(cmdlet.TestPlatformId)");
//            Console.WriteLine("current test platform id = {0}", TestData.CurrentTestPlatform.UniqueId);
            
            Guid testPlatformId = Guid.Empty;
            if (string.IsNullOrEmpty(cmdlet.TestPlatformId))
                if (null != TestData.CurrentTestPlatform)
                    testPlatformId = TestData.CurrentTestPlatform.UniqueId;
            
            if (!string.IsNullOrEmpty(cmdlet.TestPlatformId)) {
                if (TestData.TestPlatforms.All(tp => tp.Id != cmdlet.TestPlatformId))
                    throw new Exception("Couldn't find test platfiorm with Id = " + cmdlet.TestPlatformId);
                else
                    testPlatformId = TestData.TestPlatforms.First(tp => tp.Id == cmdlet.TestPlatformId).UniqueId;
            }
            
//            if (!string.IsNullOrEmpty(cmdlet.TestPlatformId))
//                if ((0 == TestData.TestPlatforms.Count || TestData.TestPlatforms.All(tp => tp.Id != cmdlet.TestPlatformId)) && null == TestData.CurrentTestPlatform)
//                    throw new Exception("Couldn't find test platfiorm with Id = " + cmdlet.TestPlatformId);
//                else
//                    testPlatformId = TestData.TestPlatforms.First(tp => tp.Id == cmdlet.TestPlatformId).UniqueId;
//            
//            testPlatformId = TestData.CurrentTestPlatform.UniqueId;
            
            // var res = string.IsNullOrEmpty(cmdlet.TestPlatformId) ? TestData.CurrentTestPlatform.UniqueId : (null != aaa ? aaa.UniqueId : Guid.Empty);
            // var testPlatformId = string.IsNullOrEmpty(cmdlet.TestPlatformId) ? TestData.CurrentTestPlatform.UniqueId : TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId;
//            Console.WriteLine("this is used {0}", res);
            
            bool result = 
                TmxHelper.NewTestSuite(
                    cmdlet.Name,
                    cmdlet.Id,
                    // 20141114
                    // cmdlet.TestPlatformId,
                    // TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId,
                    // (TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId) ?? TestData.CurrentTestPlatform).UniqueId,
                    // string.IsNullOrEmpty(cmdlet.TestPlatformId) ? TestData.CurrentTestPlatform.UniqueId : TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId,
                    
                    // string.IsNullOrEmpty(cmdlet.TestPlatformId) ? TestData.CurrentTestPlatform.UniqueId : (null != aaa ? aaa.UniqueId : Guid.Empty),
                    testPlatformId,
                    
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
