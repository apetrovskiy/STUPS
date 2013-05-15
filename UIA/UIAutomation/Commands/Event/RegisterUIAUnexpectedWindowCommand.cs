/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/15/2013
 * Time: 3:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of RegisterUIAUnexpectedWindowCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAUnexpectedWindow")]
    public class RegisterUIAUnexpectedWindowCommand : RegisterUIAWindowOpenedEventCommand
    {
        public RegisterUIAUnexpectedWindowCommand()
        {
        }
    }
}
