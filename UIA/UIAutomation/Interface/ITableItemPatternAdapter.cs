/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System.Windows.Automation;

	public interface IMySuperTableItemPattern : IBasePattern // , ISupportsTableItemPattern
	{
		// TableItemPattern.TableItemPatternInformation Cached { get; }
		ITableItemPatternInformation Cached { get; }
		// TableItemPattern.TableItemPatternInformation Current { get; }
		ITableItemPatternInformation Current { get; }
	}
}

