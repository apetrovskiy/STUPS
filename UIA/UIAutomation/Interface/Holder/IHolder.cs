/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/18/2014
 * Time: 1:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of IHolder.
    /// </summary>
    public interface IHolder
    {
        void SetParentElement(IUiElement parentElement);
        IUiElement GetParentElement();
    }
}
