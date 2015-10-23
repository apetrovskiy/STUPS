/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of TestControlStateCommand.
    /// </summary>
    public class TestControlStateCommand : UiaCommand
    {
        public TestControlStateCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (TestUiaControlStateCommand)Cmdlet;
            
            bool result = 
                cmdlet.TestControlByPropertiesFromHashtable(
                    cmdlet.InputObject,
                    cmdlet.SearchCriteria,
                    0);
            
            cmdlet.WriteObject(cmdlet, result);
        }
    }
}
