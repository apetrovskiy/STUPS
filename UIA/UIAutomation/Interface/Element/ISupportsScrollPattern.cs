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
		IUiElement SetScrollPercent(double horizontalPercent, double verticalPercent);
		IUiElement Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
		IUiElement ScrollHorizontal(ScrollAmount amount);
		IUiElement ScrollVertical(ScrollAmount amount);
		double HorizontalScrollPercent { get; }
		double VerticalScrollPercent { get; }
		double HorizontalViewSize { get; }
		double VerticalViewSize { get; }
		bool HorizontallyScrollable { get; }
		bool VerticallyScrollable { get; }
	}
}
