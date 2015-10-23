/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/18/2014
 * Time: 12:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections.Generic;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ControlFromWin32Gateway.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromWin32Provider : ControlProviderTemplate
    {
        public HandleCollector HandleCollector { get; set; }
        
        internal override List<IUiElement> FilterElements(SingleControlSearcherData controlSearcherData, List<IUiElement> initialCollection)
        {
            const WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
            var wildcardName = new WildcardPattern(controlSearcherData.Name ?? "*", options);
            var wildcardValue = new WildcardPattern(controlSearcherData.Value ?? "*", options);
            
            foreach (IUiElement element in initialCollection) {
                if (element.IsMatchWildcardPattern(ResultCollection, wildcardName, element.GetCurrent().Name))
                    continue;
                if (element.IsMatchWildcardPattern(ResultCollection, wildcardName, element.GetCurrent().AutomationId))
                    continue;
                if (element.IsMatchWildcardPattern(ResultCollection, wildcardName, element.GetCurrent().ClassName))
                    continue;
                try {
                    string elementValue = element.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern).Current.Value;
                    if (element.IsMatchWildcardPattern(ResultCollection, wildcardName, elementValue))
                        continue;
                    if (element.IsMatchWildcardPattern(ResultCollection, wildcardValue, elementValue))
                        continue;
                } catch {
                }
            }
            
            return ResultCollection;
        }
        
        internal override List<IUiElement> LoadElements(SingleControlSearcherData controlSearcherData)
        {
            return HandleCollector.GetElementsFromHandles(HandleCollector.CollectRecursively(controlSearcherData.InputObject, controlSearcherData.Name, 1));
        }
        
//        public HandleCollector HandleCollector { get; set; }
//        
//        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
//        {
//            var resultCollection = new List<IUiElement>();
//            
//            SingleControlSearcherData controlSearcherData = null;
//            if (null != data) {
//                controlSearcherData = data.ConvertControlSearcherTemplateDataToSingleControlSearcherData();
//                SearchData = data;
//            }
//            if (null == controlSearcherData) {
//                controlSearcherData = SearchData.ConvertControlSearcherTemplateDataToSingleControlSearcherData();
//                
//            }
//            if (null == controlSearcherData) return resultCollection;
//            
//            if (!string.IsNullOrEmpty(controlSearcherData.ContainsText)) {
//                controlSearcherData.Name = controlSearcherData.Value = controlSearcherData.ContainsText;
//            }
//            
//            try {
//                return FilterElements(controlSearcherData);
//            } catch (Exception eWin32Control) {
//                return resultCollection;
//            }
//        }
//        
//        internal List<IUiElement> FilterElements(SingleControlSearcherData controlSearcherData)
//        {
//            var resultCollection = new List<IUiElement>();
//            
//            const WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
//            var wildcardName = new WildcardPattern(controlSearcherData.Name ?? "*", options);
//            var wildcardValue = new WildcardPattern(controlSearcherData.Value ?? "*", options);
//            
//            foreach (IUiElement element in HandleCollector.GetElementsFromHandles(HandleCollector.CollectRecursively(controlSearcherData.InputObject, controlSearcherData.Name, 1))) {
//                if (element.IsMatchWildcardPattern(resultCollection, wildcardName, element.GetCurrent().Name))
//                    continue;
//                if (element.IsMatchWildcardPattern(resultCollection, wildcardName, element.GetCurrent().AutomationId))
//                    continue;
//                if (element.IsMatchWildcardPattern(resultCollection, wildcardName, element.GetCurrent().ClassName))
//                    continue;
//                try {
//                    string elementValue = element.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern).Current.Value;
//                    if (element.IsMatchWildcardPattern(resultCollection, wildcardName, elementValue))
//                        continue;
//                    if (element.IsMatchWildcardPattern(resultCollection, wildcardValue, elementValue))
//                        continue;
//                } catch {
//                }
//            }
//            
//            return resultCollection;
//        }
    }
}
