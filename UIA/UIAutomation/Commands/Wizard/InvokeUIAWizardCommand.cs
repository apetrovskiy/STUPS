/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 3:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Description of InvokeUiaWizardCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaWizard")]
    public class InvokeUiaWizardCommand : WizardRunCmdletBase
    {
        public InvokeUiaWizardCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            if (null != Parameters && 0 < Parameters.Length)
            {
                WriteVerbose(
                    this,
                    "converting -Parameters hashtables to dictionaries");

                /*
                foreach (Dictionary<string, object> dictParameters in this.Parameters.Select(parametersTable => this.ConvertHashtableToDictionary(parametersTable)))
                {
                    this.ParametersDictionaries.Add(dictParameters);
                }
                */
                foreach (Dictionary<string, object> dictParameters in Parameters.Select(parametersTable => ConvertHashtableToDictionary(parametersTable)))
                {
                    ParametersDictionaries.Add(dictParameters);
                }
                /*
                foreach (Hashtable parametersTable in Parameters) {

                    Dictionary<string, object> dictParameters =
                        ConvertHashtableToDictionary(parametersTable);

                    ParametersDictionaries.Add(dictParameters);
                }
                */
            }

            WriteInfo(this, "accepted " + ParametersDictionaries.Count.ToString() + " step parameters");
            
            if (null != Directions && 0 < Directions.Length)
            {
                WriteVerbose(
                    this,
                    "converting -Directions hashtables to dictionaries");

                /*
                foreach (Dictionary<string, object> dictDirections in this.Directions.Select(directionsTable => this.ConvertHashtableToDictionary(directionsTable)))
                {
                    this.DirectionsDictionaries.Add(dictDirections);
                }
                */
                foreach (Dictionary<string, object> dictDirections in Directions.Select(directionsTable => ConvertHashtableToDictionary(directionsTable)))
                {
                    DirectionsDictionaries.Add(dictDirections);
                }
                /*
                foreach (Hashtable directionsTable in Directions) {
                    
                    Dictionary<string, object> dictDirections =
                        ConvertHashtableToDictionary(directionsTable);
                    
                    DirectionsDictionaries.Add(dictDirections);
                }
                */
            }

            WriteInfo(this, "accepted " + DirectionsDictionaries.Count.ToString() + " step directions");

        	UiaInvokeWizardCommand command =
        		new UiaInvokeWizardCommand(this);
        	command.Execute();
        }
    }
}
