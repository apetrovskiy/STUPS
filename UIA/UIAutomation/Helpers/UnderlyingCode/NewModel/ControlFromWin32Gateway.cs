/*
 * Created by SharpDevelop.
 * User: Alexander
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
        public override List<IUiElement> GetElements(SearcherTemplateData data)
        {
            // 20140218
            var resultCollection = new List<IUiElement>();
            // List<IUiElement> resultCollection = new List<IUiElement>();
            
            var controlSearcherData = data as SingleControlSearcherData; 
            
            // cmdlet.WriteVerbose(cmdlet, "checking the container control");
            
            // if (null == containerElement) { return resultCollection; }
            if (null == controlSearcherData.InputObject) { return resultCollection; }
            // cmdlet.WriteVerbose(cmdlet, "checking the Name parameter");
            
            // ??
            // controlTitle = string.IsNullOrEmpty(controlTitle) ? "*" : controlTitle;
            // controlValue = string.IsNullOrEmpty(controlValue) ? "*" : controlValue;
            
            try {
                
                List<IntPtr> handlesCollection =
                    // containerElement.GetControlByNameViaWin32Recursively(
                    controlSearcherData.InputObject.GetControlByNameViaWin32Recursively(
                        //controlTitle,
                        controlSearcherData.Name,
                        1);
                
                const WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                
                // 20140218
                var wildcardName =
                    // new WildcardPattern(controlTitle, options);
                    new WildcardPattern(controlSearcherData.Name, options);
                var wildcardValue =
                    new WildcardPattern(controlSearcherData.Value, options);
                /*
                WildcardPattern wildcardName =
                    new WildcardPattern(controlTitle, options);
                WildcardPattern wildcardValue =
                    new WildcardPattern(controlValue, options);
                */
                
                if (null == handlesCollection || 0 == handlesCollection.Count) return resultCollection;
                // cmdlet.WriteVerbose(cmdlet, "handles.Count = " + handlesCollection.Count.ToString());
                
                foreach (IntPtr controlHandle in handlesCollection) {
                    try {
                        // cmdlet.WriteVerbose(cmdlet, "checking a handle");
                        if (IntPtr.Zero == controlHandle) continue;
                        // cmdlet.WriteVerbose(cmdlet, "the handle is not null");
                        
                        IUiElement tempElement =
                            UiElement.FromHandle(controlHandle);
                        // cmdlet.WriteVerbose(cmdlet, "adding the handle to the collection");
                        
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
