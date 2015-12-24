using WindowsInput.Native;
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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
//    using System.Windows.Automation.Text;
//    using System.Collections;
//    using System.Collections.Generic;
//    using System.Management.Automation;
    using System.Windows.Forms;
//    using PSTestLib;
    using WindowsInput;
    
    /// <summary>
    /// Description of ExtensionMethodsElementChildren.
    /// </summary>
    public static class ExtensionMethodsElementExtended
    {
        internal static IInputSimulator InputSimulator { get; set; }
        
        static ExtensionMethodsElementExtended()
        {
            InputSimulator = AutomationFactory.GetInputSimulator();
        }
        
        internal static IUiEltCollection PerformFindAll(this IExtendedModelHolder holder, classic.ControlType controlType)
        {
            try {
                var controlSearcherData =
                    new ControlSearcherData {
                    ControlType = controlType.ConvertControlTypeToStringArray(),
                    InputObject = new IUiElement[] { holder.GetParentElement() }
                };
                
                var controlSearcher =
                    AutomationFactory.GetSearcherImpl<ControlSearcher>();
                
                return AutomationFactory.GetUiEltCollection(
                    controlSearcher.GetElements(
                        controlSearcherData,
                        holder.Seconds));
                
            } catch (Exception) {
                return new UiEltCollection(true);
            }
        }
        
        internal static IUiEltCollection PerformFindAll(this IExtendedModelHolder holder)
        {
            try {
                return (holder as UiExtendedModelHolder).GetParentElement()
                    .FindAll(
                        holder.GetScope(),
                        classic.Condition.TrueCondition);
            } catch (Exception) {
                return new UiEltCollection(true);
                // throw;
            }
        }
        
        // 20140210
        internal static IExtendedModelHolder GetExtendedModelHolder(this IUiElement element, classic.TreeScope scope)
        // internal static IExtendedModelHolder GetExtendedModelHolder(this IUiElement element, TreeScope scope, int seconds)
        {
            // 20140210
            return AutomationFactory.GetUiExtendedModelHolder(element, scope);
            // return AutomationFactory.GetUiExtendedModelHolder(element, scope, seconds);
        }
        
        internal static T GetHolder<T>(this IUiElement element)
        {
            return AutomationFactory.GetHolder<T>(element);
        }
        
        #region IControlInputHolder
//        // internal static IControlInputHolder GetC(this IControlInputHolder holder)
//        internal static string GetC(this IControlInputHolder holder)
//        {
//            return "c"; // holder;
//        }
        
        public static IUiElement PerformClick(this IControlInputHolder holder)
        {
            var cmdlet =
                new HasControlInputCmdletBase();
            
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformCoordinatedClick(this IControlInputHolder holder, int X, int Y)
        {
            var cmdlet =
                new HasControlInputCmdletBase();
            
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    RelativeX = X,
                    RelativeY = Y
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformDoubleClick(this IControlInputHolder holder)
        {
            var cmdlet =
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
            var cmdlet =
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
            var cmdlet =
                new HasControlInputCmdletBase();
            
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    RightClick = true,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformCtrlClick(this IControlInputHolder holder)
        {
            var cmdlet =
                new HasControlInputCmdletBase();
            
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    Ctrl = true,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformAltClick(this IControlInputHolder holder)
        {
            var cmdlet =
                new HasControlInputCmdletBase();
            
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    Alt = true,
                    RelativeX = Preferences.ClickOnControlByCoordX,
                    RelativeY = Preferences.ClickOnControlByCoordY
                });
            
            return holder.GetParentElement();
        }
        
        public static IUiElement PerformShiftClick(this IControlInputHolder holder)
        {
            var cmdlet =
                new HasControlInputCmdletBase();
            
            cmdlet.ClickControl(
                cmdlet,
                holder.GetParentElement(),
                new ClickSettings() {
                    Shift = true,
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
            var cmdlet =
                new HasControlInputCmdletBase();
            
            // return the context menu window
            return holder.GetParentElement().InvokeContextMenu(cmdlet, Preferences.ClickOnControlByCoordX, Preferences.ClickOnControlByCoordY);
        }
        
        public static IUiElement PerformCoordinatedInvokeContextMenu(this IControlInputHolder holder, int X, int Y)
        {
            var cmdlet =
                new HasControlInputCmdletBase();
            
            // return the context menu window
            return holder.GetParentElement().InvokeContextMenu(cmdlet, X, Y);
        }
        #endregion IControlInputHolder
        #region IKeyboardInputHolder
        internal static IUiElement PerformKeyDown(this IKeyboardInputHolder holder, VirtualKeyCode keyCode)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Keyboard.KeyDown(keyCode);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformKeyPressSingle(this IKeyboardInputHolder holder, VirtualKeyCode keyCode)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Keyboard.KeyPress(keyCode);
            return holder.GetParentElement();
        }
        
//        internal static IUiElement PerformKeyPressMultiple(this IKeyboardInputHolder holder, IEnumerable<VirtualKeyCode> keyCodes)
//        {
//            holder.GetParentElement().MoveCursorToControlPosition();
//            InputSimulator.Keyboard.KeyPress(keyCodes);
//            return holder.GetParentElement();
//        }
        
        internal static IUiElement PerformKeyUp(this IKeyboardInputHolder holder, VirtualKeyCode keyCode)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Keyboard.KeyUp(keyCode);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformTypeText(this IKeyboardInputHolder holder, string text)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Keyboard.TextEntry(text);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformTypeChar(this IKeyboardInputHolder holder, char character)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Keyboard.TextEntry(character);
            return holder.GetParentElement();
        }
        #endregion IKeyboardInputHolder
        #region IMouseInputHolder
        internal static void MoveCursorToControlPosition(this IUiElement element)
        {
            element.SetFocus();
            
            InputSimulator.Mouse.MoveMouseTo(
                (element.GetCurrent().BoundingRectangle.X + Preferences.ClickOnControlByCoordX) / Screen.PrimaryScreen.Bounds.Width * 65535,
                (element.GetCurrent().BoundingRectangle.Y + Preferences.ClickOnControlByCoordY) / Screen.PrimaryScreen.Bounds.Height * 65535);
        }
        
        internal static IUiElement PerformHorizontalScroll(this IMouseInputHolder holder, int scrollAmountInClicks)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.HorizontalScroll(scrollAmountInClicks);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformLeftButtonClick(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.LeftButtonClick();
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformLeftButtonDoubleClick(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.LeftButtonDoubleClick();
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformLeftButtonDown(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.LeftButtonDown();
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformLeftButtonUp(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.LeftButtonUp();
            return holder.GetParentElement();
        }
        
//        IUiElement MoveMouseBy(int pixelDeltaX, int pixelDeltaY);
//        IUiElement MoveMouseTo(double absoluteX, double absoluteY);
//        IUiElement MoveMouseToPositionOnVirtualDesktop(double absoluteX, double absoluteY);
        
        internal static IUiElement PerformRightButtonClick(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.RightButtonClick();
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformRightButtonDoubleClick(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.RightButtonDoubleClick();
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformRightButtonDown(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.RightButtonDown();
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformRightButtonUp(this IMouseInputHolder holder)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.RightButtonUp();
            return holder.GetParentElement();
        }

//        IUiElement Sleep(int milliseconds);
//        IUiElement Sleep(TimeSpan timeout);

        internal static IUiElement PerformVerticalScroll(this IMouseInputHolder holder, int scrollAmountInClicks)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.VerticalScroll(scrollAmountInClicks);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformXButtonClick(this IMouseInputHolder holder, int buttonId)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.XButtonClick(buttonId);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformXButtonDoubleClick(this IMouseInputHolder holder, int buttonId)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.XButtonDoubleClick(buttonId);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformXButtonDown(this IMouseInputHolder holder, int buttonId)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.XButtonDown(buttonId);
            return holder.GetParentElement();
        }
        
        internal static IUiElement PerformXButtonUp(this IMouseInputHolder holder, int buttonId)
        {
            holder.GetParentElement().MoveCursorToControlPosition();
            InputSimulator.Mouse.XButtonUp(buttonId);
            return holder.GetParentElement();
        }
        #endregion IMouseInputHolder
        #region ITouchInputHolder
        internal static string GetT(this ITouchInputHolder holder)
        {
            return "t"; // holder;
        }
        #endregion ITouchInputHolder
    }
}
