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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PSTestLib;
    
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of ControlFromWin32Gateway.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlFromWin32Provider : ControlProvider
    {
        public override List<IUiElement> GetElements(HandleCollector handleCollector, ControlSearcherTemplateData data)
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
            
            try {
                return FilterElements(handleCollector, controlSearcherData);
            } catch (Exception eWin32Control) {
                return resultCollection;
            }
        }
        
        internal List<IUiElement> FilterElements(HandleCollector handleCollector, SingleControlSearcherData controlSearcherData)
        {
            var resultCollection = new List<IUiElement>();
            
            const WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
            var wildcardName = new WildcardPattern(controlSearcherData.Name ?? "*", options);
            var wildcardValue = new WildcardPattern(controlSearcherData.Value ?? "*", options);
            
            foreach (IUiElement element in handleCollector.GetElementsFromHandles(handleCollector.CollectRecursively(controlSearcherData.InputObject, controlSearcherData.Name, 1))) {
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
