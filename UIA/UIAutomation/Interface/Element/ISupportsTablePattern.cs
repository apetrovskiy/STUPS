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
	public interface ISupportsTablePattern
	{
		IUiElement[] GetRowHeaders();
		IUiElement[] GetColumnHeaders();
		int TableRowCount { get; }
		int TableColumnCount { get; }
		RowOrColumnMajor RowOrColumnMajor { get; }
	}
}

