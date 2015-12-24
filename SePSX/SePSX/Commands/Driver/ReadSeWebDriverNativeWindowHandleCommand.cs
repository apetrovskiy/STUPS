/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadSeWebDriverNativeWindowHandleCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "SeWebDriverNativeWindowHandle")]
    [OutputType(typeof(int))]
    public class ReadSeWebDriverNativeWindowHandleCommand : HasWebDriverInputCmdletBase
    {
        public ReadSeWebDriverNativeWindowHandleCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter MainWindowHandle { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriver(true);
            
            var command =
                new SeReadWebDriverNativeWindowHandleCommand(this);
            command.Execute();
            //SeHelper.GetNativeWindowHandle(this, this.InputObject, this.MainWindowHandle);
        }
    }
}
