/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/12/2014
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of WaitControlStateCommand.
    /// </summary>
    public class WaitControlStateCommand : UiaCommand
    {
        public WaitControlStateCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            /*
            bool result = false;
            do {
                result = 
                    TestControlByPropertiesFromHashtable(
                        InputObject,
                        SearchCriteria,
                        Timeout);
                if (result) {
                    WriteObject(this, true);
                    return;
                } else {
                    SleepAndRunScriptBlocks(this);
                    // wait until timeout expires or the state will be confirmed as valid
                    DateTime nowDate = 
                        DateTime.Now;
                    if ((nowDate - StartDate).TotalSeconds > Timeout / 1000) {
                        result = true;
                    }
                }
            } while (!result);
            
            // graceful fail
            WriteObject(this, false);
            */
            
            var cmdlet =
                (WaitUiaControlStateCommand)Cmdlet;
            
            bool result = 
                cmdlet.TestControlByPropertiesFromHashtable(
                    cmdlet.InputObject,
                    cmdlet.SearchCriteria,
                    cmdlet.Timeout);
            cmdlet.WriteObject(cmdlet, result);
        }
    }
}
