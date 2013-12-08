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
	
	public interface IMySuperScrollPattern : IBasePattern
	{
		void SetScrollPercent(double horizontalPercent, double verticalPercent);
		void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
		void ScrollHorizontal(ScrollAmount amount);
		void ScrollVertical(ScrollAmount amount);
		// ScrollPattern.ScrollPatternInformation Cached { get; }
		// ScrollPattern.ScrollPatternInformation Current { get; }
		IScrollPatternInformation Cached { get; }
		IScrollPatternInformation Current { get; }
		
		IUiElement ParentElement { get; set; }
	}
}
