/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2013
 * Time: 11:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using UIAutomation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of RealCodeCaller.
    /// </summary>
    public static class RealCodeCaller
    {
        public static List<IUiElement> GetResultList_ViaWildcards_Legacy(GetControlCmdletBase cmdlet, IUiElement element, Condition condition)
        {
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            List<IUiElement> resultList =
                cmdletDerived.GetAutomationElementsWithFindAll(
                    element,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.ControlType,
                    condition,
                    false,
                    false,
                    false,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ViaWildcards(GetControlCmdletBase cmdlet, IUiElement element, Condition condition)
        {
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            List<IUiElement> resultList =
                cmdletDerived.SearchByWildcardOrRegexViaUia(
                    cmdlet,
                    element,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    condition,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ExactSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                cmdlet.SearchByExactConditionsViaUia(cmdlet, element, conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_TextSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                cmdlet.SearchByContainsTextViaUia(cmdlet, element, conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_ReturnOnlyRightElements(GetControlCmdletBase cmdlet, IUiElement[] elements, bool useWildcardOrRegex)
        {
            HasTimeoutCmdletBase cmdletDerived = new HasTimeoutCmdletBase();
            
//            List<IUiElement> resultList =
//                cmdletDerived.SearchByWildcardOrRegexViaUia(
//                    cmdlet,
//                    element,
//                    cmdlet.Name,
//                    cmdlet.AutomationId,
//                    cmdlet.Class,
//                    cmdlet.Value,
//                    condition,
//                    true);
//            
//            return resultList;
            
            List<IUiElement> resultList =
                HasTimeoutCmdletBase.ReturnOnlyRightElements(
                    cmdletDerived,
                    elements,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.ControlType,
                    false,
                    useWildcardOrRegex);
            
Console.WriteLine("GetResultList_ReturnOnlyRightElements: 00001");
if (null == resultList) {
    Console.WriteLine("null == resultList");
} else {
    Console.WriteLine(resultList.GetType().Name);
    Console.WriteLine(resultList.Count.ToString());
    if (0 < resultList.Count) {
        foreach (var e1 in resultList) {
            Console.WriteLine(e1.Current.Name);
            Console.WriteLine(e1.Current.AutomationId);
            Console.WriteLine(e1.Current.ClassName);
            try {
                IMySuperValuePattern valuePattern =
                    e1.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern);
                Console.WriteLine(valuePattern.Current.Value);
            } catch (Exception eee) {
                Console.WriteLine(eee.Message);
            }
            
        }
    }
}
            
            return resultList;
        }
    }
}
