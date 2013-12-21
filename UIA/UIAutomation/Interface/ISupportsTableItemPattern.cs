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
	public interface ISupportsTableItemPattern
	{
		// ITableItemPatternInformation Cached { get; }
		// ITableItemPatternInformation Current { get; }
		
		// AutomationElement[] GetRowHeaderItems();
		IUiElement[] GetRowHeaderItems();
		// AutomationElement[] GetColumnHeaderItems();
		IUiElement[] GetColumnHeaderItems();
		int TableRow { get; }
		int TableColumn { get; }
		int TableRowSpan { get; }
		int TableColumnSpan { get; }
		// AutomationElement ContainingGrid { get; }
		IUiElement TableContainingGrid { get; }
	}
}

