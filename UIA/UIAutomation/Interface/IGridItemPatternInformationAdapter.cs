/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System.Windows.Automation;
	
	public interface IGridItemPatternInformation
	{
		int Row { get; }
		int Column { get; }
		int RowSpan { get; }
		int ColumnSpan { get; }
		// AutomationElement ContainingGrid { get; }
		IUiElement ContainingGrid { get; }
	}
}

