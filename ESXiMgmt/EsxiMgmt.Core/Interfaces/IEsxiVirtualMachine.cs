/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 5:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.Interfaces
{
    /// <summary>
    /// Description of IEsxiVirtualMachine.
    /// </summary>
    public interface IEsxiVirtualMachine
    {
        int Id { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        string GuestOperatingSystem { get; set; }
        string Version { get; set; }
        string Annotation { get; set; }
        string Server { get; set; }
    }
}
