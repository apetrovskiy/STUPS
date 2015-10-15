/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeGetElementByTypeCommand.
    /// </summary>
    internal class SeGetElementByTypeCommand : SeWebElementCommand
    {
        internal SeGetElementByTypeCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetWebElementViaJs(
                Cmdlet,
                ((GetSeElementByTypeCommand)Cmdlet).InputObject, 
                ((GetSeElementByTypeCommand)Cmdlet).TagName);
        }
    }
}
