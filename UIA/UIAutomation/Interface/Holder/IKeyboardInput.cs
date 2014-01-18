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
    /// Description of IKeyboardInput.
    /// </summary>
    public interface IKeyboardInput
    {
        string k { get; }
        
        // IUiElement TextEntry(string text);
        IUiElement TypeText(string text);
        // property ??
    }
}
