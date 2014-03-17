/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
//    using System.Windows.Automation;
    using UIAutomation.Helpers.Commands;
    
    /// <summary>
    /// Description of GetUiaDesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDesktop")]
    [OutputType(typeof(UIAutomation.IUiElement[]))] // [OutputType(typeof(object))]
    public class GetUiaDesktopCommand : GetCmdletBase
    {
        protected override void BeginProcessing()
        {
//System.Console.WriteLine("desktop 0001");
            var command =
                AutomationFactory.GetCommand<GetDesktopCommand>(this);
            
            // command.Cmdlet = this;
            
//System.Console.WriteLine("desktop 0002");
//if (null != command) {
//    System.Console.WriteLine("null != command");
//    System.Console.WriteLine(command.GetType().Name);
////    try {
////        if (null != command.Cmdlet) {
////            System.Console.WriteLine("null != command.Cmdlet");
////            System.Console.WriteLine(command.Cmdlet.GetType().Name);
////        } else {
////            System.Console.WriteLine("null == command.Cmdlet");
////        }
////    }
////    catch (System.Exception eee) {
////        System.Console.WriteLine(eee.Message);
////    }
//} else {
//    System.Console.WriteLine("null == command");
//}
////System.Threading.Thread.Sleep(5000);
//System.Console.WriteLine("desktop 0002.1");
            command.Execute();
//System.Console.WriteLine("desktop 0003");
        }
    }
}
