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
    /// <summary>
    /// Description of IMouseInput.
    /// </summary>
    public interface IMouseInput
    {
        string m { get; }
        
        IUiElement LeftButtonDoubleClick();
        IUiElement LeftButtonClick();
    }
}
