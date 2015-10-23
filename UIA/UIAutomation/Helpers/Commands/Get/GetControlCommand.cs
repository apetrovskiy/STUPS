/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 1:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System.Management.Automation;
//    using System.Collections;
    using System.Linq;
    using PSTestLib;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of GetControlCommand.
    /// </summary>
    public class GetControlCommand : UiaCommand
    {
        public GetControlCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet = (GetUiaControlCommand)Cmdlet;
            var controlSearcher = AutomationFactory.GetSearcherImpl<ControlSearcher>() as ControlSearcher;
            
            var returnCollection =
                controlSearcher.GetElements(
                    controlSearcher.ConvertCmdletToControlSearcherData(cmdlet),
                    cmdlet.Timeout);

            if (null != returnCollection && 0 < returnCollection.Count)
                cmdlet.WriteObject(cmdlet, returnCollection);
            else
                cmdlet.WriteError(
                    cmdlet,
                    "failed to get control in " +
                    cmdlet.Timeout +
                    " milliseconds by:" +
                    " title: '" +
                    cmdlet.Name +
                    "', automationId: '" +
                    cmdlet.AutomationId +
                    "', className: '" +
                    cmdlet.Class +
                    "', value: '" +
                    cmdlet.Value +
                    "'. Search was performed from " +
                    cmdlet.InputObject.ConvertToHashtables().Select(hashtable => hashtable).ConvertToString(),
                    "ControlIsNull",
                    ErrorCategory.OperationTimeout,
                    true);
        }
    }
}
