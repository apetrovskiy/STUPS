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
        //public static void GetByWildcard(this MySuperCollection collection, string wildcard)
        public static IEnumerable GetByWildcard(this MySuperCollection collection, string wildcard)
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
            
            // 20131109
            //System.Collections.Generic.List<AutomationElement> list = collection.Cast<AutomationElement>().ToList();
            System.Collections.Generic.List<IMySuperWrapper> list = collection.Cast<IMySuperWrapper>().ToList();

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
                
                //Console.WriteLine("//////////////////////////////////////////");
                //Console.WriteLine(element.Current.Name);
                //Console.WriteLine(element.Current.AutomationId);
            }
            
            // 20131119
            // disposal
            list = null;
            
            return query2;
        }
        
        // 20131108
        // 20131109
        //public static IAutomationElementCollection ConvertCmdletInputToCollectionAdapter(this AutomationElement[] inputArray)
        public static IMySuperCollection ConvertCmdletInputToCollectionAdapter(this ICollection inputArray)
        {
            IMySuperCollection resultCollection =
                // 20131119
                //new MySuperCollection(inputArray);
                ObjectsFactory.GetMySuperCollection(inputArray);
                //new MySuperCollection(); //inputArray.Cast<IMySuperWrapper>().ToList());
            //resultCollection.SourceCollection = inputArray;
//            foreach (AutomationElement element in inputArray) {
//                
//            }
            return resultCollection;
        }
        
//        public static IAutomationElementCollection ConvertCmdletInputToCollectionAdapter(this object[] inputArray)
//        {
//            IAutomationElementCollection resultCollection =
//                new MySuperCollection(inputArray);
//            return resultCollection;
//        }
    }
}