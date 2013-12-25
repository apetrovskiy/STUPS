/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/6/2013
 * Time: 10:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System.Windows.Automation;
	public interface ISupportsExpandCollapsePattern
	{
		IUiElement Expand();
		IUiElement Collapse();
		ExpandCollapseState ExpandCollapseState { get; }
	}
}
