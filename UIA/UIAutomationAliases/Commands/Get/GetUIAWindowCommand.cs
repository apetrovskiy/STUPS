/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/17/2012
 * Time: 10:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationAliases.Commands
{
    using System.Management.Automation;

//    /// <summary>
//    /// Description of GetUiaWindowCommand.
//    /// </summary>
//    public class GetUiaWindowCommand
//    {
//        public GetUiaWindowCommand()
//        {
//        }
//    }
    
    
    /// <summary>
    /// Description of GetWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Window")]
    [OutputType(typeof(bool))]
    
    public class GetWindowCommand : UIAutomation.Commands.GetUiaWindowCommand
    { public GetWindowCommand() { } }
    
    //===========================================================================
    /// <summary>
    /// Description of GetWindowCommand.
    /// </summary>
    [Cmdlet(@"Получить", @"Окно")]
    [OutputType(typeof(bool))]
    
    public class GetWindowCommand1 : UIAutomation.Commands.GetUiaWindowCommand
    { public GetWindowCommand1() { } }
    //===========================================================================
}
