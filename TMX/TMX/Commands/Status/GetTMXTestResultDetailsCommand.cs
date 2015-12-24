/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2013
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxTestResultDetailsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestResultDetails")]
    public class GetTmxTestResultDetailsCommand : TestResultStatusCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new TmxGetTestResultDetailsCommand(this);
            command.Execute();
        }
    }
}
