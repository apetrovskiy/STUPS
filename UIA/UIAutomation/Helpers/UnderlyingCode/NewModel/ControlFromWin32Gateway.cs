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
    public class ControlFromWin32Gateway : ControlGateway
    {
        // public override List<IUiElement> GetElements(SearcherTemplateData data)
        public override List<IUiElement> GetElements(HandleCollector handleCollector, ControlSearcherTemplateData data)
        {
            var resultCollection = new List<IUiElement>();
            
            // 20140219
            var controlSearcherData = data as SingleControlSearcherData;
            
            if (null == controlSearcherData) {
                controlSearcherData = SearchData as SingleControlSearcherData;
            } else {
                SearchData = data;
            }
//            // 20140218
//            SearchData = data;
//            
//            var controlSearcherData = data as SingleControlSearcherData; 
            
            // if (null == controlSearcherData.InputObject) { return resultCollection; } // this was a stopper
            
            // ??
            // controlTitle = string.IsNullOrEmpty(controlTitle) ? "*" : controlTitle;
            // controlValue = string.IsNullOrEmpty(controlValue) ? "*" : controlValue;
            
            try {
                
                // 20140219
                // var handleCollector = new HandleCollector();
                // var handleCollector = AutomationFactory.GetObject<HandleCollector>();
                
                var handlesCollection =
                    handleCollector.CollectRecursively(
                        controlSearcherData.InputObject,
                        controlSearcherData.Name,
                        1);
                
                // 20140218
                /*
                List<IntPtr> handlesCollection =
                    controlSearcherData.InputObject.GetControlByNameViaWin32Recursively(
                        controlSearcherData.Name,
                        1);
                */
                
                const WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                
                var wildcardName =
                    new WildcardPattern(controlSearcherData.Name, options);
                var wildcardValue =
                    new WildcardPattern(controlSearcherData.Value, options);
                
                if (null == handlesCollection || 0 == handlesCollection.Count) return resultCollection;
                
                foreach (IntPtr controlHandle in handlesCollection) {
                    try {
                        if (IntPtr.Zero == controlHandle) continue;
                        
                        IUiElement tempElement =
                            UiElement.FromHandle(controlHandle);
                        
                        if (tempElement.IsMatchWildcardPattern(resultCollection, wildcardName, tempElement.Current.Name)) continue;
                        if (tempElement.IsMatchWildcardPattern(resultCollection, wildcardName, tempElement.Current.AutomationId)) continue;
                        if (tempElement.IsMatchWildcardPattern(resultCollection, wildcardName, tempElement.Current.ClassName)) continue;
                        try {
                            string elementValue =
                                tempElement.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Current.Value;
                            if (tempElement.IsMatchWildcardPattern(resultCollection, wildcardName, elementValue)) continue;
                            if (tempElement.IsMatchWildcardPattern(resultCollection, wildcardValue, elementValue)) continue;
                        }
                        catch { //(Exception eValuePattern) {
                        }
                    }
                    catch (Exception eGetAutomationElementFromHandle) {
                        // cmdlet.WriteVerbose(cmdlet, eGetAutomationElementFromHandle.Message);
                    }
                }
                return resultCollection;
            } catch (Exception eWin32Control) {
                // cmdlet.WriteVerbose(cmdlet, "UiaHelper.GetControlByName() failed");
                // cmdlet.WriteVerbose(cmdlet, eWin32Control.Message);
                return resultCollection;
            }
        }
    }
}
