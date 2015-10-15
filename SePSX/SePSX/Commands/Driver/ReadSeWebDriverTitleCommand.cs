/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadSeWebDriverTitleCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebDriverTitle")]
    [OutputType(typeof(string))]
    public class ReadSeWebDriverTitleCommand : HasWebDriverInputCmdletBase
    {
        public ReadSeWebDriverTitleCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            var command =
                new SeReadWebDriverTitleCommand(this);
            command.Execute();
            //SeHelper.GetTitle(this, this.InputObject);
        }
    }
}
