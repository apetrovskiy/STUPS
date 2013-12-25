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

	public interface ITableItemPattern : IBasePattern
	{
		ITableItemPatternInformation Cached { get; }
		ITableItemPatternInformation Current { get; }
	}
}

