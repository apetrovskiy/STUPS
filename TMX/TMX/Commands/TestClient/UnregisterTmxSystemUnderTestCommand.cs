/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 6:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Tmx;
    
    /// <summary>
    /// Description of UnregisterTmxSystemUnderTestCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "TmxSystemUnderTest")]
    public class UnregisterTmxSystemUnderTestCommand : ClientCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new UnregisterSystemUnderTestCommand(this);
            command.Execute();
        }
    }
}
