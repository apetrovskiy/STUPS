/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2012
 * Time: 11:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddScenarioCmdletBase.
    /// </summary>
    public class AddScenarioCmdletBase : ScenarioCmdletBase
    {
        public AddScenarioCmdletBase()
        {
        }
        
        #region Parameters
        // 20130528
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public new string Name { get; set; }
        
        // 20130419
        // 20130528
        [Parameter(Mandatory = false)]
        //[Parameter(Mandatory = false,
        //           Position = 0)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        #endregion Parameters
    }
}
