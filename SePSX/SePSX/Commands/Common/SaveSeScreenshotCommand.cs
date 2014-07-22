/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2012
 * Time: 8:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using System.Runtime.InteropServices;
    using System.Windows.Automation;
    
    using UIAutomation;
    
    /// <summary>
    /// Description of SaveSeScreenshotCommand.
    /// </summary>
    public class ScreenshotCmdletBase : HasWebElementInputCmdletBase
    {
        #region Constructor
        public ScreenshotCmdletBase()
        {
            this.Path = string.Empty;
            this.As = System.Drawing.Imaging.ImageFormat.Bmp;
        }
        #endregion Constructor
        
        #region Parameters
        //[Parameter(Mandatory = false,
        //           Position = 0,
        //           ParameterSetName = "Screenshot")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "NoFile")]
        [AllowNull()]
        [AllowEmptyString()]
        public string Description { get; set; }
        
        [Parameter(Mandatory = false)] //,
        //           ParameterSetName = "Screenshot")]
        public int Left {get; set; }
        [Parameter(Mandatory = false)] //,
        //           ParameterSetName = "Screenshot")]
        public int Top {get; set; }
        [Parameter(Mandatory = false)] //,
        //           ParameterSetName = "Screenshot")]
        public int Height {get; set; }
        [Parameter(Mandatory = false)] //,
         //          ParameterSetName = "Screenshot")]
        public int Width {get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "File")]
        public string Path { get; set; }
        [Parameter(Mandatory = false,
                   ParameterSetName = "File")]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        public System.Drawing.Imaging.ImageFormat As { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            //if (this.InputObject == null ||
            // !(this.InputObject is AutomationElement)) {
//            bool save = false;
//            if (this.GetType().Name == "SaveSeScreenshotCommand") {
//                save = true;
//            }
            
//            //SeHelper.GetScreenshotOfWebElement(
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
//            
//            //Tmx.
//            //} else {
//            // UiaHelper.GetControlScreenshot(this.InputObject, this.Description);
//            //}
            SeSaveScreenshotCommand command =
                new SeSaveScreenshotCommand(this);
            command.Execute();
        }
    }
    
    
    /// <summary>
    /// Description of SaveSeScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsData.Save, "SeScreenshot", DefaultParameterSetName = "NoFile")] //"Screenshot")]
    //
    public class SaveSeScreenshotCommand : ScreenshotCmdletBase
    {
        #region Constructor
        public SaveSeScreenshotCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of GetSeScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeScreenshot", DefaultParameterSetName = "Screenshot")]
    //
    public class GetSeScreenshotCommand : ScreenshotCmdletBase
    {
        #region Constructor
        public GetSeScreenshotCommand()
        {
            this.Path = string.Empty; // ?
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Path { get; set; }
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        #endregion Parameters
    }
}
