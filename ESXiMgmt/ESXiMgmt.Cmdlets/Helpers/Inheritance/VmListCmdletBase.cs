/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/9/2012
 * Time: 6:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of VmListCmdletBase.
    /// </summary>
    public class VmListCmdletBase : CommonCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "ById")]
        public int Id { get; set; }
        
        [Parameter(Mandatory = true, ParameterSetName = "ByName")]
        public string Name { get; set; }
        
        [Parameter(Mandatory = true, ParameterSetName = "ByPath")]
        public string Path { get; set; }
        
        [Parameter(Mandatory = true)]
        public string[] Server { get; set; }
    }
}
