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
	extern alias UIANET;
	using System;
	using System.Windows.Automation;
	public interface IWindowPatternInformation
	{
		bool CanMaximize { get; }
		bool CanMinimize { get; }
		bool IsModal { get; }
		WindowVisualState WindowVisualState { get; }
		WindowInteractionState WindowInteractionState { get; }
		bool IsTopmost { get; }
	}
}
