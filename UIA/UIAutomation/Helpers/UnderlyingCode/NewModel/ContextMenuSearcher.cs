/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2014
 * Time: 9:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Management.Automation;
    using System.Linq;
    using PSTestLib;
    
    /// <summary>
    /// Description of ContextMenuSearcher.
    /// </summary>
    public class ContextMenuSearcher : SearcherTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        
        // internal int ProcessId { get; set; }
        private Condition conditionsForContextMenuSearch = null;
        
        public override void OnStartHook()
        {
            ContextMenuSearcherData data = SearcherData as ContextMenuSearcherData;
            
            conditionsForContextMenuSearch =
                new AndCondition(
                    new PropertyCondition(
                        AutomationElement.ProcessIdProperty,
                        data.ProcessId),
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Menu));
            
            ResultCollection = new List<IUiElement>();
        }
        
        public override void BeforeSearchHook()
        {
            
        }
        
        public override List<IUiElement> SearchForElements(SearcherTemplateData searchData)
        {
            ResultCollection.AddRange(
                UiElement.RootElement.FindAll(
                    TreeScope.Children,
                    conditionsForContextMenuSearch).ToArray().ToList());
            
            if (null == ResultCollection || 0 == ResultCollection.Count) {
                
                ResultCollection.AddRange(
                    (searchData as ContextMenuSearcherData).InputObject.FindAll(
                        TreeScope.Children,
                        conditionsForContextMenuSearch).ToArray().ToList());
            }
            
            return ResultCollection;
        }
        
        public override void AfterSearchHook()
        {
            
        }
        
        public override void OnFailureHook()
        {
            
        }
        
        public override void OnSuccessHook()
        {
            
        }
    }
}
