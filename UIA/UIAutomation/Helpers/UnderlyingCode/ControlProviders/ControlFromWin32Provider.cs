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
    //    using System.Collections;
    //    using System.Collections.Generic;
    //    using System.Management.Automation;
//
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ControlFromWin32Gateway.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromWin32Provider : ControlProvider
    {
        // 20140228
        public HandleCollector HandleCollector { get; set; }
        
        // 20140228
        // public override List<IUiElement> GetElements(HandleCollector handleCollector, ControlSearcherTemplateData data)
        public override List<IUiElement> GetElements(ControlSearcherTemplateData data)
        {
            var resultCollection = new List<IUiElement>();
            
            SingleControlSearcherData controlSearcherData = null;
            if (null != data) {
                controlSearcherData = data.ConvertControlSearcherTemplateDataToSingleControlSearcherData();
                SearchData = data;
            }
            if (null == controlSearcherData) {
                controlSearcherData = SearchData.ConvertControlSearcherTemplateDataToSingleControlSearcherData();
                
            }
            if (null == controlSearcherData) return resultCollection;
            
            // 20140224
            if (!string.IsNullOrEmpty(controlSearcherData.ContainsText)) {
                controlSearcherData.Name = controlSearcherData.Value = controlSearcherData.ContainsText;
            }
            
            try {
                // 20140228
                // return FilterElements(handleCollector, controlSearcherData);
                return FilterElements(controlSearcherData);
            } catch (Exception eWin32Control) {
                return resultCollection;
            }
        }
        
        // 20140228
        // internal List<IUiElement> FilterElements(HandleCollector handleCollector, SingleControlSearcherData controlSearcherData)
        internal List<IUiElement> FilterElements(SingleControlSearcherData controlSearcherData)
        {
            var resultCollection = new List<IUiElement>();
            
            const WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
            var wildcardName = new WildcardPattern(controlSearcherData.Name ?? "*", options);
            var wildcardValue = new WildcardPattern(controlSearcherData.Value ?? "*", options);
            
            // 20140228
            // foreach (IUiElement element in handleCollector.GetElementsFromHandles(handleCollector.CollectRecursively(controlSearcherData.InputObject, controlSearcherData.Name, 1))) {
            foreach (IUiElement element in HandleCollector.GetElementsFromHandles(HandleCollector.CollectRecursively(controlSearcherData.InputObject, controlSearcherData.Name, 1))) {
                if (element.IsMatchWildcardPattern(resultCollection, wildcardName, element.Current.Name))
                    continue;
                if (element.IsMatchWildcardPattern(resultCollection, wildcardName, element.Current.AutomationId))
                    continue;
                if (element.IsMatchWildcardPattern(resultCollection, wildcardName, element.Current.ClassName))
                    continue;
                try {
                    string elementValue = element.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Current.Value;
                    if (element.IsMatchWildcardPattern(resultCollection, wildcardName, elementValue))
                        continue;
                    if (element.IsMatchWildcardPattern(resultCollection, wildcardValue, elementValue))
                        continue;
                } catch {
                }
            }
            
            return resultCollection;
        }
    }
}
