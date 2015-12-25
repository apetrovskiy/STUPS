/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/25/2013
 * Time: 9:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using UIAutomation;
    using UIAutomation.Commands;
    using System.Management.Automation;
    using PSTestLib;

    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < UnitTestOutput.Count) {

                UnitTestOutput.Clear();
            }
            
            CurrentData.ResetData();
            
        }
        
        public static void CreateWizard(string name, ScriptBlock[] sb)
        {
Console.WriteLine("CreateWizard 00001");
            NewUiaWizardCommand cmdlet =
                new NewUiaWizardCommand {Name = name};
Console.WriteLine("CreateWizard 00002");
            // the -StartAction parameter could not be $null
            cmdlet.StartAction = new ScriptBlock[]{ };
            NewWizardCommand command =
                new NewWizardCommand(cmdlet);
Console.WriteLine("CreateWizard 00003");
            command.Execute();
Console.WriteLine("CreateWizard 00004");
        }
        
        public static void AddWizardStep(string name, ScriptBlock[] forwardAction, ScriptBlock[] backwardAction)
        {
Console.WriteLine("AddWizardStep 00001");
            CreateWizard("wizard", null);
Console.WriteLine("AddWizardStep 00002");
            Wizard wizard =
                (Wizard)UnitTestOutput.LastOutput[0];
Console.WriteLine("AddWizardStep 00003");
            AddUiaWizardStepCommand cmdlet =
                new AddUiaWizardStepCommand();
Console.WriteLine("AddWizardStep 00004");
            cmdlet.InputObject = wizard;
            cmdlet.Name = name;
            cmdlet.StepForwardAction = forwardAction;
            cmdlet.StepBackwardAction = backwardAction;
Console.WriteLine("AddWizardStep 00005");
            AddWizardStepCommand command =
                new AddWizardStepCommand(cmdlet);
Console.WriteLine("AddWizardStep 00006");
            command.Execute();
Console.WriteLine("AddWizardStep 00007");
        }
    }
}
