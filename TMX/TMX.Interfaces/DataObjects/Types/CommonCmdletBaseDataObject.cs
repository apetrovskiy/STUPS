/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    /// <summary>
    /// Description of CommonCmdletBaseDataObject.
    /// </summary>
    public class CommonCmdletBaseDataObject : ICommonCmdletBaseDataObject
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string TestPlatformId { get; set; }
    }
}
