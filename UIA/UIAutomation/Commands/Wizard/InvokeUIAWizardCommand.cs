/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 3:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Description of InvokeUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWizard")]
    public class InvokeUIAWizardCommand : WizardRunCmdletBase
    {
        public InvokeUIAWizardCommand()
        {
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)]
//        internal new Wizard InputObject { get; set; }
//        
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Automatic { get; set; }
//        
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public SwitchParameter ForwardDirection { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            if (null != this.Parameters && 0 < this.Parameters.Length) {
                
                this.WriteVerbose(
                    this,
                    "converting -Parameters hashtables to dictionaries");
                
                foreach (Hashtable parametersTable in this.Parameters) {

                    Dictionary<string, object> dictParameters =
                        this.ConvertHashtableToDictionary(parametersTable);

                    this.ParametersDictionaries.Add(dictParameters);
                }
            }
            
            // 20130508
            this.WriteInfo(this, "accepted " + this.ParametersDictionaries.Count.ToString() + " step parameters");
            
            // 20130322
            if (null != this.Directions && 0 < this.Directions.Length) {
                
                this.WriteVerbose(
                    this,
                    "converting -Directions hashtables to dictionaries");
                
                foreach (Hashtable directionsTable in this.Directions) {
                    
                    Dictionary<string, object> dictDirections =
                        this.ConvertHashtableToDictionary(directionsTable);
                    
                    this.DirectionsDictionaries.Add(dictDirections);
                }
            }
            
            // 20130508
            this.WriteInfo(this, "accepted " + this.DirectionsDictionaries.Count.ToString() + " step directions");

        	UIAInvokeWizardCommand command =
        		new UIAInvokeWizardCommand(this);
        	command.Execute();
        }
    }
}
