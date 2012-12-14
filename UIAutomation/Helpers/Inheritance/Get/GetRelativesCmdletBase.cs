/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/11/2012
 * Time: 11:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetRelativesCmdletBase.
    /// </summary>
    public class GetRelativesCmdletBase : GetControlCollectionCmdletBase
    {
        public GetRelativesCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter CaseSensitive { get; set; }
        #endregion Parameters
    }
}
