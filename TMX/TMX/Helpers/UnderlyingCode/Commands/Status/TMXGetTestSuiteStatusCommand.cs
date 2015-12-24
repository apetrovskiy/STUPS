/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Linq;
    using System.Management.Automation;
    using Commands;

    /// <summary>
    /// Description of TmxGetTestSuiteStatusCommand.
    /// </summary>
    class TmxGetTestSuiteStatusCommand : TmxCommand
    {
        internal TmxGetTestSuiteStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxTestSuiteStatusCommand)Cmdlet;
            
            // 20150408
            // as no longer in use
            /*
            // 20140721
            var dataObject = new GetTmxTestSuiteStatusDataObject {
                FilterOutAutomaticResults = cmdlet.FilterOutAutomaticResults,
                Name = cmdlet.Name,
                Id = cmdlet.Id,
                TestPlatformId = cmdlet.TestPlatformId
            };
            */
            
            // 20150408
            var currentTestPlatform = TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId);
            if (null == currentTestPlatform)
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to find test suite with name = '" +
                    cmdlet.Name +
                    "' and id = '" +
                    cmdlet.Id +
                    "'",
                    "FailedToFindTestSuite",
                    ErrorCategory.InvalidArgument,
                    true);

            if (!string.IsNullOrEmpty(cmdlet.Name)) {
                // 20140721
                // 20140722
                var result = 
                    TmxHelper.GetTestSuiteStatusByName(
                        // cmdlet,
                        // dataObject,
                        cmdlet.Name,
                        // 20141114
                        // cmdlet.TestPlatformId,
                        // 20150408
                        // TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId,
                        currentTestPlatform.UniqueId,
                        cmdlet.FilterOutAutomaticResults);
                cmdlet.WriteObject(result);
            } else if (!string.IsNullOrEmpty(cmdlet.Id)) {
                // 20140721
                // 20140722
                var result2 =
                    TmxHelper.GetTestSuiteStatusById(
                        // cmdlet,
                        // dataObject,
                        cmdlet.Id,
                        // 20141114
                        // cmdlet.TestPlatformId,
                        // 20150408
                        // TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId,
                        currentTestPlatform.UniqueId,
                        cmdlet.FilterOutAutomaticResults);
                cmdlet.WriteObject(result2);
            } else {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to find test suite with name = '" +
                    cmdlet.Name +
                    "' and id = '" +
                    cmdlet.Id +
                    "'",
                    "FailedToFindTestSuite",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
