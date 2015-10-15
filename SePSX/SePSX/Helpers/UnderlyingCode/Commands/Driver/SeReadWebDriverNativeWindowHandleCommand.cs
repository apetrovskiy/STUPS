/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeReadWebDriverNativeWindowHandleCommand.
    /// </summary>
    internal class SeReadWebDriverNativeWindowHandleCommand : SeWebDriverCommand
    {
        internal SeReadWebDriverNativeWindowHandleCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetNativeWindowHandle(
//                ((SeReadWebDriverNativeWindowHandleCommand)this.Cmdlet),
//                ((SeReadWebDriverNativeWindowHandleCommand)this.Cmdlet).InputObject, 
//                ((SeReadWebDriverNativeWindowHandleCommand)this.Cmdlet).MainWindowHandle);
            SeHelper.GetNativeWindowHandle(
                Cmdlet,
                ((HasWebDriverInputCmdletBase)Cmdlet).InputObject,
                ((ReadSeWebDriverNativeWindowHandleCommand)Cmdlet).MainWindowHandle);
        }
    }
}
