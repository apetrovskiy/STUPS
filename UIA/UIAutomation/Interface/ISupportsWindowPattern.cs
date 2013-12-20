/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System.Windows.Automation;
	public interface ISupportsWindowPattern
	{
		// void SetWindowVisualState(WindowVisualState state);
		IUiElement SetWindowVisualState(WindowVisualState state);
		void Close();
		bool WaitForInputIdle(int milliseconds);
		// IWindowPatternInformation Cached { get; }
		// IWindowPatternInformation Current { get; }
	}
}
