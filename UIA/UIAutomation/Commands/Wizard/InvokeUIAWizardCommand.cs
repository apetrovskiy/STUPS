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
    using System.Management.Automation;
    using System.Collections.Generic;
    using PSTestLib;
    
    using Helpers.Commands;

    /// <summary>
    /// Description of InvokeUiaWizardCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaWizard")]
    public class InvokeUiaWizardCommand : WizardRunCmdletBase
    {
        protected override void BeginProcessing()
        {
            if (null != Parameters && 0 < Parameters.Length)
            {
//                WriteVerbose(
//                    this,
//                    "converting -Parameters hashtables to dictionaries");
                
                foreach (Dictionary<string, object> dictParameters in Parameters.Select(parameterHashtable => parameterHashtable.ConvertHashtableToDictionary()))
                {
                    ParametersDictionaries.Add(dictParameters);
                }
            }

            WriteInfo(this, "accepted " + ParametersDictionaries.Count.ToString() + " step parameters");
            
            if (null != Directions && 0 < Directions.Length)
            {
//                WriteVerbose(
//                    this,
//                    "converting -Directions hashtables to dictionaries");
                
                foreach (Dictionary<string, object> dictDirections in Directions.Select(directionHashtable => directionHashtable.ConvertHashtableToDictionary()))
                {
                    DirectionsDictionaries.Add(dictDirections);
                }
            }

            WriteInfo(this, "accepted " + DirectionsDictionaries.Count.ToString() + " step directions");

            InvokeWizardCommand command =
                new InvokeWizardCommand(this);
            command.Execute();
        }
    }
}
