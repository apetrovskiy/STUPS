/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    public interface ISupportsScrollPattern
    {
        IUiElement SetScrollPercent(double horizontalPercent, double verticalPercent);
        IUiElement Scroll(classic.ScrollAmount horizontalAmount, classic.ScrollAmount verticalAmount);
        IUiElement ScrollHorizontal(classic.ScrollAmount amount);
        IUiElement ScrollVertical(classic.ScrollAmount amount);
        double HorizontalScrollPercent { get; }
        double VerticalScrollPercent { get; }
        double HorizontalViewSize { get; }
        double VerticalViewSize { get; }
        bool HorizontallyScrollable { get; }
        bool VerticallyScrollable { get; }
    }
}
