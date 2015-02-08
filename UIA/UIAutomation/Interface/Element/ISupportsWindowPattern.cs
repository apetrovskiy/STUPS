/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    public interface ISupportsWindowPattern
    {
        IUiElement SetWindowVisualState(classic.WindowVisualState state);
        void Close();
        bool WaitForInputIdle(int milliseconds);
        bool CanMaximize { get; }
        bool CanMinimize { get; }
        bool IsModal { get; }
        bool IsTopmost { get; }
        classic.WindowInteractionState WindowInteractionState { get; set; } // ?
        classic.WindowVisualState WindowVisualState { get; set; } // ?
    }
}
