/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/9/2012
 * Time: 9:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SaveTMXTestScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsData.Save, "TMXTestScreenshot")]
    [OutputType(typeof(bool))]
    public class SaveTMXTestScreenshotCommand : CommonCmdletBase
    {
        public SaveTMXTestScreenshotCommand()
        {
        }
    }
}
