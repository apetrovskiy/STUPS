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

	public interface IScrollPattern : IBasePattern
	{
		void SetScrollPercent(double horizontalPercent, double verticalPercent);
		void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
		void ScrollHorizontal(ScrollAmount amount);
		void ScrollVertical(ScrollAmount amount);
		IScrollPatternInformation Cached { get; }
		IScrollPatternInformation Current { get; }
	}
}
