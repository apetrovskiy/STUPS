/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 12:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of WizardContainerCmdletBase.
    /// </summary>
    public class WizardContainerCmdletBase : WizardConstructionCmdletBase
    {
        public WizardContainerCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new Wizard InputObject { get; set; }
        #endregion Parameters
    }
}
