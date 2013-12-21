/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System.Windows.Automation;
	public interface ISupportsScrollPattern
	{
		// void SetScrollPercent(double horizontalPercent, double verticalPercent);
		IUiElement SetScrollPercent(double horizontalPercent, double verticalPercent);
		// void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
		IUiElement Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
		// void ScrollHorizontal(ScrollAmount amount);
		IUiElement ScrollHorizontal(ScrollAmount amount);
		// void ScrollVertical(ScrollAmount amount);
		IUiElement ScrollVertical(ScrollAmount amount);
		// IScrollPatternInformation Cached { get; }
		// IScrollPatternInformation Current { get; }
		
		double HorizontalScrollPercent { get; }
		double VerticalScrollPercent { get; }
		double HorizontalViewSize { get; }
		double VerticalViewSize { get; }
		bool HorizontallyScrollable { get; }
		bool VerticallyScrollable { get; }
	}
}
