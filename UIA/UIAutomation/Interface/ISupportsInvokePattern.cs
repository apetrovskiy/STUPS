/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2013
 * Time: 1:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	public interface ISupportsInvokePattern
	{
		// void Invoke();
		// void Click();
		IUiElement Click();
		IUiElement DoubleClick();
		IUiElement RightClick();
		IUiElement CtrlClick();
		IUiElement AltClick();
		IUiElement ShiftClick();
		IUiElement Click(int X, int Y);
		IUiElement DoubleClick(int X, int Y);
		IUiElement InvokeContextMenu();
	}
}
