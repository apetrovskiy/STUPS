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
	public interface ISupportsRangeValuePattern
	{
		// void SetValue(double value);
		// IUiElement SetValue(double value); // ?
		// IRangeValuePatternInformation Cached { get; }
		// IRangeValuePatternInformation Current { get; }
		
		// double Value { get; }
		double RangeValue { get; set; }
		bool IsRangeReadOnly { get; }
		double Maximum { get; }
		double Minimum { get; }
		double LargeChange { get; }
		double SmallChange { get; }
	}
}

