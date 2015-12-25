/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 7:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ConvertFromSeTableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "SeTable")]
    [OutputType(typeof(string[]))]
    public class ConvertFromSeTableCommand : WebElementCmdletBase
    {
        public ConvertFromSeTableCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
            
            SeConvertFromTableCommand command =
                new SeConvertFromTableCommand(this);
            command.Execute();
        }
    }
}
