/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/9/2012
 * Time: 9:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SaveTmxTestScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsData.Save, "TmxTestScreenshot")]
    [OutputType(typeof(bool))]
    public class SaveTmxTestScreenshotCommand : CommonCmdletBase
    {
    }
}
