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
    using System.Management.Automation;

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
            checkInputWebElementOnly(InputObject);
            
            SeHelper.SetSelect(
                this,
                InputObject,
                Index,
                Value,
                VisibleText,
                All,
                Deselect);
        }
    }
}
