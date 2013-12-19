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
        internal static bool Active { get; set; }
        
        public override void Intercept(IInvocation invocation)
        {
            try {
                if (!Active) {
                    Active = true;
                    switch (invocation.Method.Name) {
                        #region InvokePattern
                        case "Click":
                            (invocation.Proxy as IUiElement).PerformClick();
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
                        default:
                            invocation.Proceed();
                        	break;
                    }
                    Active = false;
                } else {
                    invocation.Proceed();
                }
            }
            catch {
                // 
            }
        }
    }
}
