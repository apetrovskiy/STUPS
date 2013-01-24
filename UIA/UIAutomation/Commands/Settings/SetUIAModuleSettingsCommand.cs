/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/21/2012
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetUIAModuleSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAModuleSettings")]
    //public class SetUIAModuleSettingsCommand
    internal class SetUIAModuleSettingsCommand : CommonCmdletBase
    {
        public SetUIAModuleSettingsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            
        }
    }
}
