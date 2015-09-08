/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 10:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SettingsCmdletBase.
    /// </summary>
    public class SettingsCmdletBase : CommonCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string Path { get; set; }
        
        [Parameter(Mandatory = false)]
        public string[] VariableName { get; set; }
        #endregion Parameters
        
        protected void CheckInputFile(string path)
        {
            if (!System.IO.File.Exists(path)) {
                WriteError(
                    this,
                    "Couldn't find file '" + 
                    path + 
                    ".",
                    "NoFileFound",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
