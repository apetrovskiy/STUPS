/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/7/2013
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Windows.Automation;
    //using System.Text.RegularExpressions;
    using System.Collections;
    //using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExtensionsMethods.
    /// </summary>
    public static class ExtensionsMethods
    {
        //public static void GetByWildcard(this IAutomationElementCollection collection, string wildcard)
        //public static void GetByWildcard(this AutomationElementCollectionAdapter collection, string wildcard)
        public static IEnumerable GetByWildcard(this AutomationElementCollectionAdapter collection, string wildcard)
        {
            WildcardOptions options;
            //if (caseSensitive) {
            //    options =
            //        WildcardOptions.Compiled;
            //} else {
                options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
            //}
            
            System.Collections.Generic.List<AutomationElement> list = collection.Cast<AutomationElement>().ToList();

            /*
            foreach (AutomationElement element in collection) {
                list.Add(element);
            }
            */

            WildcardPattern wildcardName = 
                new WildcardPattern(wildcard, options);
            
//            var query = collection.SourceCollection.AsQueryable()
//                    .Where<AutomationElement>(
//                        item => (wildcardName.IsMatch(item.Current.Name)
//                                )
//                       )
//                    .ToArray<AutomationElement>();
            
            var query2 = from item1
                in list
                where wildcardName.IsMatch(item1.Current.Name)
                select item1;
            
            foreach (var element in query2) {
                
                Console.WriteLine("//////////////////////////////////////////");
                Console.WriteLine(element.Current.Name);
                Console.WriteLine(element.Current.AutomationId);
            }
            
            return query2;
        }
    }
}