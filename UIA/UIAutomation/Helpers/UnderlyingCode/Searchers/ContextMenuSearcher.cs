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
    [UiaSpecialBinding]
    public class ContextMenuSearcher : SearcherTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        
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
            #region search from the root
            ResultCollection.AddRange(
                UiElement.RootElement.FindAll(
                    TreeScope.Children,
                    conditionsForContextMenuSearch).ToArray().ToList());
            #endregion search from the root
            
            #region search from the input
            if (null == ResultCollection || 0 == ResultCollection.Count) {
                
                ResultCollection.AddRange(
                    (searchData as ContextMenuSearcherData).InputObject.FindAll(
                        TreeScope.Children,
                        conditionsForContextMenuSearch).ToArray().ToList());
            }
            #endregion search from the input
            
            #region search from the window
            if (null == ResultCollection || 0 == ResultCollection.Count) {
                if (null != CurrentData.CurrentWindow) {
    
                    ResultCollection.AddRange(
                        CurrentData.CurrentWindow.FindAll(
                            TreeScope.Children,
                            conditionsForContextMenuSearch).ToArray().ToList());
                }
            }
            #endregion search from the window
            
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
