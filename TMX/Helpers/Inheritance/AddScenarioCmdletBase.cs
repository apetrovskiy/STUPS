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
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        #endregion Parameters
    }
}
