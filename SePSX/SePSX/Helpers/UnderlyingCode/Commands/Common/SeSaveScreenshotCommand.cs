/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 8:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeSaveScreenshotCommand.
    /// </summary>
    internal class SeSaveScreenshotCommand : SeCommand
    {
        internal SeSaveScreenshotCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            //SeHelper.GetScreenshotOfWebElement(
//            SeHelper.GetScreenshotOfCmdletInput(
//                this,
//                this.Description,
//                save,
//                Left,
//                Top,
//                Height,
//                Width,
//                this.Path + @"\" + this.Name,
//                this.As);

            var save = Cmdlet.GetType().Name == "SaveSeScreenshotCommand";

            SeHelper.GetScreenshotOfCmdletInput(
                Cmdlet,
                ((SaveSeScreenshotCommand)Cmdlet).Description,
                save,
                // 20140111
                // ((SaveSeScreenshotCommand)this.Cmdlet).Left,
                // ((SaveSeScreenshotCommand)this.Cmdlet).Top,
                // ((SaveSeScreenshotCommand)this.Cmdlet).Height,
                // ((SaveSeScreenshotCommand)this.Cmdlet).Width,
                new UIAutomation.ScreenshotRect() {
                    Left = ((SaveSeScreenshotCommand)Cmdlet).Left,
                    Top = ((SaveSeScreenshotCommand)Cmdlet).Top,
                    Height = ((SaveSeScreenshotCommand)Cmdlet).Height,
                    Width = ((SaveSeScreenshotCommand)Cmdlet).Width
                },
                ((SaveSeScreenshotCommand)Cmdlet).Path + @"\" + ((SaveSeScreenshotCommand)Cmdlet).Name,
                ((SaveSeScreenshotCommand)Cmdlet).As);
            
            //Tmx.
            //} else {
            // UiaHelper.GetControlScreenshot(this.InputObject, this.Description);
            //}
        }
    }
}
