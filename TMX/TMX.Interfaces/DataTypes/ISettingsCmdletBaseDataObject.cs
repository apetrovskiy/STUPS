/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 9:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ISettingsCmdletBaseDataObject.
    /// </summary>
    public interface ISettingsCmdletBaseDataObject : ICommonDataObject
    {
        string Path { get; set; }
        string[] VariableName { get; set; }
        SessionState SessionState { get; set; }
    }
}
