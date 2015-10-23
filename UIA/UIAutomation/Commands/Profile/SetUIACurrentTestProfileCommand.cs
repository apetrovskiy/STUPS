/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2012
 * Time: 8:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetUiaCurrentTestProfileCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCurrentTestProfile")]
    public class SetUiaCurrentTestProfileCommand : ProfileInputCmdletBase
    {
        public SetUiaCurrentTestProfileCommand()
        {
        }
    }
}
