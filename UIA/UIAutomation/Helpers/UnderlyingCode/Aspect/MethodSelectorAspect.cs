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
                            (invocation.Proxy as IUiElement).PerformClick();
                            // (invocation.Proxy as UiElement).Click();
                            break;
                        case "DoubleClick":
                            (invocation.Proxy as IUiElement).PerformDoubleClick();
                            break;
                        #endregion InvokePattern
                        #region SelectionItemPattern
                        case "Select":
                            (invocation.Proxy as IUiElement).PerformSelect();
                            break;
                        case "AddToSelection":
                            (invocation.Proxy as IUiElement).PerformAddToSelection();
                            break;
                        case "RemoveFromSelection":
                            (invocation.Proxy as IUiElement).PerformRemoveFromSelection();
                            break;
                        case "get_IsSelected":
                            (invocation.Proxy as IUiElement).GetIsSelected();
                            break;
                        case "get_SelectionContainer":
                            (invocation.Proxy as IUiElement).GetSelectionContainer();
                            break;
                        #endregion SelectionItemPattern
                        #region SelectionPattern
                        case "GetSelection":
                            (invocation.Proxy as IUiElement).PerformGetSelection();
                            break;
                        case "CanSelectMultiple":
                            (invocation.Proxy as IUiElement).GetCanSelectMultiple();
                            break;
                        case "IsSelectionRequired":
                            (invocation.Proxy as IUiElement).GetIsSelectionRequired();
                            break;
                        #endregion SelectionPattern
                        #region TogglePattern
                        case "Toggle":
                            (invocation.Proxy as IUiElement).PerformToggle();
                            break;
                        #endregion TogglePattern
                        #region ValuePattern
                        case "get_Value":
                            // (invocation.Proxy as IUiElement).v
                            break;
                        case "set_Value":
                            //
                            break;
                        case "get_IsReadOnly":
                            //
                            break;
                        #endregion ValuePattern
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
                // 
            }
        }
    }
}
