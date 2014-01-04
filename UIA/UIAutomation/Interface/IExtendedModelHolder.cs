/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 1:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of IExtendedModelHolder.
    /// </summary>
    public interface IExtendedModelHolder
    {
        void SetParentElement(IUiElement parentElement);
        IUiElement GetParentElement();
    }
}
