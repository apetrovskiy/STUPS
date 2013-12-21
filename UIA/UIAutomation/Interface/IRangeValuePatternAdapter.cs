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

	public interface IMySuperRangeValuePattern : IBasePattern //, ISupportsRangeValuePattern
	{
		void SetValue(double value);
		// RangeValuePattern.RangeValuePatternInformation Cached { get; }
		IRangeValuePatternInformation Cached { get; }
		// RangeValuePattern.RangeValuePatternInformation Current { get; }
		IRangeValuePatternInformation Current { get; }
	}
}

