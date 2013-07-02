/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/2/2013
 * Time: 3:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of OpenTMXTestPlatformCommand.
    /// </summary>
    public class OpenTMXTestPlatformCommand : PlatformCmdletBase
    {
        public OpenTMXTestPlatformCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            // temporary
            ITestPlatform platform =
                TMXHelper.GetTestPlatformById(this.Id);
            this.WriteObject(this, platform);
        }
    }
}
