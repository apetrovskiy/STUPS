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
    using WindowsInput.Native;
    
    /// <summary>
    /// Description of IKeyboardInput.
    /// </summary>
    public interface IKeyboardInput
    {
        // IUiElement TextEntry(string text);
        IUiElement TypeText(string text);
        IUiElement TypeChar(char character);
        // property ??

        IUiElement KeyDown(VirtualKeyCode virtualKeyCode);
        IUiElement KeyPress(VirtualKeyCode virtualKeyCode);
        IUiElement KeyPress(VirtualKeyCode[] virtualKeyCodes);
        IUiElement KeyUp(VirtualKeyCode virtualKeyCode);
        /*
        IUiElement ModifiedKeyStroke(new [] { VirtualKeyCode.SHIFT, VirtualKeyCode.CONTROL }, new [] { VirtualKeyCode.VK_G, VirtualKeyCode.VK_F });
        IUiElement ModifiedKeyStroke(new [] { VirtualKeyCode.SHIFT, VirtualKeyCode.CONTROL }, VirtualKeyCode.VK_F);
        IUiElement ModifiedKeyStroke(VirtualKeyCode.SHIFT, new [] { VirtualKeyCode.VK_G, VirtualKeyCode.VK_F });
        IUiElement ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.VK_F);
        IUiElement Sleep(1000);
        // IUiElement Sleep(timespan);
        IUiElement TextEntry("aaaaaaaaaaaa");
        IUiElement TextEntry('b');
        */
    }
}
