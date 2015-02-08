/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2013
 * Time: 1:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    public interface ISupportsNavigation
    {
        IUiElement NavigateToParent();
        IUiElement NavigateToFirstChild();
        IUiElement NavigateToLastChild();
        IUiElement NavigateToNextSibling();
        IUiElement NavigateToPreviousSibling();
    }
}
