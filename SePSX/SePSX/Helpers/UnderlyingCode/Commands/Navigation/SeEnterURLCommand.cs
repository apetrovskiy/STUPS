/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/2/2012
 * Time: 2:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeEnterURLCommand.
    /// </summary>
    internal class SeEnterUrlCommand : SeNavigationCommand
    {
        internal SeEnterUrlCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetWebElement(
//                ((GetSeWebElementCommand)this.Cmdlet),
//                ((GetSeWebElementCommand)this.Cmdlet).InputObject);
//            SeHelper.GetWebElement(
//                this.Cmdlet,
//                ((GetSeWebElementCommand)this.Cmdlet).InputObject);
//            SeHelper.NavigateTo(
//                this, 
//                this.InputObject, 
//                this.URL);
//Console.WriteLine("command 01");
            SeHelper.NavigateTo(
                Cmdlet,
                ((EnterSeUrlCommand)Cmdlet).InputObject,
                ((EnterSeUrlCommand)Cmdlet).Url);
//Console.WriteLine("command 02");
        }
    }
}
