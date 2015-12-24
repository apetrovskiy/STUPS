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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Collections.Generic;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Linq;
    
    /// <summary>
    /// Description of ContextMenuSearcher.
    /// </summary>
    [UiaSpecialBinding]
    public class ContextMenuSearcher : SearcherTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        
        private classic.Condition conditionsForContextMenuSearch = null;
        
        public override void OnStartHook()
        {
            var data = SearcherData as ContextMenuSearcherData;
            
            conditionsForContextMenuSearch =
                new classic.AndCondition(
                    new classic.PropertyCondition(
                        classic.AutomationElement.ProcessIdProperty,
                        data.ProcessId),
                    new classic.PropertyCondition(
                        classic.AutomationElement.ControlTypeProperty,
                        classic.ControlType.Menu));
            
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
                    classic.TreeScope.Children,
                    conditionsForContextMenuSearch).ToArray().ToList());
            #endregion search from the root
            
            #region search from the input
            if (null == ResultCollection || 0 == ResultCollection.Count) {
                
                ResultCollection.AddRange(
                    (searchData as ContextMenuSearcherData).InputObject.FindAll(
                        classic.TreeScope.Children,
                        conditionsForContextMenuSearch).ToArray().ToList());
            }
            #endregion search from the input
            
            #region search from the window
            if (null == ResultCollection || 0 == ResultCollection.Count) {
                if (null != CurrentData.CurrentWindow) {
    
                    ResultCollection.AddRange(
                        CurrentData.CurrentWindow.FindAll(
                            classic.TreeScope.Children,
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
