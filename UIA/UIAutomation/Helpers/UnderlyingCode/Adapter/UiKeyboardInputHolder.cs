/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/18/2014
 * Time: 1:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of UiKeyboardInputHolder.
    /// </summary>
    public class UiKeyboardInputHolder : IKeyboardInputHolder
    {
        private IUiElement _parentElement;
        
        public UiKeyboardInputHolder()
        {
        }
        
        public void SetParentElement(IUiElement parentElement)
        {
            _parentElement = parentElement;
        }
        
        public IUiElement GetParentElement()
        {
            return _parentElement;
        }
    }
}
