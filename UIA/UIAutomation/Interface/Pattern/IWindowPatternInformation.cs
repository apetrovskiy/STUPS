/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;// using System.Windows.Automation;
	using System;
	using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;
	
	public interface IWindowPatternInformation
	{
		bool CanMaximize { get; }
		bool CanMinimize { get; }
		bool IsModal { get; }
		classic.WindowVisualState WindowVisualState { get; }
		classic.WindowInteractionState WindowInteractionState { get; }
		bool IsTopmost { get; }
	}
}
