/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2013
 * Time: 9:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetUiaSelectedItemCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSelectedItem")]
    public class GetUiaSelectedItemCommand : PatternCmdletBase
    {
        public GetUiaSelectedItemCommand()
        {
            WhatToDo = "SelectedItem";
        }
    }
}
