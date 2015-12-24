/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadSeWebElementCssValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebElementCssValue")]
    [OutputType(typeof(string))]
    public class ReadSeWebElementCssValueCommand : WebElementCmdletBase
    {
        public ReadSeWebElementCssValueCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string PropertyName { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
            
            var command =
                new SeReadWebElementCssValueCommand(this);
            command.Execute();
//            SeHelper.GetWebElementCSSValue(
//                this,
//                ((IWebElement[])this.InputObject),
//                this.PropertyName);
        }
    }
}
