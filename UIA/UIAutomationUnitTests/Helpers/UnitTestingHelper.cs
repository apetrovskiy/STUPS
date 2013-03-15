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
    using PSTestLib;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        static UnitTestingHelper()
        {
        }
        
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < PSTestLib.UnitTestOutput.Count) {

                PSTestLib.UnitTestOutput.Clear();
            }
            
            UIAutomation.CurrentData.ResetData();
            
        }
        
        public static void CreateWizard(string name, ScriptBlock[] sb)
        {
Console.WriteLine("CreateWizard 00001");
            UIAutomation.Commands.NewUIAWizardCommand cmdlet =
                new UIAutomation.Commands.NewUIAWizardCommand();
            cmdlet.Name = name;
Console.WriteLine("CreateWizard 00002");
            // the -StartAction parameter could not be $null
            cmdlet.StartAction = new ScriptBlock[]{ };
            UIANewWizardCommand command =
                new UIANewWizardCommand(cmdlet);
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
        	UIAutomation.Commands.AddUIAWizardStepCommand cmdlet =
        	    new AddUIAWizardStepCommand();
Console.WriteLine("AddWizardStep 00004");
        	cmdlet.InputObject = wizard;
        	cmdlet.Name = name;
        	cmdlet.StepForwardAction = forwardAction;
        	cmdlet.StepBackwardAction = backwardAction;
Console.WriteLine("AddWizardStep 00005");
        	UIAutomation.UIAAddWizardStepCommand command =
        	    new UIAutomation.UIAAddWizardStepCommand(cmdlet);
Console.WriteLine("AddWizardStep 00006");
        	command.Execute();
Console.WriteLine("AddWizardStep 00007");
        }
    }
}
