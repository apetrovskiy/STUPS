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
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            if (null != this.Parameters && 0 < this.Parameters.Length)
            {
                this.WriteVerbose(
                    this,
                    "converting -Parameters hashtables to dictionaries");

                /*
                foreach (Dictionary<string, object> dictParameters in this.Parameters.Select(parametersTable => this.ConvertHashtableToDictionary(parametersTable)))
                {
                    this.ParametersDictionaries.Add(dictParameters);
                }
                */
                foreach (Hashtable parametersTable in this.Parameters) {

                    Dictionary<string, object> dictParameters =
                        this.ConvertHashtableToDictionary(parametersTable);

                    this.ParametersDictionaries.Add(dictParameters);
                }
            }

            this.WriteInfo(this, "accepted " + this.ParametersDictionaries.Count.ToString() + " step parameters");
            
            if (null != this.Directions && 0 < this.Directions.Length)
            {
                this.WriteVerbose(
                    this,
                    "converting -Directions hashtables to dictionaries");

                /*
                foreach (Dictionary<string, object> dictDirections in this.Directions.Select(directionsTable => this.ConvertHashtableToDictionary(directionsTable)))
                {
                    this.DirectionsDictionaries.Add(dictDirections);
                }
                */
                foreach (Hashtable directionsTable in this.Directions) {
                    
                    Dictionary<string, object> dictDirections =
                        this.ConvertHashtableToDictionary(directionsTable);
                    
                    this.DirectionsDictionaries.Add(dictDirections);
                }
            }

            this.WriteInfo(this, "accepted " + this.DirectionsDictionaries.Count.ToString() + " step directions");

        	UIAInvokeWizardCommand command =
        		new UIAInvokeWizardCommand(this);
        	command.Execute();
        }
    }
}
