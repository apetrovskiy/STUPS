/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 1:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SettingsCmdletBaseDataObject.
    /// </summary>
    public class SettingsCmdletBaseDataObject : ISettingsCmdletBaseDataObject
    {
        public string Path { get; set; }
        public string[] VariableName { get; set; }
        public SessionState SessionState { get; set; }
    }
}
