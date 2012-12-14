/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/5/2012
 * Time: 6:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SearchCmdletBase.
    /// </summary>
    public class SearchCmdletBase : GetControlCollectionCmdletBase //HasTimeoutCmdletBase
    {
        public SearchCmdletBase()
        {
            this.CaseSensitive = false;
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)]
//        public new string[] ControlType { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public SwitchParameter CaseSensitive { get; set; }
        #endregion Parameters
    }
}
