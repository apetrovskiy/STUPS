/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/18/2014
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of UiInputHolder.
    /// </summary>
    public class UiInputHolder : IHolder
    {
        private IUiElement _parentElement;
        
        public UiInputHolder()
        {
//            CreationTime = System.DateTime.Now;
            
            // 20140210
            // Seconds = seconds;
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
