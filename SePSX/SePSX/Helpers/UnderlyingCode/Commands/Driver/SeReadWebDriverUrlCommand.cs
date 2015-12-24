/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeReadWebDriverUrlCommand.
    /// </summary>
    internal class SeReadWebDriverUrlCommand : SeWebDriverCommand
    {
        internal SeReadWebDriverUrlCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetUrl(
                ((ReadSeWebDriverUrlCommand)Cmdlet),
                ((ReadSeWebDriverUrlCommand)Cmdlet).InputObject);
        }
    }
}
