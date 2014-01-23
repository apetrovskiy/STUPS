/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2014
 * Time: 6:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExtractCmdletBase.
    /// </summary>
    public class ExtractCmdletBase : ArchivingCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipeline = true)]
        public string[] ArchiveName { get; set; }
        
        [Parameter(Mandatory = true)]
        public string TargetFolder { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Overwrite { get; set; }
        #endregion Parameters
    }
}
