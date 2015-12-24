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
    /// <summary>
    /// Description of SeReadWebDriverPageSourceCommand.
    /// </summary>
    internal class SeReadWebDriverPageSourceCommand : SeWebDriverCommand
    {
        internal SeReadWebDriverPageSourceCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetPageSource(
//                ((SeReadWebDriverPageSourceCommand)this.Cmdlet),
//                ((SeReadWebDriverPageSourceCommand)this.Cmdlet).InputObject);
            SeHelper.GetPageSource(
                Cmdlet,
                ((HasWebDriverInputCmdletBase)Cmdlet).InputObject);
        }
    }
}
