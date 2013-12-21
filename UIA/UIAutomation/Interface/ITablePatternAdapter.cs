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

	public interface IMySuperTablePattern : IBasePattern // , ISupportsTablePattern
	{
		// TablePattern.TablePatternInformation Cached { get; }
		ITablePatternInformation Cached { get; }
		// TablePattern.TablePatternInformation Current { get; }
		ITablePatternInformation Current { get; }
	}
}

