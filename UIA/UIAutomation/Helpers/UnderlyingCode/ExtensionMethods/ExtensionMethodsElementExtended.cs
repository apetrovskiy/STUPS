/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 12:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
    using System.Windows.Automation.Text;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Windows.Forms;
    using PSTestLib;
    using WindowsInput;
    
    /// <summary>
    /// Description of ExtensionMethodsElementChildren.
    /// </summary>
    public static class ExtensionMethodsElementExtended
    {
        internal static IUiEltCollection PerformFindAll(this IExtendedModelHolder holder, ControlType controlType)
        {
            try {
                return (holder as UiExtendedModelHolder).GetParentElement()
                    .FindAll(
                        holder.GetScope(),
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            controlType));
            } catch (Exception) {
                return new UiEltCollection(true);
                // throw;
            }
        }
        
        internal static IExtendedModelHolder GetExtendedModelHolder(this IUiElement element, TreeScope scope)
        {
            return AutomationFactory.GetUiExtendedModelHolder(element, scope);
        }
        
        internal static T GetHolder<T>(this IUiElement element)
        {
            return AutomationFactory.GetHolder<T>(element);
        }
        
        #region IControlInputHolder
        // internal static IControlInputHolder GetC(this IControlInputHolder holder)
        internal static string GetC(this IControlInputHolder holder)
        {
            return "c"; // holder;
        }
        
        public static IUiElement PerformClick(this IControlInputHolder holder)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    // DoubleClickInterval = 50,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformCoordinatedClick(this IControlInputHolder holder, int X, int Y)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    // DoubleClickInterval = 50,
                    RelativeX = X,
                    RelativeY = Y
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformDoubleClick(this IControlInputHolder holder)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    DoubleClick = true,
                    DoubleClickInterval = 50,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformCoordinatedDoubleClick(this IControlInputHolder holder, int X, int Y)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    DoubleClick = true,
                    DoubleClickInterval = 50,
                    RelativeX = X,
                    RelativeY = Y
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformRightClick(this IControlInputHolder holder)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    RightClick = true,
                    // DoubleClickInterval = 50,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformCtrlClick(this IControlInputHolder holder)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    Ctrl = true,
                    // DoubleClickInterval = 50,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformAltClick(this IControlInputHolder holder)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    Alt = true,
                    // DoubleClickInterval = 50,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformShiftClick(this IControlInputHolder holder)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    Shift = true,
                    // DoubleClickInterval = 50,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        /// <summary>
        /// Invokes the context menu and returns the object representing the menu invoked.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IUiElement PerformInvokeContextMenu(this IControlInputHolder holder)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            
            // 20131226
            // element.InvokeContextMenu(cmdlet);
            
            // return element;
            
            // return the context menu window
            return holder.GetParentElement().InvokeContextMenu(cmdlet, Preferences.ClickOnControlByCoordX, Preferences.ClickOnControlByCoordY);
        }
        
        public static IUiElement PerformCoordinatedInvokeContextMenu(this IControlInputHolder holder, int X, int Y)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            
            // 20131226
            // element.InvokeContextMenu(cmdlet);
            
            // return element;
            
            // return the context menu window
            return holder.GetParentElement().InvokeContextMenu(cmdlet, X, Y);
        }
        #endregion IControlInputHolder
        #region IKeyboardInputHolder
        // internal static IKeyboardInputHolder GetK(this IKeyboardInputHolder holder)
        internal static string GetK(this IKeyboardInputHolder holder)
        {
            return "k"; // holder;
        }
        
        internal static IUiElement PerformTypeText(this IKeyboardInputHolder holder, string text)
        {
            IInputSimulator inputSimulator = AutomationFactory.GetInputSimulator();
            holder.GetParentElement().MoveCursorToControlPosition();
            holder.GetParentElement().SetFocus();
            inputSimulator.Keyboard.TextEntry(text);
            return holder.GetParentElement();
        }
        #endregion IKeyboardInputHolder
        #region IMouseInputHolder
        // internal static IMouseInputHolder GetM(this IMouseInputHolder holder)
        internal static string GetM(this IMouseInputHolder holder)
        {
            return "m"; // holder;
        }
        
//        private static double GetAbsoluteX(this IUiElement element)
//        {
//            return element.Current.BoundingRectangle.
//        }
        
        internal static void MoveCursorToControlPosition(this IUiElement element)
        {
            IInputSimulator inputSimulator = AutomationFactory.GetInputSimulator();
            
            element.SetFocus();
            
            inputSimulator.Mouse.MoveMouseTo(
                (element.Current.BoundingRectangle.X + Preferences.ClickOnControlByCoordX) / Screen.PrimaryScreen.Bounds.Width * 65535,
                (element.Current.BoundingRectangle.Y + Preferences.ClickOnControlByCoordY) / Screen.PrimaryScreen.Bounds.Height * 65535);
        }
        
        internal static IUiElement PerformLeftButtonDoubleClick(this IMouseInputHolder holder)
        {
            IInputSimulator inputSimulator = AutomationFactory.GetInputSimulator();
            holder.GetParentElement().MoveCursorToControlPosition();
            inputSimulator.Mouse.LeftButtonDoubleClick();
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformLeftButtonClick(this IMouseInputHolder holder)
        {
            IInputSimulator inputSimulator = AutomationFactory.GetInputSimulator();
            holder.GetParentElement().MoveCursorToControlPosition();
            inputSimulator.Mouse.LeftButtonClick();
            return holder.GetParentElement();
        }
        #endregion IMouseInputHolder
        #region ITouchInputHolder
        // internal static ITouchInputHolder GetT(this ITouchInputHolder holder)
        internal static string GetT(this ITouchInputHolder holder)
        {
            return "t"; // holder;
        }
        #endregion ITouchInputHolder
    }
}
