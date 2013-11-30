/*
 * Created by SharpDevelop.
 * User: Alexander
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
//        public RealCodeCaller()
//        {
//        }
        
        //private ArrayList GetResultArrayList(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, Condition condition)
        public static ArrayList GetResultArrayList_ViaWildcards(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, Condition condition)
        {
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            ArrayList resultList =
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
        
        // 20131128
        // public static ArrayList GetResultArrayList_ExactSearch(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, AndCondition conditions)
        public static ArrayList GetResultArrayList_ExactSearch(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, OrCondition conditions)
        {
            GetControlCmdletBase cmdletDerived = new GetControlCmdletBase();
            cmdlet.ResultArrayListOfControls = new ArrayList();
            //cmdletDerived.ResultArrayListOfControls = new ArrayList();
            
            cmdletDerived.SearchByExactConditionsViaUia(cmdlet, element, conditions, cmdlet.ResultArrayListOfControls);
            //cmdletDerived.SearchByExactConditionsViaUia(cmdlet, element, conditions, cmdletDerived.ResultArrayListOfControls);
            
            return cmdlet.ResultArrayListOfControls;
        }
    }
}
