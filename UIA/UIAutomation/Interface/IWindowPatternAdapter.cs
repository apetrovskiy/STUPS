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
	
	public interface IMySuperWindowPattern : IBasePattern
	{
		void SetWindowVisualState(WindowVisualState state);
		void Close();
		bool WaitForInputIdle(int milliseconds);
		// WindowPattern.WindowPatternInformation Cached { get; }
		// WindowPattern.WindowPatternInformation Current { get; }
		IWindowPatternInformation Cached { get; }
		IWindowPatternInformation Current { get; }
		
//		IUiElement ParentElement { get; set; }
	}
}
