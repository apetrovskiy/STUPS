/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2013
 * Time: 3:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Reflection;
    using System.Windows.Automation;
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of MethodSelectorAspect.
    /// </summary>
    public class MethodSelectorAspect : AbstractInterceptor
    {
        internal static bool AlreadySelected { get; set; }
        
        public override void Intercept(IInvocation invocation)
        {
//            bool returnItself = true;
            
            try {
                if (!AlreadySelected) {
                    AlreadySelected = true;
//Console.WriteLine("selection of what to proceed");
                    switch (invocation.Method.Name) {
                        #region InvokePattern
                        case "Click":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformClick();
                            // (invocation.Proxy as UiElement).Click();
                            break;
                        case "DoubleClick":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformDoubleClick();
                            break;
                        #endregion InvokePattern
                        #region SelectionItemPattern
                        case "Select":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSelect();
                            break;
                        case "AddToSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformAddToSelection();
                            break;
                        case "RemoveFromSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformRemoveFromSelection();
                            break;
                        case "get_IsSelected":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsSelected();
                            break;
                        case "get_SelectionContainer":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetSelectionContainer();
                            break;
                        #endregion SelectionItemPattern
                        #region SelectionPattern
                        case "GetSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetSelection();
                            break;
                        case "CanSelectMultiple":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanSelectMultiple();
                            break;
                        case "IsSelectionRequired":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsSelectionRequired();
                            break;
                        #endregion SelectionPattern
                        #region TogglePattern
                        case "Toggle":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformToggle();
                            break;
                        #endregion TogglePattern
                        #region TransformPattern
                        case "Move":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformMove(
                                    (double)invocation.Arguments[0],
                                    (double)invocation.Arguments[1]);
                            break;
                        case "Resize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformResize(
                                    (double)invocation.Arguments[0],
                                    (double)invocation.Arguments[1]);
                            break;
                        case "Rotate":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformRotate(
                                    (double)invocation.Arguments[0]);
                            break;
                        #endregion TransformPattern
                        #region ValuePattern
                        case "get_Value":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetValue();
                            break;
                        case "set_Value":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSetValue(
                                    invocation.Arguments[0].ToString());
                            break;
                        case "get_IsReadOnly":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsReadOnly();
                            break;
                        #endregion ValuePattern
                        #region WindowPattern
                        case "SetWindowVisualState": //(WindowVisualState state);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSetWindowVisualState(
                                    (WindowVisualState)invocation.Arguments[0]);
                            break;
                        case "Close":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformClose();
                            break;
                        case "WaitForInputIdle": //(int milliseconds);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformWaitForInputIdle(
                                    (int)invocation.Arguments[0]);
                            break;
                        case "get_CanMaximize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanMaximize();
                            break;
                        case "get_CanMinimize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanMinimize();
                            break;
                        case "get_IsModal":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsModal();
                            break;
                        case "get_IsTopmost":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsTopmost();
                            break;
                        case "get_WindowInteractionState":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetWindowInteractionState();
                            break;
                        case "get_WindowVisualState":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetWindowVisualState();
                            break;
                        #endregion WindowPattern
                        default:
//Console.WriteLine("selection of what to proceed - default");
//                            returnItself = false;
                            invocation.Proceed();
                        	break;
                    }
//Console.WriteLine("resetting the flag");
                    AlreadySelected = false;
                } else {
//Console.WriteLine("Proceed");
                    // invocation.
                    invocation.Proceed();
                }
                if (invocation.ReturnValue == invocation.InvocationTarget) {
                    invocation.ReturnValue = invocation.Proxy;
                }
//if (null != invocation.ReturnValue) {
    //Console.WriteLine("null != invocation.ReturnValue");
    //Console.WriteLine(invocation.ReturnValue.GetType().Name);
    //Console.WriteLine("the proxy itself:");
    //Console.WriteLine(invocation.Proxy.GetType().Name);
//}
//                if (returnItself) {
//                    invocation.ReturnValue = invocation.Proxy;
//                }
            }
            catch {
                AlreadySelected = false;
                // 
            }
        }
    }
}
