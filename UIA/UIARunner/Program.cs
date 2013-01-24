/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/28/2012
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIARunner
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            RunModes mode = RunModes.GUI;
            
            if (args == null || args.Length > 0) {
                if (System.IO.File.Exists(args[0])) {
                    mode = RunModes.Unattended;
                } else {
                    Console.WriteLine(
                        "The path to a script file '" + 
                        args[0] +
                        "' is not valid.");
                }
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (mode == RunModes.Unattended) {
                UIARunnerForm runnerForm =
                    new UIARunnerForm();
                PSTestRunner.TestRunner.InitScript();
                TMX.TestData.TMXNewTestResultClosed += 
                    new TMX.TMXStructureChangedEventHandler(
                        PSTestRunner.TestRunner.NewTestResultClosed);
                PSRunner.Runner.PSErrorThrown +=
                    new PSRunner.PSStateChangedEventHandler(
                        runnerForm.PSStateErrorThrown);
                PSRunner.Runner.PSOutputArrived +=
                    new PSRunner.PSDataArrivedEventHandler(
                        runnerForm.PSOutputArrived);
                PSTestRunner.TestRunner.RunScript(args[0], true);
            } else {
                Application.Run(new UIARunnerForm());
            }
        }
        
    }
}
