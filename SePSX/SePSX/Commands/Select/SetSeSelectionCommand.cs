/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-03
 * Time: 05:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SetSeSelectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "SeSelection")]
    [OutputType(typeof(bool))]
    public class SetSeSelectionCommand : SetSelectionCmdletBase
    {
        public SetSeSelectionCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkInputWebElementOnly(this.InputObject);
            
            SeHelper.SetSelect(
                this,
                this.InputObject,
                this.Index,
                this.Value,
                this.VisibleText,
                this.All,
                this.Deselect);
        }
    }
}
