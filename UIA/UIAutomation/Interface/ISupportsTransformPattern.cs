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
	public interface ISupportsTransformPattern
	{
		IUiElement Move(double x, double y);
		IUiElement Resize(double width, double height);
		IUiElement Rotate(double degrees);
		bool CanMove { get; }
		bool CanResize { get; }
		bool CanRotate { get; }
	}
}

