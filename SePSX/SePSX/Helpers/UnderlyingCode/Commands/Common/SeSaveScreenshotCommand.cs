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
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    
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

            bool save = this.Cmdlet.GetType().Name == "SaveSeScreenshotCommand";

            SeHelper.GetScreenshotOfCmdletInput(
                this.Cmdlet,
                ((SaveSeScreenshotCommand)this.Cmdlet).Description,
                save,
                // 20140111
                // ((SaveSeScreenshotCommand)this.Cmdlet).Left,
                // ((SaveSeScreenshotCommand)this.Cmdlet).Top,
                // ((SaveSeScreenshotCommand)this.Cmdlet).Height,
                // ((SaveSeScreenshotCommand)this.Cmdlet).Width,
                new UIAutomation.ScreenshotRect() {
                    Left = ((SaveSeScreenshotCommand)this.Cmdlet).Left,
                    Top = ((SaveSeScreenshotCommand)this.Cmdlet).Top,
                    Height = ((SaveSeScreenshotCommand)this.Cmdlet).Height,
                    Width = ((SaveSeScreenshotCommand)this.Cmdlet).Width
                },
                ((SaveSeScreenshotCommand)this.Cmdlet).Path + @"\" + ((SaveSeScreenshotCommand)this.Cmdlet).Name,
                ((SaveSeScreenshotCommand)this.Cmdlet).As);
            
            //TMX.
            //} else {
            // UiaHelper.GetControlScreenshot(this.InputObject, this.Description);
            //}
        }
    }
}
