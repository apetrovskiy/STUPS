/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System.Windows.Automation;

	public interface IDockPattern : IBasePattern
	{
		void SetDockPosition(DockPosition dockPosition);
		IDockPatternInformation Cached { get; }
		IDockPatternInformation Current { get; }
	}
}

