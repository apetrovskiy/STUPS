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
	
	public interface ITableItemPatternInformation
	{
		// AutomationElement[] GetRowHeaderItems();
		IUiElement[] GetRowHeaderItems();
		// AutomationElement[] GetColumnHeaderItems();
		IUiElement[] GetColumnHeaderItems();
		int Row { get; }
		int Column { get; }
		int RowSpan { get; }
		int ColumnSpan { get; }
		// AutomationElement ContainingGrid { get; }
		IUiElement ContainingGrid { get; }
	}
}

