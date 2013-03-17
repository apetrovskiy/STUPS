/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/02/2012
 * Time: 12:16 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of WizardCmdletBase.
    /// </summary>
    public class WizardCmdletBase : HasControlInputCmdletBase //HasScriptBlockCmdletBase ////?
    {
        public WizardCmdletBase()
        {
        }
        
        
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        public new Wizard InputObject { get; set; }
// [Parameter(Mandatory = false)]
// public int Order { get; set; }
        #endregion Parameters
        
        //protected bool ValidateWizardName(string name)
        protected internal bool ValidateWizardName(string name)
        {
            bool result = false;
            if (name == null || name == string.Empty) {
                WriteVerbose(this, "wizard name is empty");
                return result;
            }
            foreach (Wizard wzd in WizardCollection.Wizards) {
                if (wzd.Name == name) {
                    WriteVerbose(this, "wizard name is not unique");
                    return result;
                }
            }
            WriteVerbose(this, "wizard name is unique");
            result = true;
            return result;
        }
        
        protected internal Wizard GetWizard(string name)
        {
            Wizard result = null;
            
            if (name == null || name == string.Empty) {
                return result;
            }
            foreach (Wizard wzd in WizardCollection.Wizards) {
                if (wzd.Name == name) {
                    result = wzd;
                    return result;
                }
            }
            return result;
        }
    }
}
