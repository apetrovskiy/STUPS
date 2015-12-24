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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetUiaModuleSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaModuleSettings")]
    //public class SetUiaModuleSettingsCommand
    internal class SetUiaModuleSettingsCommand : CommonCmdletBase
    {
        public SetUiaModuleSettingsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            
        }
    }
}
