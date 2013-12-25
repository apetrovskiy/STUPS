/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/6/2013
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System.Windows.Automation;

	public interface ISelectionPattern : IBasePattern
	{
		ISelectionPatternInformation Cached { get; }
		ISelectionPatternInformation Current { get; }
	}
}

