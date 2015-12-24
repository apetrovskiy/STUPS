/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SeSetWebElementKeysCommand.
    /// </summary>
    internal class SeSetWebElementKeysCommand : SeWebElementCommand
    {
        internal SeSetWebElementKeysCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.SendWebElementKeys(
//                ((SetSeWebElementKeysCommand)this.Cmdlet),
//                ((IWebElement[])((SetSeWebElementKeysCommand)this.Cmdlet).InputObject),
//                ((SetSeWebElementKeysCommand)this.Cmdlet).Text);
            SeHelper.SendWebElementKeys(
                Cmdlet,
                ((IWebElement[])((SetSeWebElementKeysCommand)Cmdlet).InputObject),
                ((SetSeWebElementKeysCommand)Cmdlet).Text);
        }
    }
}
