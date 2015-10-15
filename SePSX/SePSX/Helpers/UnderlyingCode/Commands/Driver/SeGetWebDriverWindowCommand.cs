/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeGetWebDriverWindowCommand.
    /// </summary>
    internal class SeGetWebDriverWindowCommand : SeWebDriverCommand
    {
        internal SeGetWebDriverWindowCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetWindow(
                ((GetSeWebDriverWindowCommand)Cmdlet),
                ((GetSeWebDriverWindowCommand)Cmdlet).InputObject);
        }
    }
}
