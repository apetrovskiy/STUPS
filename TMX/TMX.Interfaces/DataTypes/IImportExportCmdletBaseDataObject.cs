/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 9:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of IImportExportCmdletBaseDataObject.
    /// </summary>
    public interface IImportExportCmdletBaseDataObject : ISearchCmdletBaseDataObject // ICommonDataObject
    {
        string As { get; set; }
        string Path { get; set; }
        SwitchParameter ExcludeAutomatic { get; set; }
    }
}
