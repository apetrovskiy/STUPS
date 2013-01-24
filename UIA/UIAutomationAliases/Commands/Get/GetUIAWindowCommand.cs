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
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
//    /// <summary>
//    /// Description of GetUIAWindowCommand.
//    /// </summary>
//    public class GetUIAWindowCommand
//    {
//        public GetUIAWindowCommand()
//        {
//        }
//    }
    
    
    /// <summary>
    /// Description of GetWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Window")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetWindowCommand : UIAutomation.Commands.GetUIAWindowCommand
    { public GetWindowCommand() { } }
    
    //===========================================================================
    /// <summary>
    /// Description of GetWindowCommand.
    /// </summary>
    [Cmdlet(@"Получить", @"Окно")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetWindowCommand1 : UIAutomation.Commands.GetUIAWindowCommand
    { public GetWindowCommand1() { } }
    //===========================================================================
}
