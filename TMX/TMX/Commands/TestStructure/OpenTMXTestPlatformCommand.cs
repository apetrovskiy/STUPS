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
	using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of OpenTmxTestPlatformCommand.
    /// </summary>
    public class OpenTmxTestPlatformCommand : PlatformCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            // temporary
            var platform =
                TmxHelper.GetTestPlatformById(this.Id);
            this.WriteObject(this, platform);
        }
    }
}
