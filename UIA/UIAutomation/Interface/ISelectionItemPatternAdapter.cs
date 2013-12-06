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
	
	public interface IMySuperSelectionItemPattern : IBasePattern
	{
		void Select();
		void AddToSelection();
		void RemoveFromSelection();
		// SelectionItemPattern.SelectionItemPatternInformation Cached { get; }
		// SelectionItemPattern.SelectionItemPatternInformation Current { get; }
		ISelectionItemPatternInformation Cached { get; }
		ISelectionItemPatternInformation Current { get; }
		
		IMySuperWrapper ParentElement { get; set; }
	}
}

