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
        public static List<IMySuperWrapper> GetResultList_ViaWildcards_Legacy(GetControlCmdletBase cmdlet, IMySuperWrapper element, Condition condition)
        {
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            List<IMySuperWrapper> resultList =
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
        
        public static List<IMySuperWrapper> GetResultList_ViaWildcards(GetControlCmdletBase cmdlet, IMySuperWrapper element, Condition condition)
        {
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            List<IMySuperWrapper> resultList =
                new List<IMySuperWrapper>();
            
            cmdletDerived.SearchByWildcardOrRegexViaUia(
                cmdlet,
                ref resultList,
                element,
                cmdlet.Name,
                cmdlet.AutomationId,
                cmdlet.Class,
                cmdlet.Value,
                condition,
                true);
            
            return resultList;
        }
        
        public static List<IMySuperWrapper> GetResultList_ExactSearch(GetControlCmdletBase cmdlet, IMySuperWrapper element, Condition conditions)
        {
            cmdlet.ResultListOfControls = new List<IMySuperWrapper>();
            cmdlet.SearchByExactConditionsViaUia(cmdlet, element, conditions, cmdlet.ResultListOfControls);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IMySuperWrapper> GetResultList_TextSearch(GetControlCmdletBase cmdlet, IMySuperWrapper element, Condition conditions)
        {
            cmdlet.ResultListOfControls = new List<IMySuperWrapper>();
            cmdlet.SearchByContainsTextViaUia(cmdlet, element, conditions);
            return cmdlet.ResultListOfControls;
        }
    }
}
