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
	using System.Windows.Automation.Text;
	using System.Windows;

	public interface ITextPattern : IBasePattern
	{
		TextPatternRange[] GetSelection();
		TextPatternRange[] GetVisibleRanges();
		TextPatternRange RangeFromChild(IUiElement childElement);
		TextPatternRange RangeFromPoint(Point screenLocation);
		TextPatternRange DocumentRange { get; }
		SupportedTextSelection SupportedTextSelection { get; }
	}
}
