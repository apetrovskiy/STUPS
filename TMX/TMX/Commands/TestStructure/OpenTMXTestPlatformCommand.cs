/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/2/2013
 * Time: 3:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of OpenTmxTestPlatformCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TmxTestPlatform")]
    public class OpenTmxTestPlatformCommand : PlatformCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            // temporary
            var platform = TmxHelper.GetTestPlatformById(Id);
            TestData.CurrentTestPlatform = platform;
            WriteObject(this, platform);
        }
    }
}
