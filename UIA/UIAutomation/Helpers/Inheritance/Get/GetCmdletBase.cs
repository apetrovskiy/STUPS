/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
//    using System.Windows.Automation;
    using System.Collections;
//    using System.Linq;
//    using System.Linq.Expressions;

    /// <summary>
    /// Description of GetCmdletBase.
    /// </summary>
    public class GetCmdletBase : HasTimeoutCmdletBase
    {
        #region Constructor
        public GetCmdletBase()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        
        [Parameter(Mandatory = false)]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "Win32")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "UIAuto")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "Window")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "First")]
        // 20130228
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "SearchCriteria")]
        public Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
                
        // 20120828
        protected internal ArrayList getFiltredElementsCollection(GetCmdletBase cmdlet, ArrayList elementCollection)
        {
            ArrayList resultCollection = new ArrayList();
            
            
            
            
            return resultCollection;
        }
        
//        internal ArrayList returnOnlyRightElements(
//            AutomationElementCollection results,
//            string name,
//            string automationId,
//            string className,
//            string textValue,
//            string[] controlType,
//            bool caseSensitive)
//        {
//                ArrayList resultCollection = new ArrayList();
//                
//                WildcardOptions options;
//                if (caseSensitive) {
//                    options =
//                        WildcardOptions.Compiled;
//                } else {
//                    options =
//                        WildcardOptions.IgnoreCase |
//                        WildcardOptions.Compiled;
//                }
//
//                if (string.Empty == name || 0 == name.Length) { name = "*"; }
//                if (string.Empty == automationId || 0 == automationId.Length) { automationId = "*"; }
//                if (string.Empty == className || 0 == className.Length) { className = "*"; }
//                if (string.Empty == textValue || 0 == textValue.Length) { textValue = "*"; }
//
//                WildcardPattern wildcardName = 
//                    new WildcardPattern(name, options);
//                WildcardPattern wildcardAutomationId = 
//                    new WildcardPattern(automationId, options);
//                WildcardPattern wildcardClass = 
//                    new WildcardPattern(className, options);
//                WildcardPattern wildcardValue = 
//                    new WildcardPattern(textValue, options);
//
//                System.Collections.Generic.List<AutomationElement> list =
//                    new System.Collections.Generic.List<AutomationElement>();
//                foreach (AutomationElement elt in results) {
//                    list.Add(elt);
//                }
//
//            try {
//                var query = list
////                    .Where<AutomationElement>(item => wildcardName.IsMatch(item.Current.Name))
////                    .Where<AutomationElement>(item => wildcardAutomationId.IsMatch(item.Current.AutomationId))
////                    .Where<AutomationElement>(item => wildcardClass.IsMatch(item.Current.ClassName))
////                    .Where<AutomationElement>(item => 
////                                              item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ? 
////                                              //(("*" != textValue) ? wildcardValue.IsMatch((item.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value) : false) :
////                                              (("*" != textValue) ? (positiveMatch(item, wildcardValue, textValue)) : (negativeMatch(textValue))) :
////                                              true
////                                              )
//                    .Where<AutomationElement>(
//                        item => (wildcardName.IsMatch(item.Current.Name) &&
//                                 wildcardAutomationId.IsMatch(item.Current.AutomationId) &&
//                                 wildcardClass.IsMatch(item.Current.ClassName) &&
//                                 // check whether a control has or hasn't ValuePattern
//                                 (item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
//                                  testRealValueAndValueParameter(item, name, automationId, className, textValue, wildcardValue) :
//                                  // check whether the -Value parameter has or hasn't value
//                                  ("*" == textValue ? true : false)
//                                 )
//                                )
//                       )
//                    .ToArray<AutomationElement>();
//
//                this.WriteVerbose(
//                    this,
//                    "There are " +
//                    query.Count().ToString() +
//                    " elements");
//
//                resultCollection.AddRange(query);
//
//                this.WriteVerbose(
//                    this,
//                    "There are " +
//                    resultCollection.Count.ToString() +
//                    " elements");
//                
//            }
//            catch {
//                
//            }
//            
//            return resultCollection;
//        }
//        
//        private bool testRealValueAndValueParameter(
//            AutomationElement item,
//            string name,
//            string automationId,
//            string className,
//            string textValue,
//            WildcardPattern wildcardValue)
//        {
//            bool result = false;
//            
//            // getting the real value of a control
//            string realValue = string.Empty;
//            try {
//                realValue =
//                    (item.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
//            }
//            catch {}
//            
//            // if a control's ValuePattern has no value
//            if (string.Empty == realValue) {
//                
//                if ("*" != name || "*" != automationId || "*" != className) {
//                    return true;
//                }
//                return result;
//            }
//            
//            // if there was not specified the -Value parameter
//            if ("*" == textValue) {
//                
//                if ("*" != name || "*" != automationId || "*" != className) {
//                    return true;
//                }
//                
//                // 20130208
//                //return result;
//            }
//            
//            result =
//                wildcardValue.IsMatch(realValue);
//
//            return result;
//        }
    }
}
