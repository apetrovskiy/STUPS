/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 3:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// Description of WizardCollection.
    /// </summary>
    public static class WizardCollection
    {
        static WizardCollection()
        {
            Wizards = new List<Wizard>();
        }
        
        public static List<Wizard> Wizards { get; set; }
        // 20130401
        public static Wizard CurrentWizard { get; internal set; }
        
        public static void ResetData()
        {
            Wizards = new List<Wizard>();
        }
        
        public static void RemoveWizard(string wizardName)
        {
            Wizard wizard = Wizards.Find(x => x.Name == wizardName);
            
            if (null != wizard) {
                Wizards.Remove(wizard);
            }
        }
        
        public static Wizard GetWizard(string name)
        {
            Wizard wizard = null;
            
            foreach (Wizard wzd in Wizards.Where(wzd => name == wzd.Name))
            {
                wizard = wzd;
                return wizard;
            }
            
            return wizard;
        }
    }
}
