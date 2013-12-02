/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/7/2013
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace UIAutomation
{
    using System;
    using System.Windows.Automation;
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExtensionsMethods.
    /// </summary>
    public static class ExtensionsMethods
    {
        public static IEnumerable GetElementsByWildcard(this MySuperCollection collection, string name, string automationId, string className, string txtValue, bool caseSensitive)
        {
            WildcardOptions options;
            if (caseSensitive) {
                options =
                    WildcardOptions.Compiled;
            } else {
                options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
            }
            
            List<IMySuperWrapper> list = collection.Cast<IMySuperWrapper>().ToList();
            
            WildcardPattern wildcardName = 
                new WildcardPattern((string.IsNullOrEmpty(name) ? "*" : name), options);
            WildcardPattern wildcardAutomationId = 
                new WildcardPattern((string.IsNullOrEmpty(automationId) ? "*" : automationId), options);
            WildcardPattern wildcardClassName = 
                new WildcardPattern((string.IsNullOrEmpty(className) ? "*" : className), options);
            WildcardPattern wildcardValue = 
                new WildcardPattern((string.IsNullOrEmpty(txtValue) ? "*" : txtValue), options);
            
            var queryByBigFour = from collectionItem
                in list
                where wildcardName.IsMatch(collectionItem.Current.Name) &&
                      wildcardAutomationId.IsMatch(collectionItem.Current.AutomationId) &&
                      wildcardClassName.IsMatch(collectionItem.Current.ClassName) &&
                      (collectionItem.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
                      wildcardValue.IsMatch((collectionItem.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value) :
                      // check whether the -Value parameter has or hasn't value
                      ("*" == txtValue ? true : false))
                select collectionItem;
            
            // disposal
            list = null;
            
            return queryByBigFour;
        }
        
        public static IEnumerable GetElementsByWildcard(this MySuperCollection collection, string name, string automationId, string className, string txtValue)
        {
            return GetElementsByWildcard(collection, name, automationId, className, txtValue, false);
        }
        
        public static IMySuperCollection ConvertCmdletInputToCollectionAdapter(this ICollection inputArray)
        {
            IMySuperCollection resultCollection =
                ObjectsFactory.GetMySuperCollection(inputArray);
            return resultCollection;
        }
    }
}