/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.01.2012
 * Time: 11:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Runtime.InteropServices;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of SaveUIAScreenshotCommand.
    /// </summary>
    //[Cmdlet(VerbsData.Save, "UIAScreenshot")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ScreenshotCmdletBase : GetControlCmdletBase //HasControlInputCmdletBase
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
        public new string Name { get; set; }
        
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
            bool save = false;
            if (this.GetType().Name == "SaveUIAScreenshotCommand") {
                save = true;
            }
            
            //UIAHelper.GetScreenshotOfAutomationElement(
            UIAHelper.GetScreenshotOfCmdletInput(
                this,
                this.Description,
                save,
                Left,
                Top,
                Height,
                Width,
                this.Path + @"\" + this.Name,
                this.As);
            //TMX.
            //} else {
            // UIAHelper.GetControlScreenshot(this.InputObject, this.Description);
            //}
        }
    }
    
    /// <summary>
    /// Description of SaveUIAScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsData.Save, "UIAScreenshot", DefaultParameterSetName = "NoFile")] //"Screenshot")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SaveUIAScreenshotCommand : ScreenshotCmdletBase //GetControlCmdletBase //HasControlInputCmdletBase
    {
        #region Constructor
        public SaveUIAScreenshotCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of GetUIAScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAScreenshot", DefaultParameterSetName = "Screenshot")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAScreenshotCommand : ScreenshotCmdletBase //GetControlCmdletBase //HasControlInputCmdletBase
    {
        #region Constructor
        public GetUIAScreenshotCommand()
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
