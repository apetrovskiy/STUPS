/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/24/2013
 * Time: 2:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	public interface IMySuperValuePattern : IBasePattern //, ISupportsValuePattern
	{
		// IValuePatternAdapter
		void SetValue(string value);
		IValuePatternInformation Cached { get; }
		IValuePatternInformation Current { get; }

//		IUiElement ParentElement { get; set; }
	}
}
