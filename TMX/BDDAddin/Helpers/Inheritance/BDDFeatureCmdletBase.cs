/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/25/2012
 * Time: 11:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of BDDFeatureCmdletBase.
    /// </summary>
    public class BDDFeatureCmdletBase : BDDCmdletBase
    {
        public BDDFeatureCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string FeatureName { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AsA { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string IWant { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SoThat { get; set; }
        #endregion Parameters
    }
}
