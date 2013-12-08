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
	
	public interface IMySuperGridItemPattern : IBasePattern
	{
		// GridItemPattern.GridItemPatternInformation Cached { get; }
		IGridItemPatternInformation Cached { get; }
		// GridItemPattern.GridItemPatternInformation Current { get; }
		IGridItemPatternInformation Current { get; }
	}
}

