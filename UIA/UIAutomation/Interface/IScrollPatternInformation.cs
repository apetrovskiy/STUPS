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
	using System;
	using System.Windows.Automation;
	public interface IScrollPatternInformation
	{
		double HorizontalScrollPercent { get; }
		double VerticalScrollPercent { get; }
		double HorizontalViewSize { get; }
		double VerticalViewSize { get; }
		bool HorizontallyScrollable { get; }
		bool VerticallyScrollable { get; }
	}
}
