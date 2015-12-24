/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadSeWebElementTagNameCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementTagName")]
    [OutputType(typeof(string))]
    public class ReadSeWebElementTagNameCommand : WebElementCmdletBase
    {
        public ReadSeWebElementTagNameCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
            
            var command =
                new SeReadWebElementTagNameCommand(this);
            command.Execute();
            //SeHelper.GetWebElementTagName(this, ((IWebElement[])this.InputObject));
        }
    }
}
