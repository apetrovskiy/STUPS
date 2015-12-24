/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.01.2012
 * Time: 11:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Drawing.Imaging;

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of SaveUiaScreenshotCommand.
    /// </summary>
    //[Cmdlet(VerbsData.Save, "UiaScreenshot")]
    public class ScreenshotCmdletBase : GetControlCmdletBase //HasControlInputCmdletBase
    {
        #region Constructor
        public ScreenshotCmdletBase()
        {
            // 20130702
            //this.Path = string.Empty;
            As = ImageFormat.Bmp;
        }
        #endregion Constructor
        
        #region Parameters
        //[UiaParameterNotUsed][Parameter(Mandatory = false,
        //           Position = 0,
        //           ParameterSetName = "Screenshot")]
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "NoFile")]
        // 20130702
        [Parameter(Mandatory = false,
                   ParameterSetName = "File")]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        [UiaParameter][Parameter(Mandatory = false)] //,
        //           ParameterSetName = "Screenshot")]
        public int Left {get; set; }
        [UiaParameter][Parameter(Mandatory = false)] //,
        //           ParameterSetName = "Screenshot")]
        public int Top {get; set; }
        [UiaParameter][Parameter(Mandatory = false)] //,
        //           ParameterSetName = "Screenshot")]
        public int Height {get; set; }
        [UiaParameter][Parameter(Mandatory = false)] //,
         //          ParameterSetName = "Screenshot")]
        public int Width {get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "File")]
        public string Path { get; set; }
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "File")]
        public new string Name { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public ImageFormat As { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            //if (this.InputObject == null ||
            // !(this.InputObject is AutomationElement)) {
            bool save = GetType().Name == "SaveUiaScreenshotCommand";
            /*
            bool save = false;
            if (this.GetType().Name == "SaveUiaScreenshotCommand") {
                save = true;
            }
            */

            UiaHelper.GetScreenshotOfCmdletInput(
                this,
                Description,
                save,
                new ScreenshotRect {
                    Left = Left,
                    Top = Top,
                    Height = Height,
                    Width = Width
                },
                Path + @"\" + Name,
                As);
        }
    }
    
    /// <summary>
    /// Description of SaveUiaScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsData.Save, "UiaScreenshot", DefaultParameterSetName = "NoFile")] //"Screenshot")]
    
    public class SaveUiaScreenshotCommand : ScreenshotCmdletBase
    {
        #region Constructor
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of GetUiaScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaScreenshot", DefaultParameterSetName = "Screenshot")]
    
    public class GetUiaScreenshotCommand : ScreenshotCmdletBase
    {
        #region Constructor
        public GetUiaScreenshotCommand()
        {
            Path = string.Empty; // ?
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        internal new string Path { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        #endregion Parameters
    }
}
