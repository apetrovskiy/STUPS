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

	public interface IMySuperGridPattern : IBasePattern // , ISupportsGridPattern
	{
		// AutomationElement GetItem(int row, int column);
		IUiElement GetItem(int row, int column);
		// GridPattern.GridPatternInformation Cached { get; }
		IGridPatternInformation Cached { get; }
		// GridPattern.GridPatternInformation Current { get; }
		IGridPatternInformation Current { get; }
	}
}

