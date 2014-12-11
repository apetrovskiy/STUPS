/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2012
 * Time: 11:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddScenarioCmdletBase.
    /// </summary>
    public class AddScenarioCmdletBase : ScenarioCmdletBase
    {
        // 20141211
        public AddScenarioCmdletBase()
        {
            BeforeTest = new ScriptBlock[]{};
            AfterTest = new ScriptBlock[]{};
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] BeforeTest { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] AfterTest { get; set; }
        #endregion Parameters
    }
}
