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

	public interface ITransformPattern : IBasePattern
	{
		void Move(double x, double y);
		void Resize(double width, double height);
		void Rotate(double degrees);
		ITransformPatternInformation Cached { get; }
		ITransformPatternInformation Current { get; }
	}
}

