/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/17/2014
 * Time: 10:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    /// <summary>
    /// Description of IMouseInput.
    /// </summary>
    public interface IMouseInput
    {
        IUiElement HorizontalScroll(int scrollAmountInClicks);
        IUiElement LeftButtonClick();
        IUiElement LeftButtonDoubleClick();
        IUiElement LeftButtonDown();
        IUiElement LeftButtonUp();
        IUiElement MoveMouseBy(int pixelDeltaX, int pixelDeltaY);
        IUiElement MoveMouseTo(double absoluteX, double absoluteY);
        IUiElement MoveMouseToPositionOnVirtualDesktop(double absoluteX, double absoluteY);
        IUiElement RightButtonClick();
        IUiElement RightButtonDoubleClick();
        IUiElement RightButtonDown();
        IUiElement RightButtonUp();
        IUiElement Sleep(int milliseconds);
        IUiElement Sleep(TimeSpan timeout);
        IUiElement VerticalScroll(int scrollAmountInClicks);
        IUiElement XButtonClick(int buttonId);
        IUiElement XButtonDoubleClick(int buttonId);
        IUiElement XButtonDown(int buttonId);
        IUiElement XButtonUp(int buttonId);
    }
}
