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
	public interface ISupportsSelectionItemPattern
	{
		IUiElement Select();
		IUiElement AddToSelection();
		IUiElement RemoveFromSelection();
		bool IsSelected { get; }
		IUiElement SelectionContainer { get; }
	}
}

