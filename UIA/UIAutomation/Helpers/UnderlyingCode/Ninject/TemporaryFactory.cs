/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/15/2013
 * Time: 8:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of TemporaryFactory.
    /// </summary>
    public class TemporaryFactory
    {
        public static IUiElement RootElement()
        {
//		//	get {
//			    // switch (_innerElementType) {
//			    switch (element.InnerElementType) {
//			        case InnerElementTypes.AutomationElementNet:
//			            return AutomationFactory.GetUiElement(AutomationElement.RootElement);
////			        case InnerElementTypes.AutomationElementCom:
////			            //
//			        // case InnerElementTypes.UiElement:
//			        //     return RootElement;
//			        default:
//			            return AutomationFactory.GetUiElement(AutomationElement.RootElement);
//			    }
//		//	}
            return AutomationFactory.GetUiElement(AutomationElement.RootElement);
		}
    }
}
