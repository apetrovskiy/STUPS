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
    /// Description of ReadSeWebElementSizeCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementSize")]
    [OutputType(typeof(object))]
    public class ReadSeWebElementSizeCommand : WebElementCmdletBase
    {
        public ReadSeWebElementSizeCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
            
            var command =
                new SeReadWebElementSizeCommand(this);
            command.Execute();
            //SeHelper.GetWebElementSize(this, ((IWebElement[])this.InputObject));
         }
    }
}
