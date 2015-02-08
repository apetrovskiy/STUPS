/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/17/2014
 * Time: 10:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of IControlInput.
    /// </summary>
    public interface IControlInput
    {
        IUiElement Click();
        IUiElement DoubleClick();
        IUiElement DoubleClick(int X, int Y);
        IUiElement RightClick();
        IUiElement CtrlClick();
        IUiElement AltClick();
        IUiElement ShiftClick();
        IUiElement Click(int X, int Y);
        IUiElement InvokeContextMenu();
        IUiElement InvokeContextMenu(int X, int Y);
    }
}
