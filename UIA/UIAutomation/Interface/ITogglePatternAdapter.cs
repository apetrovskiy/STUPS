/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/6/2013
 * Time: 10:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System.Windows.Automation;
    
	public interface IMySuperTogglePattern : IBasePattern
	{
		void Toggle();
		// TogglePattern.TogglePatternInformation Cached { get; }
		// TogglePattern.TogglePatternInformation Current { get; }
		ITogglePatternInformation Cached { get; }
		ITogglePatternInformation Current { get; }
		
		IMySuperWrapper ParentElement { get; set; }
	}
}
