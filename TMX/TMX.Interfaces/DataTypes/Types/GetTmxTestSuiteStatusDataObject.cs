/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 11:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxTestSuiteStatusDataObject.
    /// </summary>
    public class GetTmxTestSuiteStatusDataObject : IGetTmxTestSuiteStatusDataObject
    {
        public SwitchParameter FilterOutAutomaticResults { get; set; }
        public string Name { get; set; }
        
//        public string Name { get; set; }
        public string Id { get; set; }
        public string TestPlatformId { get; set; }
    }
}
