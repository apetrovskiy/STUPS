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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetUIASelectedItemCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASelectedItem")]
    public class GetUIASelectedItemCommand : PatternCmdletBase
    {
        public GetUIASelectedItemCommand()
        {
            WhatToDo = "SelectedItem";
        }
    }
}
