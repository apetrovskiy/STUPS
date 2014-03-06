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
	extern alias UIANET;// using System.Windows.Automation;
	using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;

	public interface IExpandCollapsePattern : IBasePattern
	{
		void Expand();
		void Collapse();
		IExpandCollapsePatternInformation Cached { get; }
		IExpandCollapsePatternInformation Current { get; }
	}
}
