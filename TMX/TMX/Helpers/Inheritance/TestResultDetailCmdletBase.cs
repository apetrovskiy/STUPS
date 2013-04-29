/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/31/2013
 * Time: 12:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestResultDetailCmdletBase.
    /// </summary>
    public class TestResultDetailCmdletBase : CommonCmdletBase
    {
        public TestResultDetailCmdletBase()
        {
            // 20130429
            if (TMX.Preferences.AutoEcho) {
                this.Echo = true;
            }
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Id { get; set; }
        
        // 20130325
        //[Parameter(Mandatory = true)]
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string TestResultDetail { get; set; }
        
        // 20130331
        [Parameter(Mandatory = false)]
        public TestResultStatuses TestResultStatus { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Echo { get; set; }
        
        // 20130402
        [Parameter(Mandatory = false)]
        public SwitchParameter Finished { get; set; }
        #endregion Parameters
    }
}
