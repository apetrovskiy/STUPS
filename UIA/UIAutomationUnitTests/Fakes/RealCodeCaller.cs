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
	using UIAutomationUnitTests.Helpers.Inheritance;
    // using System.Collections.ObjectModel;
    using UIAutomation;
    using System.Windows.Automation;
    using System.Linq;
    
    /// <summary>
    /// Description of RealCodeCaller.
    /// </summary>
    public static class RealCodeCaller
    {
        public static List<IUiElement> GetResultList_ViaWildcards_Legacy(IUiElement element, Condition condition, ControlSearcherData data)
        {
            var cmdletDerived = new GetControlCollectionCmdletBase();
            
            List<IUiElement> resultList =
                cmdletDerived.GetAutomationElementsWithFindAll(
                    element,
                    data,
                    condition,
                    false,
                    false,
                    false,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ViaWildcards(IUiElement element, Condition condition, ControlSearcherData data)
        {
            List<IUiElement> resultList =
                ControlSearcher.SearchByWildcardOrRegexViaUia(
                    element,
                    data,
                    condition,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ExactSearch(IUiElement element, Condition conditions, Hashtable[] searchCriteria)
        {
            var resultListOfControls =
                ControlSearcher.SearchByExactConditionsViaUia(
                    element,
                    searchCriteria,
                    conditions);
            return resultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_TextSearch(IUiElement element, Condition conditions)
        {
            var resultListOfControls =
                ControlSearcher.SearchByContainsTextViaUia(element, conditions);
            return resultListOfControls;
        }
        
        public static List<IUiElement> SearchByContainsTextViaWin32(
        	IUiElement inputObject,
            string containsText,
            string[] controlTypeNames,
            IEnumerable<IUiElement> collection,
            IEnumerable<int> handles)
        {
        	var singleControlSearcherData = new SingleControlSearcherData { Name = containsText, ControlType = controlTypeNames };
        	var controlProvider = FakeFactory.GetControlFromWin32Provider(collection, singleControlSearcherData);
        	
        	if (null == collection || 0 == collection.Count()) {
        	    return ControlSearcher.SearchByContainsTextViaWin32(inputObject, controlProvider, FakeFactory.GetHandleCollector(inputObject, new int[] {}, collection.ToArray())).ToList();
        	} else {
        	    return ControlSearcher.SearchByContainsTextViaWin32(inputObject, controlProvider, FakeFactory.GetHandleCollector(inputObject, new int[] {}, collection.ToArray())).ToList();
        	}
        }
        
        public static List<IUiElement> GetResultList_ReturnOnlyRightElements(IEnumerable<IUiElement> elements, ControlSearcherData data, bool useWildcardOrRegex)
        {
            List<IUiElement> resultList =
                WindowSearcher.ReturnOnlyRightElements(
                    elements,
                    data,
                    false,
                    useWildcardOrRegex);
            
            return resultList;
        }
        
        public static bool GetResult_IsStepActive(Hashtable[] searchCriteria, IUiEltCollection elements)
        {
            var step = new WizardStep("stepName", 1) {
                Description = "description",
                SearchCriteria = searchCriteria
            };
            
            var wizard = new Wizard("wizardName");
            
            return wizard.IsStepActive(step, elements);
        }
        
        public static List<IUiElement> GetResultList_GetWindowCollectionByPid(
            IUiElement rootElement,
            WindowSearcherData data)
        {
            var windowSearcher = new WindowSearcher();
            
            List<IUiElement> resultList =
                windowSearcher.GetWindowCollectionByPid(
                    rootElement,
                    data);
            
            return resultList;
        }
        
        public static List<IUiElement> Win32Gateway_GetElements_WithControlSearcherDataInput(
            IUiElement rootElement,
            IUiElement[] elements,
            IEnumerable<int> handles,
            string searchString)
        {
            var controlProvider = new ControlFromWin32Provider();
            var controlSearcherData = new ControlSearcherTemplateData {
                ContainsText = searchString,
                Name = searchString,
                Win32 = true,
                InputObject = new IUiElement[] { rootElement }
            };
            controlProvider.SearchData = controlSearcherData;
            
            var handleCollector = FakeFactory.GetHandleCollector(rootElement, handles, elements);
            
            List<IUiElement> resultList =
                controlProvider.GetElements(
                    handleCollector,
                    controlSearcherData);
            
            return resultList;
        }
        
        public static List<IUiElement> Win32Gateway_GetElements_NullControlSearcherDataInput(
            IUiElement rootElement,
            IUiElement[] elements,
            IEnumerable<int> handles,
            string searchString)
        {
            var controlProvider = new ControlFromWin32Provider();
            var controlSearcherData = new ControlSearcherTemplateData {
                ContainsText = searchString,
                Name = searchString,
                Win32 = true,
                InputObject = new IUiElement[] { rootElement }
            };
            controlProvider.SearchData = controlSearcherData;
            
            var handleCollector = FakeFactory.GetHandleCollector(rootElement, handles, elements);
            
            List<IUiElement> resultList =
                controlProvider.GetElements(
                    handleCollector,
                    null);
            
            return resultList;
        }
    }
}
