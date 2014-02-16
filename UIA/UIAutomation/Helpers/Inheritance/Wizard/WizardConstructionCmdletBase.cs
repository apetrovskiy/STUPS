/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of WizardConstructionCmdletBase.
    /// </summary>
    public class WizardConstructionCmdletBase : WizardCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        public string Description { get; set; }
        #endregion Parameters
    }
}
