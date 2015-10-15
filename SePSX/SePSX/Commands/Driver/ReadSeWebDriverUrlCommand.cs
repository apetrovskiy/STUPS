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
    /// Description of ReadSeWebDriverUrlCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebDriverUrl")]
    [OutputType(typeof(string))]
    public class ReadSeWebDriverUrlCommand : HasWebDriverInputCmdletBase
    {
        public ReadSeWebDriverUrlCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            var command =
                new SeReadWebDriverUrlCommand(this);
            command.Execute();
            //SeHelper.GetUrl(this, this.InputObject);
        }
    }
}
